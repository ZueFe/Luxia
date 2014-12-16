using UnityEngine;
using System.Collections;

public class Dwarf_AnimHash : MonoBehaviour {

	public int Attacking;

	void Start(){
		Attacking = Animator.StringToHash("Attacking");
	}
}
