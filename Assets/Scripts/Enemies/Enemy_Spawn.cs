using UnityEngine;
using System.Collections;

public class Enemy_Spawn : MonoBehaviour {

	public Transform[] SpawningPositions;
	public GameObject Enemy;


	private bool activated = false;

	// Use this for initialization
	void OnTriggerEnter(Collider col) {

		if(!activated && col.tag == Global_Variables.PLAYER_TAG){
			int pickSpawn = Random.Range(0, SpawningPositions.Length);
			Instantiate(Enemy, SpawningPositions[pickSpawn].transform.position, Quaternion.identity);
			activated = true;
		}
	}
}
