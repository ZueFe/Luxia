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
		public Texture HealthBarFillRed;
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

				GUI.DrawTexture (new Rect (screenWidth / 2 - messageBoardWidth / 2, -35, messageBoardWidth, messageBoardWidth / 5), messageBoard, ScaleMode.StretchToFill);

				GUIStyle fontStyle = new GUIStyle ();
				fontStyle.font = nightmareFont;
				fontStyle.fontSize = 20;
				fontStyle.alignment = TextAnchor.UpperCenter;
				GUI.Label (new Rect (screenWidth / 2 - messageBoardWidth / 2, 3, messageBoardWidth, messageBoardWidth / 5), "Oh no! Something happend!", fontStyle);
			

				int screenHeight = Screen.height;
				int panelHeight = screenWidth /12;	
				GUI.DrawTexture (new Rect (0, screenHeight - panelHeight , screenWidth, panelHeight), panel, ScaleMode.StretchToFill);


				GUI.DrawTexture (new Rect (30, screenHeight - 105, 300, 120), HealthBarBackground, ScaleMode.StretchToFill);


				float life = GameObject.FindWithTag (Global_Variables.PLAYER_TAG).GetComponent<Player_Stats> ().GetEnergy () / 100f - 0.05f;

				GUI.BeginGroup (new Rect (30, screenHeight - 105, 300 * life, 120));
				//GUI.DrawTexture (new Rect (30, screenHeight - 120,300, 120), HealthBarFillBlue, ScaleMode.StretchToFill);
				GUI.DrawTexture (new Rect (0, 0, 300, 120), HealthBarFillBlue, ScaleMode.StretchToFill);
				GUI.EndGroup ();


				GUI.DrawTexture (new Rect (30, screenHeight - 105, 300, 120), HealthBarForeground, ScaleMode.StretchToFill);

				if (GameObject.FindWithTag (Global_Variables.PLAYER_TAG).GetComponent<Player_Inventory> ().HasKey) {
						GUI.DrawTexture (new Rect (350, screenHeight - 85, 70, 70), key, ScaleMode.StretchToFill);
				}

				GUI.DrawTexture (new Rect (screenWidth - 330, screenHeight - 105, 300, 120), HealthBarBackground, ScaleMode.StretchToFill);

				float pilgrimLife = Camera.main.GetComponent<Game_FollowerDeath> ().GetCurrentDeathTime () - 0.05f;

				GUI.BeginGroup (new Rect (screenWidth - 330, screenHeight - 105, 300 * pilgrimLife, 120));
				if (pilgrimLife < (1 - Camera.main.GetComponent<Game_FollowerDeath> ().MaxRandomParam)) {
						GUI.DrawTexture (new Rect (0, 0, 300, 120), HealthBarFillRed, ScaleMode.StretchToFill);
				} else {
						GUI.DrawTexture (new Rect (0, 0, 300, 120), HealthBarFillPurple, ScaleMode.StretchToFill);
				}
				GUI.EndGroup ();
				GUI.DrawTexture (new Rect (screenWidth - 330, screenHeight - 105, 300, 120), HealthBarForeground, ScaleMode.StretchToFill);


				for (int i= 0; i<Camera.main.GetComponent<Game_FollowerDeath>().NumberOfLivingFollowers(); i++) {
						GUI.DrawTexture (new Rect (screenWidth - 410 - (i * 80), screenHeight - 85, 70, 70), head, ScaleMode.StretchToFill);
		
				}
				
		fontStyle.fontStyle = FontStyle.Bold;
		GUI.Label (new Rect (140, screenHeight -27, 70, 30), "Health", fontStyle);
		GUI.Label (new Rect (screenWidth-210, screenHeight -27, 70, 30), "Pilgrim's life", fontStyle);


		}


	
}
