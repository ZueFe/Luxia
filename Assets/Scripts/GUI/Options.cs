using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {

	public Font nightmareFont;
	public GUISkin skin;

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


		GUI.Label (new Rect (screenWidth / 2 - 200, 10, 200,100), "Options", fontStyle);

	}

}
