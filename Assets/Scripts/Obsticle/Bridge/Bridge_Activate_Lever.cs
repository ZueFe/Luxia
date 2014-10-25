using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Obsticle_Stats))]
public class Bridge_Activate_Lever : MonoBehaviour {

	public GameObject Bridge;

	private Obsticle_Stats stats;

	// Use this for initialization
	void Start () {
		stats = GetComponent<Obsticle_Stats>();
	}
	
	void OnTriggerStay(Collider col){
		if(col.tag == Global_Variables.PLAYER_TAG && Input.GetButtonDown(Global_Variables.BYPASS_OBSTICLE)){
			GameObject player =  GameObject.FindGameObjectWithTag(Global_Variables.PLAYER_TAG);
			Player_Stats pStats = player.GetComponent<Player_Stats>();
			
			if(pStats.GetEnergy() >= stats.EnergyCost){
				Bridge_AnimHash hash = GetComponent<Bridge_AnimHash>();

				GetComponent<Animator>().SetBool(hash.Activated, true);

				pStats.ChangeEnergy(-1f * stats.EnergyCost);
		
			}
		}
	}

	void LeverActivated(){
		Bridge_AnimHash hash = Bridge.GetComponent<Bridge_AnimHash>();
		
		Bridge.GetComponent<Animator>().SetBool(hash.Activated, true);

		BoxCollider[] cols = transform.parent.GetComponentsInChildren<BoxCollider>();

		foreach(BoxCollider c in cols){
			c.enabled = !c.enabled;
		}
	}
}
