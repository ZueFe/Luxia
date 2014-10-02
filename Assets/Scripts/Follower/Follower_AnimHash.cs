using UnityEngine;
using System.Collections;

public class Follower_AnimHash : MonoBehaviour {

	public int Direction;

	// Use this for initialization
	void Start () {
		Direction = Animator.StringToHash("Direction"); 
	}
}
