using UnityEngine;
using System.Collections;

public class FinalBoss_SetUpDynamite : MonoBehaviour {

	void OnTriggerStay(Collider col){
		if(col.tag == Global_Variables.PLAYER_TAG && Input.GetButtonDown(Global_Variables.BYPASS_OBSTICLE)){
			if(col.GetComponent<Player_Inventory>().HasDynamite){
				
				GetComponentInParent<Dynamite_Blinking>().blinking = false;
				GetComponentInParent<FinalBoss_BlowBoss>().dynamiteSet = true;
				col.GetComponent<Player_Inventory>().UseDynamite();
			}else{
				//DONT HAVE DYNAMITE
			}
		}
	}

}
