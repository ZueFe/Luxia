using UnityEngine;
using System.Collections;

public class Lights_Movement : MonoBehaviour {
	
	public Transform HeadedTowards;
	public float Speed;

	//[HideInInspector]
	public Transform[] WayOutOfMaze;
	//[HideInInspector]
	public bool FoundByPlayer;
	//[HideInInspector]
	public int ofMazeIndex = -1;

	private bool turnedToBoat = false;
	private Animator anim;
	private Obsticle_AnimHash hash;

	void Start(){
		anim = GetComponent<Animator>();
		hash = GetComponent<Obsticle_AnimHash>();
	}


	void Update () {
		if(turnedToBoat){
			if(!anim.GetBool(hash.Activated)){
				anim.SetBool(hash.Activated, true);
			}

			return;
		}

		if(WayOutOfMaze.Length != 0){
			if(ofMazeIndex >= WayOutOfMaze.Length){
				turnedToBoat = true;
			}else{
				HeadedTowards = WayOutOfMaze[ofMazeIndex];
			}
		}
			
		Vector3 pos = transform.position;

		pos = Vector3.Lerp(pos, HeadedTowards.position, Time.deltaTime * Speed);
		transform.position = pos;

	}
}
