using UnityEngine;
using System.Collections;

public class Lights_FoundByPlayer : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if(col.tag == Global_Variables.PLAYER_TAG){
			GetComponent<Lights_Movement>().FoundByPlayer = true;
		}
	}
}
