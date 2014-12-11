using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	

	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown (Global_Variables.MAP) && Camera.main.GetComponent<Game_Camera>().getTarget().gameObject.tag==Global_Variables.PLAYER_TAG) {
			bool mapOn = GameObject.FindGameObjectWithTag("GUI").GetComponent<gui>().mapOn;

			mapOn = !mapOn;
			Global_Variables.Instance.FreezeTime = mapOn;

			GameObject.FindGameObjectWithTag("GUI").GetComponent<gui>().mapOn = mapOn;
		}
	
	}
}
