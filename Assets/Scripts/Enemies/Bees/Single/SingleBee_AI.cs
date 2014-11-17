using UnityEngine;
using System.Collections;

public class SingleBee_AI : MonoBehaviour {

	public Transform DefensiveSpot;
	public float StoppingDistance;
	public float ReturnSpeed;
	public float ElevationOffset;
	public GameObject Bee;

	public bool playerInSight;
	private float speed;
	//private Vector3 previousPos;

	void Start(){
		speed = gameObject.GetComponentInChildren<Bee_Movement>().Speed;
		//previousPos = Bee.transform.position;
	}

	void FixedUpdate(){
		if(playerInSight){
			gameObject.GetComponentInChildren<Bee_Movement>().ResolveMovement();
		}else{
			if(Vector3.Distance(DefensiveSpot.position, Bee.transform.position) > StoppingDistance){
				MoveBackToSpot();
			}else{
				Vector3 pos = Bee.transform.position;
				pos.y += AddedElevation();
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.tag == Global_Variables.PLAYER_TAG){
			playerInSight = true;
		}
	}

	void OnTriggerExit(Collider col){
		if(col.tag == Global_Variables.PLAYER_TAG){
			playerInSight = false;
		}
	}

	private void MoveBackToSpot(){
		Vector3 current = Vector3.Lerp(Bee.transform.position, DefensiveSpot.position, Time.deltaTime * ReturnSpeed);
		Vector3 scale = Bee.transform.localScale;

		if((current.x - Bee.transform.position.x != 0) && Mathf.Sign(scale.x) != Mathf.Sign(current.x - Bee.transform.position.x)){
			scale.x = -1 * scale.x;
			Bee.transform.localScale = scale;
		}

		Bee.transform.position = current;

		//previousPos = Bee.transform.position;
	}

	private float AddedElevation(){
		float added = Mathf.PingPong(Time.time, 2 * ElevationOffset);

		return added - ElevationOffset;
	}
}
