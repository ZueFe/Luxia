using UnityEngine;
using System.Collections;

public class Wisp_MazeTrigger : MonoBehaviour {

	void Start(){
		GetComponentInChildren<Wisp_Life>().InMaze = false;
	}

	void OnTriggerEnter(Collider col){
		if(col.tag == Global_Variables.PLAYER_TAG){
			GetComponentInChildren<Wisp_Life>().InMaze = true;
		}
	}

	void OnTriggerStay(Collider col){
		if(col.tag == Global_Variables.PLAYER_TAG){
			GetComponentInChildren<Wisp_Life>().InMaze = true;
		}
	}

	void OnTriggerExit(Collider col){
		if(col.tag == Global_Variables.PLAYER_TAG){
			GetComponentInChildren<Wisp_Life>().InMaze = false;
		}
	}
}
