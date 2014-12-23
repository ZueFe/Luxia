using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Obsticle_PlaySound : MonoBehaviour {

	public string SoundFileName;
	public bool IsTrigger = false;

	void Activated(){
		AudioClip ac = (AudioClip)Resources.Load("Sounds/" + SoundFileName);
		AudioSource audioS = gameObject.GetComponent<AudioSource>();


		audioS.clip = ac;
		audioS.Play();
	}

	void OnTriggerEnter(Collider col){
		if(IsTrigger && col.tag == Global_Variables.PLAYER_TAG){
			Activated();
		}
	}
}
