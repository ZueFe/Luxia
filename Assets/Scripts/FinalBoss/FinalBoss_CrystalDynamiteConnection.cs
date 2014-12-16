using UnityEngine;
using System.Collections;

public class FinalBoss_CrystalDynamiteConnection : MonoBehaviour {
	
	[HideInInspector]
	public bool dwarfMining;
	public float ExplosionDistance;

	private FinalBoss_BlowRocks Crystal;

	void Start(){
		Crystal = transform.parent.GetComponentInChildren<FinalBoss_BlowRocks>();
	}

	void Update(){
		if(Crystal == null){
			Crystal = transform.parent.GetComponentInChildren<FinalBoss_BlowRocks>();
			return;
		}

		GameObject dwarf = GameObject.FindGameObjectWithTag(Global_Variables.FINAL_BOSS_TAG);

		if(dwarfMining && Crystal.RocksBlown &&
		   (Mathf.Abs(dwarf.transform.position.x - Crystal.transform.position.x) <= ExplosionDistance)){
			//do dmg to dwarf
			dwarfMining = false;


			dwarf.GetComponent<FinalBoss_Stats>().ChangeHP(-1 * dwarf.GetComponent<Dwarf_Movement>().dmgPerExplosion);
		}
	}
}
