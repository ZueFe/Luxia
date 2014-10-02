using UnityEngine;
using System.Collections;

public class Game_Manager : MonoBehaviour {

	public GameObject Player;
	public GameObject[] Followers;
	public int NumberOfFollowers;

	private GameObject[] followerInstances;
	private Game_Camera gameCamera;

	// Use this for initialization
	void Start () {
		gameCamera = GetComponent<Game_Camera>();
		followerInstances = new GameObject[NumberOfFollowers];
		spawnPlayer();
	}

	private void spawnPlayer(){
		GameObject p = Instantiate(Player, new Vector3(0, 0.5f, 0f), Quaternion.identity) as GameObject;
		gameCamera.setTarget(p.transform);

		GameObject fol;
		Follow_Player fp;

		fol = Instantiate(Followers[Random.Range(0, Followers.Length)], new Vector3(-2f, 1f, 0f), Quaternion.identity) as GameObject;
		fp = (Follow_Player)fol.GetComponent("Follow_Player");
		fp.Follows = p;
		fp.followsPlayer = true;

		followerInstances[0] = fol;

		for(int i = 1; i < NumberOfFollowers; i++){
			fol = Instantiate(Followers[Random.Range(0, Followers.Length)], new Vector3(-4f - 2*i, 1f, 0f), Quaternion.identity) as GameObject;
			fp = (Follow_Player)fol.GetComponent("Follow_Player");
			fp.Follows = followerInstances[i - 1];
			fp.followsPlayer = false;
			followerInstances[i] = fol;
		}
	}
}
