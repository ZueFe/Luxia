using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Music_SmoothStart : MonoBehaviour {

	public float SmoothingTime;
	
	private float t;
	private float originalVolume;

	void Start(){
		originalVolume = GetComponent<AudioSource>().volume;
		GetComponent<AudioSource>().volume = 0f;
		GetComponent<AudioSource>().Play();
	}

	void Update(){
		GetComponent<AudioSource>().volume = Mathf.SmoothDamp(GetComponent<AudioSource>().volume, originalVolume, ref t, SmoothingTime);
	}


}
