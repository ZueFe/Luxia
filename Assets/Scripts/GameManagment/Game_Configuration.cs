using UnityEngine;
using System.Collections;

public class Game_Configuration : MonoBehaviour {

	public float MusicVolume;
	public float SFXVolume;
	public bool MusicOn;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("MusicOn")){
			MusicOn = PlayerPrefs.GetInt("MusicOn") > 0;
		}else{
			MusicOn = true;
		}

		if(PlayerPrefs.HasKey("MusicVolume")){
			MusicVolume = PlayerPrefs.GetFloat("MusicVolume");
		}else{
			MusicVolume = 1f;
		}

		if(PlayerPrefs.HasKey("SFXVolume")){
			SFXVolume = PlayerPrefs.GetFloat("SFXVolume");
		}else{
			SFXVolume = 1f;
		}

		GameObject.DontDestroyOnLoad(this.gameObject);

		//change in case you wanna add animations before starting main menu
		//comment this line in case you are debugging
		Application.LoadLevel("mainMenu");
	}
}
