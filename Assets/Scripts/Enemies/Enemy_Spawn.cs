using UnityEngine;
using System.Collections;

public class Enemy_Spawn : MonoBehaviour {

	public Transform[] SpawningPositions;
	public GameObject[] Enemies;


	private bool activated = false;

	// Use this for initialization
	void OnTriggerEnter(Collider col) {

		if(!activated && col.tag == Global_Variables.PLAYER_TAG){
			int randPick = Random.Range(0, Enemies.Length);

			int pickSpawn = Random.Range(0, SpawningPositions.Length);
			Instantiate(Enemies[randPick], SpawningPositions[pickSpawn].transform.position, Quaternion.identity);
			activated = true;
		}
	}
}
