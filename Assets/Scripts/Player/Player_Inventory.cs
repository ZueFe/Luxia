using UnityEngine;
using System.Collections;

public class Player_Inventory : MonoBehaviour {

	[HideInInspector]
	public bool HasKey = false; 
	[HideInInspector]
	public bool HasDynamite = false;

	private int numOfKeys = 0;
	private int numOfDynamite = 0;

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

	public void AddDynamite(){
		numOfDynamite++;
		HasDynamite = true;
	}
	
	public void UseDynamite(){
		numOfDynamite--;
		if(numOfDynamite <= 0){
			HasDynamite = false;
		}
	}
}
