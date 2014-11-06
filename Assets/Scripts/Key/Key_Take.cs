using UnityEngine;
using System.Collections;

public class Key_Take : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if (col.tag == Global_Variables.PLAYER_TAG) {
			GameObject player = GameObject.FindGameObjectWithTag(Global_Variables.PLAYER_TAG);

			player.GetComponent<Player_Inventory>().HasKey = true;
			Destroy(this.gameObject);
		}
	}
}
