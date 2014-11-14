using UnityEngine;
using System.Collections;

public class Light_WaypointTrigger : MonoBehaviour {

	public Transform[] ConnectedTo;
	public Transform[] OutOfMaze;

	private const float ACTIVATION_DISTANCE = 5f;

	void OnTriggerEnter(Collider col){
		if(col.tag == Global_Variables.LIGHT_OBST_TAG){
			Lights_Movement lm = col.gameObject.GetComponent<Lights_Movement>();

			if(!lm.FoundByPlayer){

				int r = Random.Range(0, ConnectedTo.Length);
				lm.HeadedTowards = ConnectedTo[r];

			}else if(lm.WayOutOfMaze.Length == 0){

				lm.WayOutOfMaze = OutOfMaze;

			}else{
				lm.ofMazeIndex++;
			}
		}
	}

	void OnTriggerStay(Collider col){
		if(col.tag == Global_Variables.LIGHT_OBST_TAG){
			if(col.gameObject.GetComponent<Lights_Movement>().turnedToBoat
			        && Input.GetButtonDown(Global_Variables.BYPASS_OBSTICLE)){

				if(Vector2.Distance(col.gameObject.transform.position, GameObject.FindGameObjectWithTag(Global_Variables.PLAYER_TAG).transform.position) < ACTIVATION_DISTANCE){
					col.gameObject.GetComponent<Lights_Movement>().HeadedTowards = ConnectedTo[0];
				}

			}
		}
	}

}
