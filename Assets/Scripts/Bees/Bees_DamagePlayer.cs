using UnityEngine;
using System.Collections;

public class Bees_DamagePlayer : MonoBehaviour {

	public float DamagePerSecond;

	void OnTriggerStay(Collider col){
		if(col.tag == Global_Variables.PLAYER_TAG){
			col.gameObject.GetComponent<Player_Stats>().ChangeEnergy(-1 * DamagePerSecond * Time.deltaTime);
		}
	}
}
