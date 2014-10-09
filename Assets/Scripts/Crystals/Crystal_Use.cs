using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Obsticle_Stats))]
public class Crystal_Use : MonoBehaviour {

	private Light light;
	private BoxCollider trigger;
	private Obsticle_Stats stats;

	// Use this for initialization
	void Start () {
		light = gameObject.GetComponentInChildren<Light>();
		stats = gameObject.GetComponent<Obsticle_Stats>();
	}
	
	void OnTriggerStay(Collider col){
		if(col.tag == Global_Variables.PLAYER_TAG && Input.GetButtonDown(Global_Variables.BYPASS_OBSTICLE)){
			gameObject.GetComponentInChildren<Light>().enabled = false;
			gameObject.GetComponentInChildren<BoxCollider>().enabled = false;

			GameObject player = GameObject.FindGameObjectWithTag(Global_Variables.PLAYER_TAG);
			player.GetComponent<Player_Stats>().ChangeEnergy(-1 * stats.EnergyCost);
		}
	}
}
