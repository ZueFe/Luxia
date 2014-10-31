using UnityEngine;
using System.Collections;

public class Follower_AnimHash : MonoBehaviour {

	public int Direction;
	public int Dying;

	// Use this for initialization
	void Start () {
		Direction = Animator.StringToHash("Direction"); 
		Dying = Animator.StringToHash("Dying");
	}
}
