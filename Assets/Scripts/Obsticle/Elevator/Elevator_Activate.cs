using UnityEngine;
using System.Collections;

public class Elevator_Activate : MonoBehaviour {

	public GameObject Elevator;

	private Obsticle_Stats stats;

	void Start () {
		stats = GetComponent<Obsticle_Stats>();
	}

	void OnTriggerStay(Collider col){
		if(col.tag == Global_Variables.PLAYER_TAG && Input.GetButtonDown(Global_Variables.BYPASS_OBSTICLE)){
			Player_Stats pStats = col.gameObject.GetComponent<Player_Stats>();
			
			if(pStats.GetEnergy() >= stats.EnergyCost && gameObject.transform.parent.GetComponentInChildren<Elevator_MoveFollowers>().CanMove){
				Obsticle_AnimHash hash = GetComponent<Obsticle_AnimHash>();
				
				GetComponent<Animator>().SetBool(hash.Activated, true);
				
				pStats.ChangeEnergy(-1f * stats.EnergyCost);	
			}
		}
	}

	void LeverActivated(){
		Obsticle_AnimHash hash = Elevator.GetComponent<Obsticle_AnimHash>();

		Elevator.GetComponent<Animator>().SetBool(hash.Activated, true);
	}
}
