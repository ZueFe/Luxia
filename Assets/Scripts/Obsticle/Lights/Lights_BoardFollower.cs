using UnityEngine;
using System.Collections;

public class Lights_BoardFollower : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if(col.tag == Global_Variables.FOLLOWER_TAG){
			col.gameObject.transform.parent = this.gameObject.transform;
		}
	}

	void OnTriggerExit(Collider col){
		if(col.tag == Global_Variables.FOLLOWER_TAG){
			col.gameObject.transform.parent = null;
		}
	}
}
