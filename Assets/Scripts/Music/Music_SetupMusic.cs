using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Music_SetupMusic : MonoBehaviour {

	private float originalVolume;
	private bool playMusic;
	private float musicModif;
	private Game_Configuration con;

	// Use this for initialization
	void Start () {
		GameObject config = GameObject.FindGameObjectWithTag(Global_Variables.CONFIG_TAG);
		
		playMusic = true;
		musicModif = 1f;
		
		if(config != null){
			con = config.GetComponent<Game_Configuration>();
			playMusic = con.MusicOn;
			musicModif = con.SFXVolume;
		}
		
		originalVolume = GetComponent<AudioSource>().volume;
	}
	
	// Update is called once per frame
	void Update () {
		if(con != null){
			musicModif = con.SFXVolume;
			playMusic = con.MusicOn;
		}

		if(playMusic){
			GetComponent<AudioSource>().volume = originalVolume * musicModif;
		}else{
			GetComponent<AudioSource>().volume = 0f;
		}
	}
}
