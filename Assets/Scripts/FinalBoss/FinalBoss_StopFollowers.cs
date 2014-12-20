using UnityEngine;
using System.Collections;

public class FinalBoss_StopFollowers : MonoBehaviour {

	public Transform[] SpawningPositions;
	public GameObject[] Enemies;
	
	private bool activated = false;
	
	void Update(){
		if (activated) {			
			int randPick = Random.Range(0, Enemies.Length);
				
			int pickSpawn = Random.Range(0, SpawningPositions.Length);
			Instantiate(Enemies[randPick], SpawningPositions[pickSpawn].transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}
	
	// Use this for initialization
	void OnTriggerEnter(Collider col) {
		if(!activated && col.tag == Global_Variables.FOLLOWER_TAG){
			
			activated = true;
			GameObject.FindGameObjectWithTag("GUI").GetComponent<gui>().bossActivated=true;
			Global_Variables.Instance.FollowersStopped = true;
		}
	}
}
