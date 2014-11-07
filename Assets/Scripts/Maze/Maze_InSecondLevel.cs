using UnityEngine;
using System.Collections;

public class Maze_InSecondLevel : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if(col.tag == Global_Variables.PLAYER_TAG){
			Global_Variables.Instance.PlayerInSecondLevel = !Global_Variables.Instance.PlayerInSecondLevel;
		}
	}
}
