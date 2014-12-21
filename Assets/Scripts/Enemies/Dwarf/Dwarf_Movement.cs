using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dwarf_Movement : MonoBehaviour {

	public float Speed;
	public float SpeedChangeTime = 1f;
	public float Offset;
	public float MinMiningTime;
	public float MaxMiningTime;
	public int ExplosionsToKill;
	public float ToRecoverFromStunt;
	public GameObject Dynamite;

	[HideInInspector]
	public float dmgPerExplosion;

	private GameObject currentTarget;
	private Rigidbody rigidbody;
	private float direction = -1f;
	private Animator anim;
	private float usedSpeed = 0f;
	private float t;
	private List<GameObject> targets;
	private float mingingTimeDecrease;
	private float currentMiningTimeRequired;
	private float miningTimer;

	private float stuntTimer;
	private bool isStunt;
	private bool isAttacking;
	private Vector3 scale;
	private float killTimer;
	private const float TIME_TO_KILL_FOLLOWER = 5f;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		mingingTimeDecrease = (MaxMiningTime - MinMiningTime) / ExplosionsToKill;
		currentMiningTimeRequired = MaxMiningTime;

		targets = new List<GameObject>(10);

		isAttacking = false;
		scale = transform.localScale;
		dmgPerExplosion = GetComponent<FinalBoss_Stats>().MaxHealth / ExplosionsToKill;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Global_Variables.Instance.FreezeTime){
			return;
		}
	
		if(!isStunt){
			PickTarget();

			if(currentTarget == null){
				return;
			}

			ResolveLocoMotion();
			CheckForStunt();
			CheckForDynamite();
		}else{
			ResolveStunt();
		}

		if (currentTarget.tag == Global_Variables.FOLLOWER_TAG ) {
			GameObject.FindGameObjectWithTag("GUI").GetComponent<gui>().bossAttacking = true;
		} else {
			GameObject.FindGameObjectWithTag("GUI").GetComponent<gui>().bossAttacking = false;
		}
	}

	private void ResolveLocoMotion(){
		direction = currentTarget.transform.position.x - this.transform.position.x;
		direction = Mathf.Sign(direction);

		Vector3 lScale = scale;
		lScale.x *= -1 * direction;
		transform.localScale = lScale;
		
		usedSpeed = Mathf.SmoothDamp(usedSpeed, Speed,ref t, SpeedChangeTime);
		float moveBy = direction * usedSpeed;
		
		if(Mathf.Abs(this.transform.position.x - currentTarget.transform.position.x) < Offset){
			moveBy = 0f;
			anim.SetBool(GetComponent<Dwarf_AnimHash>().Attacking, true);
			isAttacking = true;
		}else{
			anim.SetBool(GetComponent<Dwarf_AnimHash>().Attacking, false);
			isAttacking = false;
		}
		
		rigidbody.MovePosition(new Vector3(this.transform.position.x + moveBy * Time.deltaTime, this.transform.position.y, this.transform.position.z));
	}

	public void AddTarget(GameObject t){
		targets.Add(t);
	}

	public void RemoveTarget(GameObject t){
		targets.Remove(t);
	}

	private void PickTarget(){
		if(currentTarget != null && currentTarget.tag == Global_Variables.FOLLOWER_TAG && targets.Count == 0){
			killTimer += Time.deltaTime;

			if(isAttacking && killTimer >= TIME_TO_KILL_FOLLOWER){
				Camera.main.GetComponent<Game_FollowerDeath>().KillLastFollower(); //kill last follower when close
				killTimer = 0f;
			}

			return;			//attacking followers
		}

		if(currentTarget != null && currentTarget.tag == Global_Variables.FOLLOWER_TAG && targets.Count > 0){
			//crystal was lit was attacking followers
			currentTarget = targets[0];

			FinalBoss_CrystalDynamiteConnection crystal = currentTarget.GetComponent<FinalBoss_CrystalDynamiteConnection>();
			crystal.dwarfMining = true;


			RemoveTarget(targets[0]);
			return;
		}

		if(currentTarget != null && currentTarget.tag != Global_Variables.FOLLOWER_TAG){
			if(Mathf.Abs(this.transform.position.x - currentTarget.transform.position.x) <= Offset){

				//mining crystal
				miningTimer += Time.deltaTime;

				if(miningTimer >= currentMiningTimeRequired){
					DecreaseMiningTimer();

					FinalBoss_CrystalDynamiteConnection crystal = currentTarget.GetComponent<FinalBoss_CrystalDynamiteConnection>();
					crystal.dwarfMining = false;

					FinalBoss_GrowCrystalLight[] crystals = currentTarget.GetComponentsInChildren<FinalBoss_GrowCrystalLight>();
					foreach(FinalBoss_GrowCrystalLight f in crystals){
						f.activated = false;
					}

					currentTarget = null;
				}

				return;
			}
		}

		if (currentTarget == null){
			if(targets.Count > 0){
				currentTarget = targets[0];

				FinalBoss_CrystalDynamiteConnection crystal = currentTarget.GetComponent<FinalBoss_CrystalDynamiteConnection>();
				crystal.dwarfMining = true;
				
				RemoveTarget(targets[0]);
				return;
			}else{
				currentTarget = Camera.main.GetComponent<Game_FollowerDeath>().GetLastFollower();
			}
		}


	}

	public void DecreaseMiningTimer(){
		miningTimer = 0f;
		currentMiningTimeRequired -= mingingTimeDecrease;
	}

	public void RemoveCurrentTarget(GameObject t){
		if(t == currentTarget){
			currentTarget = null;
		}
	}
	private void CheckForStunt(){
		bool dynamitePlaced = false;

		if(Dynamite.activeSelf){
			dynamitePlaced = !Dynamite.GetComponentInChildren<Dynamite_Blinking>().blinking;
		}

		isStunt = (GetComponent<FinalBoss_Stats>().GetCurrentHealth() <= 1f || dynamitePlaced);
		GameObject.FindGameObjectWithTag("GUI").GetComponent<gui>().bossStunt = (GetComponent<FinalBoss_Stats>().GetCurrentHealth() <= 1f);
		GameObject.FindGameObjectWithTag ("GUI").GetComponent<gui> ().timer = 3;
	}

	private void CheckForDynamite(){
		if(isStunt){
			Dynamite.SetActive(true);
		}
	}

	private void ResolveStunt(){
		if(Dynamite.GetComponentInChildren<Dynamite_Blinking>().blinking){
			stuntTimer += Time.deltaTime;
		}

		if(stuntTimer >= ToRecoverFromStunt){
			isStunt = false;
			GameObject.FindGameObjectWithTag("GUI").GetComponent<gui>().bossStunt = false;
			GetComponent<FinalBoss_Stats>().ChangeHP(dmgPerExplosion - 1);
			Dynamite.SetActive(false);
			stuntTimer = 0;
		}
	}
}
