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
		public float timer = 30;

		private string labelText = "So far, so good!";

		void OnGUI ()
		{
				GUIStyle fontStyle = new GUIStyle ();
				fontStyle.font = nightmareFont;
				fontStyle.fontSize = 20;
				fontStyle.fontStyle = FontStyle.Bold;
				fontStyle.alignment = TextAnchor.UpperCenter;

				int screenWidth = Screen.width;
				int screenHeight = Screen.height;
				int borderGap = 20;

				//MESSAGE BOARD
				int messageBoardWidth = screenWidth / 2;
				if (messageBoardWidth < 600) {
						messageBoardWidth = 600;
				}

				GUI.DrawTexture (new Rect (screenWidth / 2 - messageBoardWidth / 2, -35, messageBoardWidth, messageBoardWidth / 5), messageBoard, ScaleMode.StretchToFill);
				GUI.Label (new Rect (screenWidth / 2 - messageBoardWidth / 2, 3, messageBoardWidth, messageBoardWidth / 5), labelText, fontStyle);
			

				//MAIN PANEL
				int panelHeight = screenWidth / 12;	
				if (panelHeight < 100)
						panelHeight = 100;
				GUI.DrawTexture (new Rect (0, screenHeight - panelHeight, screenWidth, panelHeight), panel, ScaleMode.StretchToFill);


				//HEALTHBAR
				int healthBarWidth = screenWidth / 5;
				if (healthBarWidth < 150) {
						healthBarWidth = 150;
				}
				if (healthBarWidth > 400) {
						healthBarWidth = 400;
				}

				GUI.DrawTexture (new Rect (borderGap, screenHeight - 105, healthBarWidth, 120), HealthBarBackground, ScaleMode.StretchToFill);

				float life = GameObject.FindWithTag (Global_Variables.PLAYER_TAG).GetComponent<Player_Stats> ().GetEnergy () / 100f - 0.05f;

				GUI.BeginGroup (new Rect (borderGap, screenHeight - 105, healthBarWidth * life, 120));
				//GUI.DrawTexture (new Rect (30, screenHeight - 120,300, 120), HealthBarFillBlue, ScaleMode.StretchToFill);
				GUI.DrawTexture (new Rect (0, 0, healthBarWidth, 120), HealthBarFillBlue, ScaleMode.StretchToFill);
				GUI.EndGroup ();

				GUI.DrawTexture (new Rect (borderGap, screenHeight - 105, healthBarWidth, 120), HealthBarForeground, ScaleMode.StretchToFill);

				GUI.Label (new Rect (healthBarWidth / 2 - 15, screenHeight - 27, 70, 30), "Health", fontStyle);

				//LIFEBAR			
				GUI.DrawTexture (new Rect (screenWidth - healthBarWidth - borderGap, screenHeight - 105, healthBarWidth, 120), HealthBarBackground, ScaleMode.StretchToFill);

				float pilgrimLife = Camera.main.GetComponent<Game_FollowerDeath> ().GetCurrentDeathTime () - 0.05f;

				GUI.BeginGroup (new Rect (screenWidth - healthBarWidth - borderGap, screenHeight - 105, healthBarWidth * pilgrimLife, 120));
				if (pilgrimLife < (1 - Camera.main.GetComponent<Game_FollowerDeath> ().MaxRandomParam)) {
						GUI.DrawTexture (new Rect (0, 0, healthBarWidth, 120), HealthBarFillRed, ScaleMode.StretchToFill);
				} else {
						GUI.DrawTexture (new Rect (0, 0, healthBarWidth, 120), HealthBarFillPurple, ScaleMode.StretchToFill);
				}
				GUI.EndGroup ();
				GUI.DrawTexture (new Rect (screenWidth - healthBarWidth - borderGap, screenHeight - 105, healthBarWidth, 120), HealthBarForeground, ScaleMode.StretchToFill);

				GUI.Label (new Rect (screenWidth - healthBarWidth / 2 - 35 - borderGap, screenHeight - 27, 70, 30), "Pilgrim's life", fontStyle);

				//FOLLOWERS
				int d = screenWidth / 22;
				if (d < 40)
						d = 40;
				for (int i= 0; i<Camera.main.GetComponent<Game_FollowerDeath>().NumberOfLivingFollowers(); i++) {
						GUI.DrawTexture (new Rect (screenWidth - healthBarWidth - d - borderGap + 5 - (i * (d + 5)), screenHeight - (d / 2) - 45, d, d), head, ScaleMode.StretchToFill);
		
				}
				
				//KEY	
				if (GameObject.FindWithTag (Global_Variables.PLAYER_TAG).GetComponent<Player_Inventory> ().HasKey) {
						GUI.DrawTexture (new Rect (healthBarWidth + d / 2, screenHeight - (d / 2) - 45, d, d), key, ScaleMode.StretchToFill);
				}


				//MESSAGES
				if (timer<3) {
						labelText="You don't have enough energy!";
				}
				else if (pilgrimLife < (1 - Camera.main.GetComponent<Game_FollowerDeath> ().MaxRandomParam)) {
						labelText = "Your pilgrims are in mortal peril!";	
				} else if (Camera.main.GetComponent<Game_Manager> ().followerInstances [0].GetComponent<Follow_Player> ().Follows.gameObject.tag != Global_Variables.PLAYER_TAG) {
						labelText = "Oh no! Potato monster stole your pilgrms!";
				} else {
						labelText = "So far, so good!";
				}

		}

		void Update(){
			timer += Time.deltaTime;
			if (timer > 30) {
				timer = 30;		
			}
		}


	
}
