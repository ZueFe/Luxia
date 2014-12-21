using UnityEngine;
using System.Collections;

public class HowToPlay : MonoBehaviour {
	public Font nightmareFont;
	public GUISkin skin;
	public GameObject[] objects;
	private int index;
	private string[] obsticles = new string[]{"Bridge","Gate","Water","Potato monster"};
	private string[] obsticle_desc = new string[]{
		"You will come accros numerous bridges in this game. To overcome them, \n you can use your energy or find a lever in the maze.",
		"When you come accros closed gate, you need to search for a key. \n Alternatively, you can use your energy to open it.",
		"To get your pilgrims over the water you need to find a group of light wisps, \n that will form a boat from light.",
		"Potato monster will hyntotize you pilgrims, so they will no longer follow you. \nYou need to kill him with your energy."
	};


	void OnGUI ()
	{		
		GUIStyle fontStyle = new GUIStyle ();
		fontStyle.font = nightmareFont;
		fontStyle.alignment = TextAnchor.MiddleCenter;
		fontStyle.normal.textColor = Color.white;
		fontStyle.fontStyle = FontStyle.Bold;
		fontStyle.fontSize = 35;
		GUI.skin = skin;
		int screenWidth = Screen.width;
		int screenHeight = Screen.height;

		GUI.Label (new Rect (screenWidth / 2 - 40, 30, 80, 40), obsticles [index]+" ("+(index+1f)+"/"+objects.Length+")", fontStyle);
		fontStyle.fontSize = 25;
		GUI.Label (new Rect (screenWidth / 2 - screenWidth/4, screenHeight - screenHeight / 4, screenWidth / 2, 100), obsticle_desc [index], fontStyle);


		if (GUI.Button (new Rect (40, screenHeight/2 - screenHeight /16, screenWidth / 7, screenHeight / 8), "Previous")) {
			index--;
			if(index<0){
				index=objects.Length-1;
			}
			
		}

		if (GUI.Button (new Rect (screenWidth-screenWidth / 7-40, screenHeight/2 - screenHeight /16, screenWidth / 7, screenHeight / 8), "Next")) {
			index++;
			if(index==objects.Length){
				index=0;
			}

		}
		displayIndex (index);


		if (GUI.Button (new Rect (20, screenHeight - screenHeight / 8, screenWidth / 5, screenHeight / 8), "Back")) {
			Application.LoadLevel ("mainMenu");
			
		}
	}

	private void setVisibility(GameObject obj, bool visible){
		Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
		foreach (Renderer r in renderers)
		{
			r.enabled = visible;
		}

	}
	private void displayIndex(int index){
		for (int i =0; i< objects.Length;i++){
			setVisibility(objects[i],i==index);
		}
	}
}
