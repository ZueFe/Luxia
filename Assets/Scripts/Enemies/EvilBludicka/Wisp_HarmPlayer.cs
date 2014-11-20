using UnityEngine;
using System.Collections;

public class Wisp_HarmPlayer : MonoBehaviour {

	public float DamagePerSec;

	void OnTriggerStay(Collider col){
		if(col.tag == Global_Variables.PLAYER_TAG){
			col.gameObject.GetComponent<Player_Stats>().ChangeEnergy(-1f * DamagePerSec * Time.deltaTime);
		}
	}
}
