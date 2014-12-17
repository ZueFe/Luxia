using UnityEngine;
using System.Collections;

public class FinalBoss_ActivateCrystal : MonoBehaviour {

	[HideInInspector]
	public bool Activated;

	void OnTriggerStay(Collider col){
		if(!Activated && col.tag == Global_Variables.PLAYER_TAG && Input.GetButtonDown(Global_Variables.BYPASS_OBSTICLE)){
			Activated = true;

			Player_Stats ps = col.gameObject.GetComponent<Player_Stats>();
			float energyCost = GetComponent<Obsticle_Stats>().EnergyCost;

			if(ps.GetEnergy() >= energyCost){
				ps.ChangeEnergy(-1 * energyCost);

				FinalBoss_GrowCrystalLight[] crystals = GetComponentsInChildren<FinalBoss_GrowCrystalLight>();

				Dwarf_Movement dm = GameObject.FindGameObjectWithTag(Global_Variables.FINAL_BOSS_TAG).GetComponent<Dwarf_Movement>();

				if(dm == null){
					GameObject.FindGameObjectWithTag(Global_Variables.FINAL_BOSS_TAG).SetActive(false);
					GameObject.FindGameObjectWithTag(Global_Variables.FINAL_BOSS_TAG).SetActive(true);
					dm = GameObject.FindGameObjectWithTag(Global_Variables.FINAL_BOSS_TAG).GetComponent<Dwarf_Movement>();
				}else{
					GameObject.FindGameObjectWithTag(Global_Variables.FINAL_BOSS_TAG).GetComponent<Dwarf_Movement>().AddTarget(this.gameObject);
				}
				foreach(FinalBoss_GrowCrystalLight c in crystals){
					c.activated = true;
				}
			}
		}
	}
}
