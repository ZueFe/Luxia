using UnityEngine;
using System.Collections;

public class FinalBoss_BlowBoss : MonoBehaviour {

	public GameObject Explosion;
	public float ExplosionTime;

	[HideInInspector]
	public bool dynamiteSet;

	private GameObject Exit;
		
	private float timer;


	void Start(){
		Exit = GameObject.FindGameObjectWithTag(Global_Variables.EXIT_TAG);
	}

	void Update(){
		if(dynamiteSet){
			timer += Time.deltaTime;

			if(timer >= ExplosionTime){
				Instantiate(Explosion,GameObject.FindGameObjectWithTag(Global_Variables.FINAL_BOSS_TAG).transform.position, Quaternion.identity);

				GetComponent<AudioSource>().Play();

				GameObject.FindGameObjectWithTag(Global_Variables.FINAL_BOSS_TAG).SetActive(false);
				ExplodeExit();

				Global_Variables.Instance.FollowersStopped = false;

				GameObject.FindGameObjectWithTag("GUI").GetComponent<gui>().bossActivated=false;
				GameObject.FindGameObjectWithTag("GUI").GetComponent<gui>().bossAttacking = false;
				GameObject.FindGameObjectWithTag("GUI").GetComponent<gui>().bossStunt = false;

				dynamiteSet = false;

				//Destroy(transform.root.gameObject);


			}
		}
	}


	private void ExplodeExit(){
		Rigidbody[] exitRocks = Exit.GetComponentsInChildren<Rigidbody>();
		BoxCollider[] exitCol = Exit.GetComponents<BoxCollider>();

		foreach(Rigidbody r in exitRocks){
			r.useGravity = true;
			r.isKinematic = false;
		
			r.AddForce(Vector3.back);
		}

		foreach(BoxCollider b in exitCol){
			b.enabled = !b.enabled;
		}

		Exit.layer = 0;
	}
}
