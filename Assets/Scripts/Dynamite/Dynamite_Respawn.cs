using UnityEngine;
using System.Collections;

public class Dynamite_Respawn : MonoBehaviour {

	public float MaxRespawnTime;
	public float MinRespawnTime;

	private float timer;
	private float respawnTime;
	private bool timeChanged;

	void Start(){
		timeChanged = true;
		respawnTime = Random.Range(MinRespawnTime, MaxRespawnTime);
	}

	void Update(){
		if(!Global_Variables.Instance.FreezeTime){
			bool enabled = GetComponentInChildren<MeshRenderer>().enabled;

			if(!enabled){
				timer += Time.deltaTime;

				if(timer >= respawnTime){				
					MeshRenderer[] r = GetComponentsInChildren<MeshRenderer>();
					foreach(MeshRenderer rr in r){
						rr.enabled = true;
					}

					GetComponent<BoxCollider>().enabled = true;

					timer = 0f;
					timeChanged = false;
				}
			}else if(!timeChanged){
				timeChanged = true;
				respawnTime = Random.Range(MinRespawnTime, MaxRespawnTime);
			}
		}
	}
}
