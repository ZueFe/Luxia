using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour
{

		public Font nightmareFont;
		public Texture background;
		public GUISkin skin;
		public float musicVolume;
		public float sfxVolume;
		public bool musciOn;
		public bool optionsOn = false;

		void OnGUI ()
		{
				if (optionsOn) {
						Screen.showCursor = true;
						GUIStyle fontStyle = new GUIStyle ();
						fontStyle.font = nightmareFont;
						fontStyle.fontSize = 50;
						fontStyle.fontStyle = FontStyle.Bold;
						fontStyle.alignment = TextAnchor.MiddleCenter;
						fontStyle.normal.textColor = Color.white;
			
						int screenWidth = Screen.width;
						int screenHeight = Screen.height;

						
						for (int i = 0; i<screenWidth; i=i+background.width) {
								for (int j = 0; j<screenHeight; j=j+background.height) {
										GUI.DrawTexture (new Rect (i, j, background.width, background.height), background, ScaleMode.StretchToFill);
								}
						}

						

						GUI.skin = skin;
						GUI.Label (new Rect (screenWidth / 2 - 200, 10, 400, 100), "Options", fontStyle);

						if (screenWidth > 1200) {
								fontStyle.fontSize = 30;
						} else {
								fontStyle.fontSize = screenWidth / 40;
						}

						fontStyle.alignment = TextAnchor.MiddleLeft;

						musciOn = GUI.Toggle (new Rect (screenWidth / 4 + screenWidth / 8, 100, screenWidth / 20, screenWidth / 20), musciOn, "");
				
						GUI.Label (new Rect (screenWidth / 4, 105, 100, screenWidth / 20), "Sounds:", fontStyle);


						GUI.Label (new Rect (screenWidth / 4, 105 + screenWidth / 20, 100, screenWidth / 20), "Music volume:", fontStyle);
						musicVolume = GUI.HorizontalSlider (new Rect (screenWidth / 4 + screenWidth / 8, 105 + screenWidth / 20, screenWidth / 3, screenWidth / 18), musicVolume, -15, 115);
						if (musicVolume < 0) {
								musicVolume = 0;
						}
						if (musicVolume > 100) {
								musicVolume = 100;
						}



						GUI.Label (new Rect (screenWidth / 4, 105 + screenWidth / 10, 100, screenWidth / 20), "SFX volume:", fontStyle);
						sfxVolume = GUI.HorizontalSlider (new Rect (screenWidth / 4 + screenWidth / 8, 110 + screenWidth / 10, screenWidth / 3, screenWidth / 18), sfxVolume, -15, 115);
						if (sfxVolume < 0) {
								sfxVolume = 0;
						}
						if (sfxVolume > 100) {
								sfxVolume = 100;
						}

						GameObject.FindGameObjectWithTag ("Config").GetComponent<Game_Configuration> ().MusicVolume = musicVolume / 100;
						GameObject.FindGameObjectWithTag ("Config").GetComponent<Game_Configuration> ().SFXVolume = sfxVolume / 100;
						GameObject.FindGameObjectWithTag ("Config").GetComponent<Game_Configuration> ().MusicOn = musciOn;
				
						if (GUI.Button (new Rect (screenWidth / 8, screenHeight - screenHeight / 7, screenWidth / 4, screenHeight / 7), "Cancel")) {
								GameObject.FindGameObjectWithTag ("Config").GetComponent<Game_Configuration> ().LoadMusicPrefs ();
								optionsOn = false;
																
						}
						if (GUI.Button (new Rect (screenWidth / 2 - screenWidth / 8, screenHeight - screenHeight / 7, screenWidth / 4, screenHeight / 7), "Reset settings")) {
								musicVolume = 100f;
								sfxVolume = 100f;
								musciOn = true;
						}
						if (GUI.Button (new Rect (screenWidth - (screenWidth / 8) - screenWidth / 4, screenHeight - screenHeight / 7, screenWidth / 4, screenHeight / 7), "Done!")) {
								doneAction ();
								
						}

				}

		}

		private void doneAction ()
		{
				GameObject.FindGameObjectWithTag ("Config").GetComponent<Game_Configuration> ().MusicVolume = musicVolume / 100;
				GameObject.FindGameObjectWithTag ("Config").GetComponent<Game_Configuration> ().SFXVolume = sfxVolume / 100;
				if (musciOn) {
						PlayerPrefs.SetInt ("MusicOn", 1);
						GameObject.FindGameObjectWithTag ("Config").GetComponent<Game_Configuration> ().MusicOn = true;
				} else {
						PlayerPrefs.SetInt ("MusicOn", 0);
						GameObject.FindGameObjectWithTag ("Config").GetComponent<Game_Configuration> ().MusicOn = false;
				}
				PlayerPrefs.SetFloat ("MusicVolume", musicVolume / 100);
				PlayerPrefs.SetFloat ("SFXVolume", sfxVolume / 100);
				PlayerPrefs.Save ();
		
		
				optionsOn = false;
		}

		void Update ()
		{
				if (Input.GetButtonDown (Global_Variables.GAME_MENU)) {
						GameObject.FindGameObjectWithTag ("Config").GetComponent<Game_Configuration> ().LoadMusicPrefs ();
						optionsOn = false;
				}
				if (Input.GetButtonDown (Global_Variables.SUBMIT)) {
						doneAction ();
				}

		}
	
}
	