using UnityEngine;
using System.Collections;

public class Bandurko_Movement : MonoBehaviour {

	public float Speed;
	public float ObsticleCheck = 1f;
	public LayerMask[] CollisionMasks;

	[HideInInspector]
	public bool dead = false;

	private Rigidbody rigidbody;
	private float direction = 1f;
	private Animator anim;
	

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		ToogleDirection();

		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!dead){
			if(CheckForObsticles(direction)){
				ToogleDirection();
			}
			rigidbody.MovePosition(new Vector3(this.transform.position.x + direction * Speed * Time.deltaTime, this.transform.position.y, this.transform.position.z));
		}
	}

	private bool CheckForObsticles(float dir){
		RaycastHit hit;
		Ray ray;
		Vector2 direction = new Vector2(Mathf.Sign(dir), 0);

		foreach(LayerMask c in CollisionMasks){
			ray = new Ray(this.transform.position, direction);
			
				if(Physics.Raycast(ray, out hit, ObsticleCheck, c)){
					return true;
				}
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
