using UnityEngine;
using System.Collections;

public class FinalBoss_Exit : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if(col.tag == Global_Variables.FOLLOWER_TAG){
			Global_Variables.Instance.FreezeTime = true;
			GameObject.FindGameObjectWithTag("GUI").GetComponent<gui>().winScreenOn = true;
		}
	}
}
