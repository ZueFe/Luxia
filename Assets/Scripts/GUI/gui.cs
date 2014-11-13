using UnityEngine;
using System.Collections;

public class gui : MonoBehaviour
{

		public Texture messageBoard;
		public Texture panel;
		public Texture key;
		public Texture head;
		public Texture HealthBarBackground;
		public Texture HealthBarForeground;
		public Texture HealthBarFillBlue;
		public Texture HealthBarFillPurple;
		public Font nightmareFont;


		void OnGUI ()
		{
				// Make a background box
				//			GUI.Box (new Rect (10, 10, 100, 90), "Loader Menu");
		int screenWidth = Screen.width;
		int messageBoardWidth = screenWidth / 2;
		if (messageBoardWidth < 600) {
			messageBoardWidth = 600;
		}

		GUI.DrawTexture (new Rect (screenWidth/2-messageBoardWidth/2, 0,messageBoardWidth, messageBoardWidth/5), messageBoard, ScaleMode.StretchToFill);

		GUIStyle fontStyle = new GUIStyle ();
		fontStyle.font = nightmareFont;
		fontStyle.fontSize = 20;
		fontStyle.alignment = TextAnchor.UpperCenter;
		GUI.Label(new Rect (screenWidth/2-messageBoardWidth/2,10,messageBoardWidth, messageBoardWidth/5), "Oh no! Something happend! \n Hurry up!",fontStyle);
			

		int screenHeight = Screen.height;
		int panelHeight = screenWidth / 4;	
		GUI.DrawTexture (new Rect (0, screenHeight - panelHeight/2,screenWidth, panelHeight), panel, ScaleMode.StretchToFill);


		GUI.DrawTexture (new Rect (30, screenHeight - 120,300, 120), HealthBarBackground, ScaleMode.StretchToFill);


		float life = GameObject.FindWithTag(Global_Variables.PLAYER_TAG).GetComponent<Player_Stats>().GetEnergy() / 100f;

		GUI.BeginGroup (new Rect (30, screenHeight - 120,300*life, 120));
		//GUI.DrawTexture (new Rect (30, screenHeight - 120,300, 120), HealthBarFillBlue, ScaleMode.StretchToFill);
		GUI.DrawTexture (new Rect (0, 0,300, 120), HealthBarFillBlue, ScaleMode.StretchToFill);
		GUI.EndGroup ();


		GUI.DrawTexture (new Rect (30, screenHeight - 120,300, 120), HealthBarForeground, ScaleMode.StretchToFill);

		GUI.DrawTexture (new Rect (350, screenHeight - 100,70,70), key, ScaleMode.StretchToFill);

		GUI.DrawTexture (new Rect (screenWidth-330, screenHeight - 120,300, 120), HealthBarBackground, ScaleMode.StretchToFill);
		GUI.DrawTexture (new Rect (screenWidth-330, screenHeight - 120,300, 120), HealthBarFillPurple, ScaleMode.StretchToFill);
		GUI.DrawTexture (new Rect (screenWidth-330, screenHeight - 120,300, 120), HealthBarForeground, ScaleMode.StretchToFill);

		GUI.DrawTexture (new Rect (screenWidth-410, screenHeight - 100,70,70), head, ScaleMode.StretchToFill);
		GUI.DrawTexture (new Rect (screenWidth-490, screenHeight - 100,70,70), head, ScaleMode.StretchToFill);
		GUI.DrawTexture (new Rect (screenWidth-570, screenHeight - 100,70,70), head, ScaleMode.StretchToFill);
		GUI.DrawTexture (new Rect (screenWidth-650, screenHeight - 100,70,70), head, ScaleMode.StretchToFill);

		

		}


	
}
