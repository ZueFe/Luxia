using UnityEngine;
using System.Collections;

public class Follow_Player : MonoBehaviour {

	public float Offset;
	public GameObject Follows;
	public float ReachFollowerTime = 0.5f;
	public float MaxFallDistance = 3f;
	public float ObsticleCheck = 1f;
	public bool followsPlayer;
	public LayerMask CollisionMasks;

	private Light playerLight;
	private bool hitPlayer = false;
	private const float FALL_OFFSET = 1.2f;
	private Animator anim;
	private Follower_AnimHash hash;
	private Vector3 scale;
	private Vector3 colSize;
	private float directionDamp;
	private float t;
	private bool stop;
	private bool dead;

	// Use this for initialization
	void Start () {
		if(followsPlayer){
			//player = GameObject.FindGameObjectWithTag("Player");
			playerLight = Follows.GetComponentInChildren<Light>();
		}

		anim = gameObject.GetComponent<Animator>();
		hash = gameObject.GetComponent<Follower_AnimHash>();
		colSize = gameObject.GetComponent<BoxCollider>().size;
	}
	
	// Update is called once per frame
	void Update () {
		if(Global_Variables.Instance.FreezeTime || dead){
			return;
		}

		if(Global_Variables.Instance.FolloweresFollowing){
			FollowPlayer();
		}else{
			anim.SetFloat(hash.Direction, 0f);
		}
	}

	/*void OnColliderEnter(Collision col){
		if(col.collider.tag == "Player" || col.collider.tag == "Follower"){
			hitPlayer = true;
		}else{
			hitPlayer = false;
		}
	}*/

	private void FollowPlayer(){

		if(followsPlayer && Follows.GetComponent<Player_Stats>().GetEnergy() <= 0){
			anim.SetFloat(hash.Direction, 0f);
			return;
		}

		float dist = GetDistanceWithPlayer();
		float direction = 0;
		float currentX = transform.position.x;

		if(followsPlayer && dist >= playerLight.range){
			anim.SetFloat(hash.Direction, 0f);
			return;
		}

		direction = Follows.transform.position.x - transform.position.x;

		if((!followsPlayer ||dist > Offset) &&
		   !(Follows.transform.position.x - Offset < transform.position.x && 
		 	Follows.transform.position.x + Offset > transform.position.x) &&
		   !hitPlayer){

			currentX = Mathf.SmoothDamp(transform.position.x, Follows.transform.position.x + Mathf.Sign(direction) * Offset, ref t, ReachFollowerTime);


			if(CheckForHole(currentX) ||CheckForObsticles(currentX - transform.position.x)){
				anim.SetFloat(hash.Direction, 0f);
				return;
			}
		}

		anim.SetFloat(hash.Direction, Mathf.SmoothDamp(anim.GetFloat(hash.Direction), 
		                                                         Mathf.Abs(currentX - transform.position.x), ref directionDamp, 0.1f));
		scale = transform.localScale;

		if((currentX - transform.position.x != 0) && Mathf.Sign(scale.x) != Mathf.Sign(currentX - transform.position.x)){
			scale.x = -1 * scale.x;
			transform.localScale = scale;
		}


		Vector3 moveTo = new Vector3(currentX, transform.position.y, transform.position.z);

		rigidbody.MovePosition(moveTo);		
	}

	private float GetDistanceWithPlayer(){
		Vector3 posFol = transform.position;
		Vector3 posPlay = Follows.transform.position;

		return Mathf.Pow(posFol.x - posPlay.x, 2) + Mathf.Pow(posFol.y - posPlay.y, 2) + Mathf.Pow(posFol.z - posPlay.z, 2);
	}

	private bool CheckForHole(float currentX){
		RaycastHit hit;

		if(!Physics.Raycast(new Vector2(currentX + FALL_OFFSET, transform.position.y), Vector3.down, MaxFallDistance + FALL_OFFSET)){
			return true;
		}

		if(!Physics.Raycast(new Vector2(currentX - FALL_OFFSET, transform.position.y), Vector3.down, MaxFallDistance + FALL_OFFSET)){
			return true;
		}

		return false;
	}

	private bool CheckForObsticles(float dir){
		RaycastHit hit;
		Ray ray;
		Vector2 direction = new Vector2(Mathf.Sign(dir), 0);

	
		ray = new Ray(transform.position, direction);

		if(Physics.Raycast(ray, out hit, ObsticleCheck, CollisionMasks)){
				return true;
		}


		return false;
	}

	public void KillFollower(){
		dead = true;
		anim.SetBool(hash.Dying, false);
	}

	public void DestroyFollower(){
		Destroy(this.gameObject);
	}
}
