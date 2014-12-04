using UnityEngine;
using System.Collections;

public class Final_PlayerEntered : MonoBehaviour {

	public bool PlayerEntered;

	void OnTriggerEnter(Collider col){
		if (col.tag == Global_Variables.PLAYER_TAG) {
			PlayerEntered = true;
		}
	}
}
