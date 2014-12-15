using UnityEngine;
using System.Collections;

public class FinalBoss_RespawnRocks : MonoBehaviour {

	public GameObject RockFormation;
	public float RespawnTime;

	private Rigidbody[] rocks;
	private bool startRespawning;
	private float timer;

	// Use this for initialization
	void Start () {
		rocks = GetComponentsInChildren<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(startRespawning){
			timer += Time.deltaTime;

			if(timer >= RespawnTime){
				Restart();
				startRespawning = false;
				timer = 0;
			}
		}else{
			startRespawning = CheckForRespawn();

			if(startRespawning){
				DeleteOldRocks();
			}
		}
	}

	private void Restart(){
		GameObject respawn = (GameObject)Instantiate(RockFormation, gameObject.transform.position, Quaternion.identity);
		respawn.transform.parent = this.gameObject.transform;
		rocks = GetComponentsInChildren<Rigidbody>();
	}

	private bool CheckForRespawn(){
		bool allDespawned = true;
	
		foreach(Rigidbody r in rocks){
			if(r.gameObject.activeSelf){
				allDespawned = false;
				break;
			}
		}

		return allDespawned;
	}

	private void DeleteOldRocks(){
		foreach(Transform t in GetComponentsInChildren<Transform>()){
			if(t.gameObject != gameObject){
				Destroy(t.gameObject);
			}
		}
	}
}
