using UnityEngine;
using System.Collections;

public class InGameMenu : MonoBehaviour
{

		public GUISkin skin;
		private bool menuOn;

		void OnGUI ()
		{
				if (!GameObject.FindGameObjectWithTag ("GUI").GetComponent<gui> ().deathScreenOn && !GameObject.FindGameObjectWithTag ("GUI").GetComponent<gui> ().winScreenOn) {
						Cursor.visible = menuOn;	
				}
				if (menuOn && !GetComponent<Options> ().optionsOn) {
						int screenWidth = Screen.width;
						int screenHeight = Screen.height;
		
						GUI.skin = skin;
						if (GUI.Button (new Rect ((screenWidth - (screenWidth / 4)) / 2, screenHeight / 10 + screenHeight / 7 - 10, screenWidth / 4, screenHeight / 7), "Resume Game")) {
								menuOn = false;
								Global_Variables.Instance.FreezeTime = menuOn;
															
						}

						if (GUI.Button (new Rect ((screenWidth - (screenWidth / 4)) / 2, screenHeight / 10 + 2 * (screenHeight / 7 - 10), screenWidth / 4, screenHeight / 7), "Options")) {
								GetComponent<Options> ().musicVolume = GameObject.FindGameObjectWithTag ("Config").GetComponent<Game_Configuration> ().MusicVolume * 100;
								GetComponent<Options> ().sfxVolume = GameObject.FindGameObjectWithTag ("Config").GetComponent<Game_Configuration> ().SFXVolume * 100;
								GetComponent<Options> ().musciOn = GameObject.FindGameObjectWithTag ("Config").GetComponent<Game_Configuration> ().MusicOn;
								GetComponent<Options> ().optionsOn = true;
													
						}

						if (GUI.Button (new Rect ((screenWidth - (screenWidth / 4)) / 2, screenHeight / 10 + 3 * (screenHeight / 7 - 10), screenWidth / 4, screenHeight / 7), "Main menu")) {
								Application.LoadLevel ("mainMenu");
						}
				}

		}

		void Update ()
		{
				if (Input.GetButtonDown (Global_Variables.GAME_MENU) && Camera.main.GetComponent<Game_Camera> ().getTarget ().gameObject.tag == Global_Variables.PLAYER_TAG && !GetComponent<Options> ().optionsOn && !GameObject.FindGameObjectWithTag ("GUI").GetComponent<gui> ().deathScreenOn && !GameObject.FindGameObjectWithTag ("GUI").GetComponent<gui> ().winScreenOn) {
						menuOn = !menuOn;
						Global_Variables.Instance.FreezeTime = menuOn;
				}
		}
}
