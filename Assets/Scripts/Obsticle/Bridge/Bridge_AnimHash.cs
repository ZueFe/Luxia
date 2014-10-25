using UnityEngine;
using System.Collections;

public class Bridge_AnimHash : MonoBehaviour {

	public int Activated;
	
	// Use this for initialization
	void Start () {
		Activated = Animator.StringToHash("Activated"); 
	}
}
