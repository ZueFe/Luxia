using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	public TextAsset credits;
	public Font nightmareFont;
	public GUISkin skin;
	private float y;
	private float timer = 0;

	void Start(){
		y = Screen.height;
	}


	void OnGUI ()
	{

		string text = credits.text;
		GUIStyle fontStyle = new GUIStyle ();
		fontStyle.font = nightmareFont;
		fontStyle.alignment = TextAnchor.MiddleCenter;
		fontStyle.normal.textColor = Color.white;
		fontStyle.richText = true;

		int screenWidth = Screen.width;
		int screenHeight = Screen.height;

		GUI.Label (new Rect (screenWidth / 2 - 200, screenHeight-timer, 400, 1400), text, fontStyle);
	//	y-=Time.deltaTime/5;
		if (screenHeight-timer < -1400) {
					//	y = screenHeight;		
			timer = 0;
				}
		print (timer);
		GUI.skin = skin;
		if (GUI.Button (new Rect (20, screenHeight - screenHeight / 8, screenWidth / 5, screenHeight / 8), "Back")) {
			Application.LoadLevel ("mainMenu");
			
		}
	}

	void Update(){
		timer += 70*Time.deltaTime;
	}

}
