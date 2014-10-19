using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Obsticle_Stats))]
public class Lamps_Activate : MonoBehaviour {

	private Obsticle_Stats stats;

	void Start(){
		stats = GetComponent<Obsticle_Stats>();
	}

	void OnTriggerStay(Collider col){
		if(col.tag == Global_Variables.PLAYER_TAG && Input.GetButtonDown(Global_Variables.BYPASS_OBSTICLE)){
			GameObject player =  GameObject.FindGameObjectWithTag(Global_Variables.PLAYER_TAG);
			Player_Stats pStats = player.GetComponent<Player_Stats>();

			if(pStats.GetEnergy() >= stats.EnergyCost){

			gameObject.GetComponent<Light>().enabled = true;
			gameObject.GetComponent<BoxCollider>().enabled = false;

			pStats.ChangeEnergy(-1 * stats.EnergyCost);
			}
		}
	}
}
