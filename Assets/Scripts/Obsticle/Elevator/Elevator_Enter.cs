using UnityEngine;
using System.Collections;

public class Elevator_Enter : MonoBehaviour {

	public GameObject MoveTo;

	void OnTriggerEnter(Collider col){
		if(col.tag == Global_Variables.FOLLOWER_TAG){
			if(col.gameObject.GetComponent<Follow_Player>().Follows.tag == Global_Variables.PLAYER_TAG){
				//Followers start moving to elevator, check msg in GUI!

				Follow_Player fp = col.gameObject.GetComponent<Follow_Player>();

				fp.Follows = MoveTo;
				fp.followsPlayer = false;
				fp.ReachFollowerTime *= Global_Variables.MOVE_TO_ELEVATOR_SMOOTHING;
				GameObject.FindGameObjectWithTag("GUI").GetComponent<gui> ().areInElevator = true;
			}
		}
	}

}
