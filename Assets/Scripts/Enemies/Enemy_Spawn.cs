using UnityEngine;
using System.Collections;

public class Enemy_Spawn : MonoBehaviour {

	public Transform[] SpawningPositions;
	public GameObject[] Enemies;
	public float Delay = 0f;
	[HideInInspector]
	public bool Spawned;

	private bool activated = false;
	private float timer;

	void Update(){
		if (activated && !Spawned) {
			timer += Time.deltaTime;

			if(timer >= Delay){
				int randPick = Random.Range(0, Enemies.Length);
				
				int pickSpawn = Random.Range(0, SpawningPositions.Length);
				Instantiate(Enemies[randPick], SpawningPositions[pickSpawn].transform.position, Quaternion.identity);
				Spawned = true;
			}
		}
	}

	// Use this for initialization
	void OnTriggerEnter(Collider col) {
		if(!activated && col.tag == Global_Variables.PLAYER_TAG){

			activated = true;
		}
	}
}
