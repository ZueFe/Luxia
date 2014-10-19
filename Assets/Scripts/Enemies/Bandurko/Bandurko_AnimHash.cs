using UnityEngine;
using System.Collections;

public class Bandurko_AnimHash : MonoBehaviour {
	
	public int Dying;
	
	// Use this for initialization
	void Start () {
		Dying = Animator.StringToHash("Dying"); 
	}
}
