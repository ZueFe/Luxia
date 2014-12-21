using UnityEngine;
using System.Collections;

public class Crystal_Recharge : MonoBehaviour {

	public float RechargeTime;

	private float timer;

	void Update () {
		if(!gameObject.GetComponentInChildren<Light>().enabled){
			timer += Time.deltaTime;
		}else{
			timer = 0;
		}

		if(timer >= RechargeTime){
			gameObject.GetComponentInChildren<Light>().enabled = true;
			gameObject.GetComponentInChildren<Light>().intensity = 5.6f;
			gameObject.GetComponentInChildren<BoxCollider>().enabled = true;
		}
	}
}
