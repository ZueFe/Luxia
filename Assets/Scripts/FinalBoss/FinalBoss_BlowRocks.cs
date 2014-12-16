using UnityEngine;
using System.Collections;

public class FinalBoss_BlowRocks : MonoBehaviour {

	public GameObject Explosion;
	public GameObject Dynamite;
	public float ExplosionTime;
	
	[HideInInspector]
	public bool RocksBlown;

	private Rigidbody[] rocks;
	private bool explosionCountdown;
	private float timer;
	private float originalVolume;

	void Start(){
		rocks = GetComponentsInChildren<Rigidbody>();
		RocksBlown = false;
	}

	void Update(){
		if(explosionCountdown && !Global_Variables.Instance.FreezeTime){
			timer += Time.deltaTime;

			if(timer >= ExplosionTime){
				ExplodeRocks();
				TurnOfCrystal();
				explosionCountdown = false;
				RocksBlown = true;
				timer = 0f;
			}
		}
	}

	void OnTriggerStay(Collider col){
		if(col.tag == Global_Variables.PLAYER_TAG && Input.GetButtonDown(Global_Variables.BYPASS_OBSTICLE)){
			if(col.gameObject.GetComponent<Player_Inventory>().HasDynamite){

				col.gameObject.GetComponent<Player_Inventory>().UseDynamite();

				gameObject.GetComponentInChildren<Dynamite_Blinking>().blinking = false;

				Dynamite.SetActive(true);
				explosionCountdown = true;
			}else{

				//DONT HAVE DYNAMITES
			}
		}
	}

	private void ExplodeRocks(){
		Dynamite.SetActive(false);
		Instantiate(Explosion,Dynamite.transform.position, Quaternion.identity);
		GetComponent<BoxCollider>().enabled = false;

		GameObject config = GameObject.FindGameObjectWithTag(Global_Variables.CONFIG_TAG);
		AudioSource a = GetComponent<AudioSource>();

		if(config != null){
			Game_Configuration con = config.GetComponent<Game_Configuration>();

			if(con.MusicOn){
				a.volume = originalVolume * con.SFXVolume;
			}
		}

		a.Play();

		foreach(Rigidbody r in rocks){
			r.useGravity = true;
			r.isKinematic = false;
		}
	}

	private void TurnOfCrystal(){
		GameObject crystal = transform.parent.GetComponentInChildren<FinalBoss_CrystalDynamiteConnection>().gameObject;
		FinalBoss_GrowCrystalLight[] lights = transform.parent.GetComponentsInChildren<FinalBoss_GrowCrystalLight>();

		foreach(FinalBoss_GrowCrystalLight l in lights){
			l.activated = false;
		}
	
		Dwarf_Movement dwarf = GameObject.FindGameObjectWithTag(Global_Variables.FINAL_BOSS_TAG).GetComponent<Dwarf_Movement>();

		dwarf.RemoveTarget(crystal);
		dwarf.RemoveCurrentTarget(crystal);
	}
}
