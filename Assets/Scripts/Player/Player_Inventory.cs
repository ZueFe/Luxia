using UnityEngine;
using System.Collections;

public class Player_Inventory : MonoBehaviour {

	[HideInInspector]
	public bool HasKey = false; 

	private int numOfKeys = 0;

	public void AddKey(){
		numOfKeys++;
		HasKey = true;
	}

	public void UseKey(){
		numOfKeys--;
		if(numOfKeys <= 0){
			HasKey = false;
		}
	}
}
