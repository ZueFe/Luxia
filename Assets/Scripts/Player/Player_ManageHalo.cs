using UnityEngine;
using System.Collections;

public class Player_ManageHalo : MonoBehaviour {

	public Light playerLight;
	public float deathDecrease;

	float newHalo;
	
	// Update is called once per frame
	void Update () {
		Player_Stats ps = GameObject.FindGameObjectWithTag(Global_Variables.PLAYER_TAG).GetComponent<Player_Stats>();
		newHalo = (playerLight.range / 2) - (ps.MinRange / 2);

		if(ps.GetEnergy() <= 0){
			newHalo -= deathDecrease * Time.deltaTime;
		}

		GetComponent<Light>().range = (playerLight.range / 2) - (ps.MinRange / 2);		
	}
}
