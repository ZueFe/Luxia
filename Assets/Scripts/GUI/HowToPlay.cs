using UnityEngine;
using System.Collections;

public class HowToPlay : MonoBehaviour {
	public Font nightmareFont;
	public GUISkin skin;
	public GameObject[] objects;
	private int index;
		private string[] obsticles = new string[]{"How to play","Luxia","Followers","Map","Bridge","Gate","Water","Potato monster","Bees","Evil wisp","The Dwarf"};
	private string[] obsticle_desc = new string[]{
		"",
		"This is Luxia, the character you control. She can fly freely through the maze, however her energy is constanty decreasing. To refill the energy, find glowing crystal and press action button (E by default).",
		"The pilgrims you need to save. They follow your light, but you can tell them to stop/start following you whenever you like (F key by default). They can only walk on solid ground. Be carful not to leave them in the dark for too long. The darkness will swallow them!",
		"Should you become lost, you can look at the map of the maze, where your position will be marked (M key by default).",
		"You will come accros numerous bridges in this game. To overcome them, you can use your energy or find a lever in the maze.",
		"When you come accros closed gate, you need to search for a key. Alternatively, you can use your energy to open it.",
		"To get your pilgrims over the water you need to find a group of light wisps, that will form a boat from light.",
		"Potato monster will hyntotize you pilgrims, so they will no longer follow you. You need to kill him with your energy.",
		"These dark bees feer the light. Traveling in swarm or alone, they grow bigger in the darkness, but if you keep them in the light long enough, they will disappear. Just watch out and don't touch them directly.",
		"This evil wisp sucks your light and the only thing you can do about it is try to avoid her crazy moves until she disappears. Good luck!",
		"The man to be feared. You need to occupy him by lighting up a crystal, and while he is mining it, set up a dynamite over his head. Watch out, when he is not mining, he is attacking your pilgrims."
	};
	private int screenWidth;
	private int screenHeight;

	void OnGUI ()
	{		
		GUIStyle fontStyle = new GUIStyle ();
		fontStyle.font = nightmareFont;
		fontStyle.alignment = TextAnchor.MiddleCenter;
		fontStyle.normal.textColor = Color.white;
		fontStyle.fontStyle = FontStyle.Bold;
		fontStyle.fontSize = 35;
		fontStyle.wordWrap = true;
		GUI.skin = skin;
		screenWidth = Screen.width;
		screenHeight = Screen.height;

		GUI.Label (new Rect (screenWidth / 2 - screenWidth / 4, 30, screenWidth/2, 40), obsticles [index]+" ("+(index+1f)+"/"+objects.Length+")", fontStyle);
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
		Light[] lights = obj.GetComponentsInChildren<Light>();
		foreach (Renderer r in renderers)
		{
			r.enabled = visible;
		}
		foreach (Light l in lights)
		{
			l.enabled = visible;
		}

	}
	private void displayIndex(int index){
		for (int i =0; i< objects.Length;i++){
			setVisibility(objects[i],i==index);
		}
		if (index ==0) {
			GUIStyle fontStyle = new GUIStyle ();
			fontStyle.font = nightmareFont;
			fontStyle.alignment = TextAnchor.MiddleCenter;
			fontStyle.normal.textColor = Color.white;
			fontStyle.fontStyle = FontStyle.Bold;
			fontStyle.fontSize = 25;
			fontStyle.wordWrap = true;
			string entry = "In this game, you become a light wisp called Luxia and your job is to save pilgrims lost in an underground maze. \n  \n"+ 
				"This guide should help you with your mission. You will find here entries on: \n  \n genral game principles (p. 2-4) \n obsticles (p. 5-7) \n enemies (p. 8-10) \n final boss (p. 11)";

			GUI.Label (new Rect (screenWidth / 2 - screenWidth/4,  screenHeight / 3, screenWidth / 2, screenHeight /2), entry, fontStyle);

		}
	}
}
