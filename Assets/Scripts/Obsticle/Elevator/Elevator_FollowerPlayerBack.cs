using UnityEngine;
using System.Collections;

public class Elevator_FollowerPlayerBack : MonoBehaviour {

	 void SwitchBackToPlayer(){
		Follow_Player fp = Camera.main.GetComponent<Game_Manager>().followerInstances[0].GetComponent<Follow_Player>();
		fp.Follows = GameObject.FindGameObjectWithTag(Global_Variables.PLAYER_TAG);
		fp.followsPlayer = true;
		fp.ReachFollowerTime /= Global_Variables.MOVE_TO_ELEVATOR_SMOOTHING;


		GameObject.FindGameObjectWithTag("GUI").GetComponent<gui> ().areInElevator = false;

		foreach(GameObject f in Camera.main.GetComponent<Game_Manager>().followerInstances){
			f.transform.parent = null;
		}
	}
}
