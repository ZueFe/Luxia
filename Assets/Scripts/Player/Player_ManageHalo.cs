using UnityEngine;
using System.Collections;

public class Player_ManageHalo : MonoBehaviour {

	public Light playerLight;
	
	// Update is called once per frame
	void Update () {
		GetComponent<Light>().range = playerLight.range / 2 - 2.5f;		
	}
}
