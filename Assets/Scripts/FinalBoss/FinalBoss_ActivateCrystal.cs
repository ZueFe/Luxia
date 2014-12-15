using UnityEngine;
using System.Collections;

public class FinalBoss_ActivateCrystal : MonoBehaviour {

	[HideInInspector]
	public bool Activated;

	void OnTriggerStay(Collider col){
		if(col.tag == Global_Variables.PLAYER_TAG && Input.GetButtonDown(Global_Variables.BYPASS_OBSTICLE)){

			Player_Stats ps = col.gameObject.GetComponent<Player_Stats>();
			float energyCost = GetComponent<Obsticle_Stats>().EnergyCost;

			if(ps.GetEnergy() >= energyCost){
				ps.ChangeEnergy(-1 * energyCost);

				FinalBoss_GrowCrystalLight[] crystals = GetComponentsInChildren<FinalBoss_GrowCrystalLight>();

				foreach(FinalBoss_GrowCrystalLight c in crystals){
					c.activated = true;
				}
			}
		}
	}
}
