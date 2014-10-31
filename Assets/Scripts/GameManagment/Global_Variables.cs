using UnityEngine;
using System.Collections;

public class Global_Variables : MonoBehaviour {

	public static Global_Variables Instance;

	public bool FolloweresFollowing;
	public bool FreezeTime;
	public bool FollowersCharmed;

	public const string PLAYER_TAG = "Player";
	public const string ENEMY_TAG = "Enemy";
	public const int COLLISION_LAYER = 8;
	public const string TOOGLE_FOLLOW = "Toogle Follow";
	public const string BYPASS_OBSTICLE = "Bypass Obsticle";
	public const string FOLLOWER_TAG = "Follower";

	public const float CAMERA_SMOOTH_TIME = 1f;
	public const float CAMERA_FOLLOWER_DEATH_SMOOTH_TIME = 0.2f;

	void Start(){
		Instance = this;
		FolloweresFollowing = true;
	}
}
