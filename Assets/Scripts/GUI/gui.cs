using UnityEngine;
using System.Collections;

public class gui : MonoBehaviour
{

		public Texture messageBoard;
		public Texture panel;
		public Texture key;
		public Texture dynamite;
		public Texture head;
		public Texture background;
		public Texture HealthBarBackground;
		public Texture HealthBarForeground;
		public Texture HealthBarBossBackground;
		public Texture HealthBarBossForeground;
		public Texture HealthBarBossFill;
		public Texture HealthBarFillBlue;
		public Texture HealthBarFillPurple;
		public Texture HealthBarFillRed;
		public Texture map;
		public Texture mark;
		public Font nightmareFont;
		public float timer = 30;
		public bool areInElevator = false;
		private string labelText = "So far, so good!";
		public bool mapOn = false;
		public bool bossActivated = false;
		private Color gameEnd = new Color (1, 1, 1, 0);
		private int screenWidth;
		private int screenHeight;
		private GUIStyle fontStyle;
		public GUISkin skin;
		public bool deathScreenOn = false;

		void OnGUI ()
		{
				GUI.skin = skin;
				if (!GetComponent<Options> ().optionsOn) {
						fontStyle = new GUIStyle ();
						fontStyle.font = nightmareFont;
				
						fontStyle.fontStyle = FontStyle.Bold;
						fontStyle.alignment = TextAnchor.UpperCenter;

						screenWidth = Screen.width;
						screenHeight = Screen.height;
						int borderGap = 20;
						int inventoryItems = 0;

						//MESSAGE BOARD
						int messageBoardWidth = screenWidth / 2;
						if (messageBoardWidth < 600) {
								messageBoardWidth = 600;
						}


						if (screenWidth > 1200) {
								fontStyle.fontSize = screenWidth / 60;
						} else {
								fontStyle.fontSize = 20;
						}

						GUI.DrawTexture (new Rect (screenWidth / 2 - messageBoardWidth / 2, -35, messageBoardWidth, messageBoardWidth / 5), messageBoard, ScaleMode.StretchToFill);
						GUI.Label (new Rect (screenWidth / 2 - messageBoardWidth / 2, 3, messageBoardWidth, messageBoardWidth / 5), labelText, fontStyle);
			
						fontStyle.fontSize = 20;

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

						GUI.DrawTexture (new Rect (borderGap, screenHeight - 75 - healthBarWidth / 5, healthBarWidth, 90 + healthBarWidth / 5), HealthBarBackground, ScaleMode.StretchToFill);

						float life = GameObject.FindWithTag (Global_Variables.PLAYER_TAG).GetComponent<Player_Stats> ().GetEnergy () / 100f - 0.05f;

						GUI.BeginGroup (new Rect (borderGap, screenHeight - 75 - healthBarWidth / 5, healthBarWidth * life, 90 + healthBarWidth / 5));
						//GUI.DrawTexture (new Rect (30, screenHeight - 120,300, 120), HealthBarFillBlue, ScaleMode.StretchToFill);
						GUI.DrawTexture (new Rect (0, 0, healthBarWidth, 90 + healthBarWidth / 5), HealthBarFillBlue, ScaleMode.StretchToFill);
						GUI.EndGroup ();

						GUI.DrawTexture (new Rect (borderGap, screenHeight - 75 - healthBarWidth / 5, healthBarWidth, 90 + healthBarWidth / 5), HealthBarForeground, ScaleMode.StretchToFill);

						GUI.Label (new Rect (healthBarWidth / 2 - 15, screenHeight - 27, 70, 30), "Health", fontStyle);

						//LIFEBAR			
						GUI.DrawTexture (new Rect (screenWidth - healthBarWidth - borderGap, screenHeight - 75 - healthBarWidth / 5, healthBarWidth, 90 + healthBarWidth / 5), HealthBarBackground, ScaleMode.StretchToFill);

						float pilgrimLife = Camera.main.GetComponent<Game_FollowerDeath> ().GetCurrentDeathTime () - 0.05f;

						GUI.BeginGroup (new Rect (screenWidth - healthBarWidth - borderGap, screenHeight - 75 - healthBarWidth / 5, healthBarWidth * pilgrimLife, 90 + healthBarWidth / 5));
						if (pilgrimLife < (1 - Camera.main.GetComponent<Game_FollowerDeath> ().MaxRandomParam)) {
								GUI.DrawTexture (new Rect (0, 0, healthBarWidth, 90 + healthBarWidth / 5), HealthBarFillRed, ScaleMode.StretchToFill);
						} else {
								GUI.DrawTexture (new Rect (0, 0, healthBarWidth, 90 + healthBarWidth / 5), HealthBarFillPurple, ScaleMode.StretchToFill);
						}
						GUI.EndGroup ();
						GUI.DrawTexture (new Rect (screenWidth - healthBarWidth - borderGap, screenHeight - 75 - healthBarWidth / 5, healthBarWidth, 90 + healthBarWidth / 5), HealthBarForeground, ScaleMode.StretchToFill);

						GUI.Label (new Rect (screenWidth - healthBarWidth / 2 - 35 - borderGap, screenHeight - 27, 70, 30), "Pilgrim's life", fontStyle);


						//BOSS HEALTHBAR
						if (bossActivated) {
								GUI.DrawTexture (new Rect (screenWidth / 2 - (messageBoardWidth - messageBoardWidth / 5) / 2, messageBoardWidth / 7 - 45, (messageBoardWidth - messageBoardWidth / 5), messageBoardWidth / 7), HealthBarBossBackground, ScaleMode.StretchToFill);
			
								float bossLife = GameObject.FindWithTag (Global_Variables.FINAL_BOSS_TAG).GetComponent<FinalBoss_Stats> ().GetCurrentHealth () / GameObject.FindWithTag (Global_Variables.FINAL_BOSS_TAG).GetComponent<FinalBoss_Stats> ().MaxHealth;
			
								GUI.BeginGroup (new Rect (screenWidth / 2 - (messageBoardWidth - messageBoardWidth / 5) / 2, messageBoardWidth / 7 - 45, bossLife * (messageBoardWidth - messageBoardWidth / 5), messageBoardWidth / 7));
								GUI.DrawTexture (new Rect (0, 0, (messageBoardWidth - messageBoardWidth / 5), messageBoardWidth / 7), HealthBarBossFill, ScaleMode.StretchToFill);
		
								GUI.EndGroup ();
								GUI.DrawTexture (new Rect (screenWidth / 2 - (messageBoardWidth - messageBoardWidth / 5) / 2, messageBoardWidth / 7 - 45, (messageBoardWidth - messageBoardWidth / 5), messageBoardWidth / 7), HealthBarBossForeground, ScaleMode.StretchToFill);

						}

						//FOLLOWERS
						int d = screenWidth / 22;
						if (d < 40)
								d = 40;
						for (int i= 0; i<Camera.main.GetComponent<Game_FollowerDeath>().NumberOfLivingFollowers(); i++) {
								GUI.DrawTexture (new Rect (screenWidth - healthBarWidth - d - borderGap + 5 - (i * (d + 5)), screenHeight - 30 - healthBarWidth / 10 - d / 2, d, d), head, ScaleMode.StretchToFill);
		
						}
				
						//KEY	
						if (GameObject.FindWithTag (Global_Variables.PLAYER_TAG).GetComponent<Player_Inventory> ().HasKey) {
								inventoryItems++;
								GUI.DrawTexture (new Rect (healthBarWidth + d / 2, screenHeight - 30 - healthBarWidth / 10 - d / 2, d, d), key, ScaleMode.StretchToFill);
						}

						//Dynamite
						if (GameObject.FindWithTag (Global_Variables.PLAYER_TAG).GetComponent<Player_Inventory> ().HasDynamite) {
								GUI.DrawTexture (new Rect (healthBarWidth + d / 2 + inventoryItems * (d + 5), screenHeight - 30 - healthBarWidth / 10 - d / 2, d, d), dynamite, ScaleMode.StretchToFill);
						}
				
				
				 
						if (mapOn) {				
								float w = screenWidth;
								float h = screenWidth / (map.width / map.height);
								if (screenHeight < h) {
										h = screenHeight;
										w = screenHeight * (map.width / map.height);
								}
								float r = w / map.width;
								GUI.DrawTexture (new Rect ((screenWidth - w) / 2, (screenHeight - h) / 2, w, h), map, ScaleMode.StretchToFill);
								Vector3 pos = GameObject.FindGameObjectWithTag (Global_Variables.PLAYER_TAG).transform.position;
								float marksize = mark.width * r;
								GUI.DrawTexture (new Rect ((screenWidth - w) / 2 + r * (425 + 2.81f * pos.x) - marksize / 2, (screenHeight - h) / 2 + r * (755 - 3 * pos.y) - marksize / 2, marksize, marksize), mark, ScaleMode.StretchToFill);
						}
				


						//MESSAGES
						if (timer < 3) {
								labelText = "You don't have enough energy!";
						} else if (pilgrimLife < (1 - Camera.main.GetComponent<Game_FollowerDeath> ().MaxRandomParam)) {
								labelText = "Your pilgrims are in mortal peril!";	
						} else if (!deathScreenOn && Camera.main.GetComponent<Game_Manager> ().followerInstances [0].GetComponent<Follow_Player> ().Follows.gameObject.tag != Global_Variables.PLAYER_TAG && !areInElevator) {
								labelText = "Oh no! Potato monster stole your pilgrms!";
						} else {
								labelText = "So far, so good!";
						}
				
						if (life <= 0.08f || Camera.main.GetComponent<Game_FollowerDeath> ().NumberOfLivingFollowers () <= 0) {
								deathScreenOn = true;
								Global_Variables.Instance.FreezeTime = true;
						}
									
				}
				if (deathScreenOn) {
						drawDeathScreen ();
				}

				

		}

		void Update ()
		{
				timer += Time.deltaTime;
				if (timer > 30) {
						timer = 30;		
				}

	

	
		}

		private void drawDeathScreen ()
		{
				gameEnd.a += 0.002f;
				
				
				if (gameEnd.a > 0.8f) {
						GUI.color = new Color (1, 1, 1, 0.8f);
				} else {
						GUI.color = gameEnd;		
				}
				//GUI.DrawTextureWithTexCoords (new Rect (0, 0, screenWidth, screenHeight), background, new Rect (0, 0, screenWidth / background.width, screenHeight / background.height));
				Texture2D back = new Texture2D (1, 1);
				back.SetPixel (0, 0, new Color (0, 0.14f, 0.26f, GUI.color.a));
				back.Apply ();
				GUI.DrawTexture (new Rect (0, 0, screenWidth, screenHeight), back, ScaleMode.StretchToFill);

				GUI.color = gameEnd;	
				fontStyle.fontSize = 50;
				fontStyle.fontStyle = FontStyle.Bold;
				fontStyle.alignment = TextAnchor.MiddleCenter;
				fontStyle.normal.textColor = gameEnd;
				GUI.Label (new Rect (0, screenHeight / 2 - screenHeight / 5, screenWidth, screenHeight / 5), "You failed!", fontStyle);
		
				if (GUI.Button (new Rect (screenWidth / 2 - (screenWidth / 4) - 10, screenHeight / 2 + 5, screenWidth / 4, screenHeight / 7), "New Game")) {
						
						Application.LoadLevel ("base");
						deathScreenOn = false;
						
				}
				if (GUI.Button (new Rect (screenWidth / 2 + 10, screenHeight / 2 + 5, screenWidth / 4, screenHeight / 7), "Main menu")) {
						
						Application.LoadLevel ("mainMenu");
						deathScreenOn = false;
				}

				
				GUI.color = Color.white;
			

		}


	
}
