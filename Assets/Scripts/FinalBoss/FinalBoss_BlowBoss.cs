using UnityEngine;
using System.Collections;

public class FinalBoss_BlowBoss : MonoBehaviour {

	public GameObject Explosion;
	public float ExplosionTime;

	private GameObject Exit;
		
	private float timer;
	private bool dynamiteSet;

	void Start(){
		Exit = GameObject.FindGameObjectWithTag(Global_Variables.EXIT_TAG);
	}

	void Update(){
		if(dynamiteSet){
			timer += Time.deltaTime;

			if(timer >= ExplosionTime){
				gameObject.transform.parent.gameObject.SetActive(false);
				Instantiate(Explosion,gameObject.transform.parent.position, Quaternion.identity);

				GetComponent<AudioSource>().Play();
				ExplodeExit();

				Global_Variables.Instance.FollowersStopped = false;

				Destroy(transform.root.gameObject);
				GameObject.FindGameObjectWithTag("GUI").GetComponent<gui>().bossActivated=false;
			}
		}
	}

	void OnTriggerStay(Collider col){
		if(col.tag == Global_Variables.PLAYER_TAG && Input.GetButtonDown(Global_Variables.BYPASS_OBSTICLE)){
			if(col.GetComponent<Player_Inventory>().HasDynamite){

				GetComponent<Dynamite_Blinking>().blinking = false;
				dynamiteSet = true;
				col.GetComponent<Player_Inventory>().UseDynamite();
			}else{
				//DONT HAVE DYNAMITE
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
