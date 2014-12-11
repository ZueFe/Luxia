using UnityEngine;
using System.Collections;

public class Dynamite_Respawn : MonoBehaviour {

	public float RespawnTime;

	private float timer;

	void Update(){
		bool enabled = GetComponentInChildren<MeshRenderer>().enabled;

		if(!enabled){
			timer += Time.deltaTime;

			if(timer >= RespawnTime){				
				MeshRenderer[] r = GetComponentsInChildren<MeshRenderer>();
				foreach(MeshRenderer rr in r){
					rr.enabled = true;
				}

				GetComponent<BoxCollider>().enabled = true;

				timer = 0f;
			}
		}
	}
}
