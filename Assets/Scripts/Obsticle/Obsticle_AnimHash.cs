using UnityEngine;
using System.Collections;

public class Obsticle_AnimHash : MonoBehaviour {

	public int Activated;
	
	// Use this for initialization
	void Start () {
		Activated = Animator.StringToHash("Activated"); 
	}
}
