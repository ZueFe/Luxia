using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game_Manager : MonoBehaviour {

	public GameObject Player;
	public GameObject[] Followers;
	public int NumberOfFollowers;
	public Vector3 StartPosition = new Vector3(0f, 0.5f, 0f);
	[HideInInspector]
	public GameObject[] followerInstances;


	private Game_Camera gameCamera;
	private const float FOLLOWER_START_OFFSET = 10f;
	private const float FOLLOWER_HEIGHT_OFFSET = 4f;

	// Use this for initialization
	void Start () {
		gameCamera = GetComponent<Game_Camera>();
		followerInstances = new GameObject[NumberOfFollowers];
		spawnPlayer();
	}

	private void spawnPlayer(){
		GameObject p = Instantiate(Player, StartPosition, Quaternion.identity) as GameObject;
		gameCamera.setTarget(p.transform);


		GenerateFollower(p, true, 0, Random.Range(0, Followers.Length), StartPosition.x - FOLLOWER_START_OFFSET, FOLLOWER_HEIGHT_OFFSET);

		for(int i = 1; i < NumberOfFollowers; i++){
			GenerateFollower(followerInstances[i - 1], false, i, Random.Range(0, Followers.Length), (-1 * FOLLOWER_START_OFFSET -2*i), FOLLOWER_HEIGHT_OFFSET);
		}
	}

	private void GenerateFollower(GameObject follows, bool followsPlayer, int followerIndex, int spriteIndex, float xCoord, float yCoord){
		GameObject fol;
		Follow_Player fp;

		fol = Instantiate(Followers[spriteIndex], new Vector3(xCoord, yCoord, 0f), Quaternion.identity) as GameObject;
		fol.GetComponent<SpriteRenderer>().sortingOrder = -1 * followerIndex;

		fp = (Follow_Player)fol.GetComponent("Follow_Player");
		fp.Follows = follows;
		fp.followsPlayer = followsPlayer;
		
		followerInstances[followerIndex] = fol;
	}
}
