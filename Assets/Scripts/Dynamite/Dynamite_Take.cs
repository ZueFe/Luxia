using UnityEngine;
using System.Collections;

public class Dynamite_Take : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if (col.tag == Global_Variables.PLAYER_TAG) {
			col.gameObject.GetComponent<Player_Inventory>().AddDynamite();

			GetComponent<BoxCollider>().enabled = false;

			MeshRenderer[] r = GetComponentsInChildren<MeshRenderer>();
			foreach(MeshRenderer rr in r){
				rr.enabled = false;
			}

		}
	}
}
