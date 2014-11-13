using UnityEngine;
using System.Collections;

public class Key_Take : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if (col.tag == Global_Variables.PLAYER_TAG) {
			col.gameObject.GetComponent<Player_Inventory>().AddKey();
			Destroy(this.gameObject);
		}
	}
}
