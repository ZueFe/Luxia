using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {

	public Font nightmareFont;
	public GUISkin skin;
	private float musicVolume = 70.0f;
	private bool musciOn = true;

	void OnGUI ()
	{
				GUIStyle fontStyle = new GUIStyle ();
				fontStyle.font = nightmareFont;
				fontStyle.fontSize = 50;
				fontStyle.fontStyle = FontStyle.Bold;
				fontStyle.alignment = TextAnchor.MiddleCenter;
				fontStyle.normal.textColor = Color.white;
			
				int screenWidth = Screen.width;
				int screenHeight = Screen.height;

		GUI.skin = skin;
		GUI.Label (new Rect (screenWidth / 2 - 200, 10, 400,100), "Options", fontStyle);

		fontStyle.fontSize = 30;
		fontStyle.alignment = TextAnchor.MiddleLeft;

		string dots = "...............................................................................................................................";
		GUI.BeginGroup (new Rect (40, 105 , screenWidth /3,screenHeight));
		GUI.Label (new Rect (40,0 , screenWidth /3,screenWidth / 20), "Up "+dots, fontStyle);
		GUI.Label (new Rect (40,  screenWidth / 20 , screenWidth /3,screenWidth / 20), "Down "+dots, fontStyle);
		GUI.Label (new Rect (40, 2*screenWidth / 20 , screenWidth /3,screenWidth / 20), "Left "+dots, fontStyle);
		GUI.Label (new Rect (40, 3*screenWidth / 20 , screenWidth /3,screenWidth / 20), "Right "+dots, fontStyle);
		GUI.Label (new Rect (40, 4*screenWidth / 20 , screenWidth /3,screenWidth / 20), "Action "+dots, fontStyle);
		GUI.Label (new Rect (40, 5*screenWidth / 20 , screenWidth /3,screenWidth / 20), "Stop followers "+dots, fontStyle);
		GUI.EndGroup ();


		musciOn = GUI.Toggle (new Rect (screenWidth /2+screenWidth /7, 100 , screenWidth / 20, screenWidth / 20), musciOn, "");
		GUI.Label (new Rect (screenWidth /2+20, 105 , 100,screenWidth / 20), "Sound effects:", fontStyle);


		GUI.Label (new Rect (screenWidth /2+20, 105 + screenWidth / 20, 100,screenWidth / 20), "Music volume:", fontStyle);
		musicVolume = GUI.HorizontalSlider(new Rect (screenWidth /2+screenWidth / 7, 90+ screenWidth / 20, screenWidth / 3,screenWidth /13),musicVolume,-15,115);
		if (musicVolume < 0) {
			musicVolume=0;
				}
		if (musicVolume > 100) {
			musicVolume=100;
		}


		if (GUI.Button (new Rect (screenWidth/8, screenHeight - screenHeight/ 7, screenWidth / 4, screenHeight / 7), "Cancel")) {
			Application.LoadLevel("mainMenu");
		}
		if (GUI.Button (new Rect (screenWidth /2 -screenWidth /8 , screenHeight - screenHeight/ 7, screenWidth / 4, screenHeight / 7), "Reset settings")) {
			musicVolume=70;
			musciOn = true;
		}
		if (GUI.Button (new Rect (screenWidth-(screenWidth/8)- screenWidth / 4, screenHeight - screenHeight/ 7, screenWidth / 4, screenHeight / 7), "Done!")) {
			Application.LoadLevel("mainMenu");
		}



	}

}
