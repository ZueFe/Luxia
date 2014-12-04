using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy_AllEnemiesDeadFinal : MonoBehaviour {

	public GameObject FinalSpawningScript;
	public bool AllDead;

	private bool stillAlive;
	private List<GameObject> enemies;

	void Start(){
		enemies = new List<GameObject>();
	}

	// Update is called once per frame
	void Update () {
		if (enemies.Count > 0) {
			for (int i = enemies.Count - 1; i < 0; i--) {
				if (enemies [i] == null) {
					enemies.Remove (enemies [i]);
				}
			}
		}

		//check if all are spawned
		AllDead = (enemies.Count <= 0);
	}

	void OnTriggerStay(Collider col){
		if (col.tag == Global_Variables.ENEMY_TAG) {
			if(!enemies.Contains(col.gameObject)){
				enemies.Add(col.gameObject);
			}
		}
	}
}
