using UnityEngine;
using System.Collections;

public class Follow_Player : MonoBehaviour {

	public float Offset;
	public GameObject Follows;
	public float Speed = 5f;
	public float MaxFallDistance = 3f;
	public float ObsticleCheck = 1f;
	public bool followsPlayer;
	public LayerMask CollisionMask;

	private Light playerLight;
	private bool hitPlayer = false;
	private const float FALL_OFFSET = 1.2f;
	private Animator anim;
	private Follower_AnimHash hash;
	private Vector3 scale;
	private Vector3 colSize;

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
		FollowPlayer();
	}

	void OnColliderEnter(Collision col){
		if(col.collider.tag == "Player" || col.collider.tag == "Follower"){
			hitPlayer = true;
		}else{
			hitPlayer = false;
		}
	}

	private void FollowPlayer(){
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
		
			currentX = incrementTowards(transform.position.x, Follows.transform.position.x + Mathf.Sign(direction) * Offset, Speed);

			if(CheckForHole(currentX) || CheckForObsticles(currentX - transform.position.x)){
				currentX = transform.position.x;
			}


		}


		anim.SetFloat(hash.Direction, Mathf.Abs(currentX - transform.position.x));
		//Debug.LogError(anim.GetFloat(hash.Direction));
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

	private float incrementTowards(float n, float target, float acceleration){
		if(n == target){			//if player moves in target speed
			return n;
		}
		
		float dir = Mathf.Sign(target - n);			//get sign of acceleration (either speed up or down)
		n += acceleration * Time.deltaTime * dir;	//accelerate (up or down) based on acceleration speed
		
		if(dir == Mathf.Sign(target - n)){			//if target speed is not reached return n
			return n;
		}
		
		return target;								//if target speed is reached (or is smaller) return traget speed
		//so you won't ever go faster than target speed
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

		for(int i = -1; i < 2; i++){
			ray = new Ray(new Vector2(transform.position.x, transform.position.y + colSize.y /6 * i),
			              direction);
		
			if(Physics.Raycast(ray, out hit, ObsticleCheck, CollisionMask)){
					return true;
			}
		}

		return false;
	}
}
