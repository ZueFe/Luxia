using UnityEngine;
using System.Collections;

public class Global_Variables : MonoBehaviour {

	public static Global_Variables Instance;

	public bool FolloweresFollowing;

	public const string PLAYER_TAG = "Player";
	public const int COLLISION_LAYER = 8;
	public const string TOOGLE_FOLLOW = "Toogle Follow";
	public const string BYPASS_OBSTICLE = "Bypass Obsticle";

	void Start(){
		Instance = this;
		FolloweresFollowing = true;
	}
}
