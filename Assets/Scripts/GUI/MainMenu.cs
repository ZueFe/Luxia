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
		if (GUI.Button (new Rect (screenWidth - (3 * screenWidth / 7), 0 + screenHeight / 10, screenWidth / 4, 100), "New Game")) {
			Application.LoadLevel("base");
		}
		GUI.Button (new Rect (screenWidth - (3 * screenWidth / 7), 0 + screenHeight / 10 +90 , screenWidth / 4, 100), "How to play");
		GUI.Button (new Rect (screenWidth - (3 * screenWidth / 7), 0 + screenHeight / 10 +2*90 , screenWidth / 4, 100), "Options");
		GUI.Button (new Rect (screenWidth - (3 * screenWidth / 7), 0 + screenHeight / 10 +3*90 , screenWidth / 4, 100), "Credits");
		if (GUI.Button (new Rect (screenWidth - (3 * screenWidth / 7), 0 + screenHeight / 10 + 4 * 90, screenWidth / 4, 100), "Quit")) {
		Application.Quit(); 		
		}

		
		
	}
}