using UnityEngine;
using System.Collections;

public class Global_Variables : MonoBehaviour {

	public static Global_Variables Instance;

	public bool FolloweresFollowing;
	public bool FollowersStopped;
	public bool FreezeTime;
	public bool FollowersCharmed;
	public bool PlayerInSecondLevel = false;

	public const string PLAYER_TAG = "Player";
	public const string ENEMY_TAG = "Enemy";
	public const string FINAL_BOSS_TAG = "FinalBoss";
	public const string CRYSTAL_TAG = "Crystal";
	public const string EXIT_TAG = "Exit";
	public const int COLLISION_LAYER = 8;
	public const string TOOGLE_FOLLOW = "Toogle Follow";
	public const string BYPASS_OBSTICLE = "Use/Attack";
	public const string MAP = "Map";
	public const string GAME_MENU = "Game menu";
	public const string FOLLOWER_TAG = "Follower";
	public const string LIGHT_OBST_TAG = "LightObstacle";
	public const string CONFIG_TAG = "Config";

	public const string BLINKING_SHADER = "Transparent/Diffuse";
	public const string ORIGINAL_SHADER = "Diffuse";

	public const float CAMERA_SMOOTH_TIME = 1f;
	public const float CAMERA_FOLLOWER_DEATH_SMOOTH_TIME = 0.2f;
	public const float MOVE_TO_ELEVATOR_SMOOTHING = 4f;

	public const float PLAYER_INTENSITY_INCREASE = 2f;

	void Start(){
		Instance = this;
		FolloweresFollowing = true;
	}
}
