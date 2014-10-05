using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Obsticle_Stats))]
public class Obsticle_Trigger : MonoBehaviour {

	private Obsticle_Stats stats;
	private MeshRenderer mesh;

	// Use this for initialization
	void Start () {
		stats = gameObject.GetComponent<Obsticle_Stats>();
	}
	
	void OnTriggerStay(Collider col){
		if(col.tag == Global_Variables.PLAYER_TAG && Input.GetButtonUp(Global_Variables.BYPASS_OBSTICLE)){
			gameObject.GetComponent<MeshRenderer>().enabled = true;

			BoxCollider[] colliders = gameObject.GetComponents<BoxCollider>();
			foreach(BoxCollider c in colliders){
				c.enabled = !c.enabled;
			}

			gameObject.layer = Global_Variables.COLLISION_LAYER;

			GameObject player = GameObject.FindGameObjectWithTag(Global_Variables.PLAYER_TAG);
			player.GetComponent<Player_Stats>().ChangeEnergy(-1 * stats.EnergyCost);
		}
	}
}
