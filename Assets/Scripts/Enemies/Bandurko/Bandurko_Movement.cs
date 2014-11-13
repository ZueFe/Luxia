using UnityEngine;
using System.Collections;

public class Bandurko_Movement : MonoBehaviour {

	public float Speed;
	public float FleeingSpeed;
	public float SpeedChangeTime = 1f;
	public float ObsticleCheck = 1f;
	public LayerMask CollisionMasks;

	[HideInInspector]
	public bool dead = false;

	[HideInInspector]
	public bool fleeing;
	[HideInInspector]
	public bool charming;

	private Rigidbody rigidbody;
	private float direction = 1f;
	private Animator anim;
	private float timerFromLastChange = 0;
	private float usedSpeed = 0f;
	private float t;

	private const float WAIT_FOR_DIRECTION_CHANGE = 5f;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		ToogleDirection();
		usedSpeed = 0f;

		anim = GetComponent<Animator>();

		GetComponent<AudioSource>().clip = (AudioClip) Resources.Load("Sounds/bandurko laugh", typeof(AudioClip));
		GetComponent<AudioSource>().audio.Play();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Global_Variables.Instance.FreezeTime){
			return;
		}

		if(!dead){
			timerFromLastChange += Time.deltaTime;

			if(CheckForObsticles(direction)){
				ToogleDirection();
			}

			if(fleeing){
				usedSpeed = Mathf.SmoothDamp(usedSpeed, FleeingSpeed,ref t, SpeedChangeTime);

				if(timerFromLastChange >= WAIT_FOR_DIRECTION_CHANGE && charming){
					ToogleDirection();
					timerFromLastChange = 0;
				}

			}else{
				usedSpeed = Mathf.SmoothDamp(usedSpeed, Speed,ref t, SpeedChangeTime);
			}
			rigidbody.MovePosition(new Vector3(this.transform.position.x + direction * usedSpeed * Time.deltaTime, this.transform.position.y, this.transform.position.z));
		}
	}

	private bool CheckForObsticles(float dir){
		RaycastHit hit;
		Ray ray;
		Vector2 direction = new Vector2(Mathf.Sign(dir), 0);

		ray = new Ray(this.transform.position, direction);
			
		if(Physics.Raycast(ray, out hit, ObsticleCheck, CollisionMasks)){
			return true;
		}
		
		return false;
	}

	private void ToogleDirection(){
		direction *= -1f;
		Vector3 newScale = this.transform.localScale;
		newScale.x *= -1f;
		
		this.transform.localScale = newScale;
	}
}
