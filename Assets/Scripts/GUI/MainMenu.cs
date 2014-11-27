﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture button;
	public Font nightmareFont;
	public GUISkin skin;

	void OnGUI ()
	{
		GUIStyle fontStyle = new GUIStyle ();
		fontStyle.font = nightmareFont;
		fontStyle.fontSize = 30;
		fontStyle.fontStyle = FontStyle.Bold;
		fontStyle.alignment = TextAnchor.MiddleCenter;
		
		int screenWidth = Screen.width;
		int screenHeight = Screen.height;

		GUI.skin = skin;
		if (GUI.Button (new Rect (screenWidth - (3 * screenWidth / 7), 0 + screenHeight / 10, screenWidth / 4, screenHeight / 7), "New Game")) {
			Application.LoadLevel("base");
		}
		GUI.Button (new Rect (screenWidth - (3 * screenWidth / 7), 0 + screenHeight / 10 +screenHeight / 7-10 , screenWidth / 4, screenHeight / 7), "How to play");
		if (GUI.Button (new Rect (screenWidth - (3 * screenWidth / 7), 0 + screenHeight / 10 + 2 * (screenHeight / 7 - 10), screenWidth / 4, screenHeight / 7), "Options")) {
			Application.LoadLevel("options");
		}
		GUI.Button (new Rect (screenWidth - (3 * screenWidth / 7), 0 + screenHeight / 10 +3*(screenHeight / 7-10), screenWidth / 4, screenHeight / 7), "Credits");
		if (GUI.Button (new Rect (screenWidth - (3 * screenWidth / 7), 0 + screenHeight / 10 + 4 *(screenHeight / 7-10), screenWidth / 4, screenHeight / 7), "Quit")) {
		Application.Quit(); 		
		}

		
		
	}
}