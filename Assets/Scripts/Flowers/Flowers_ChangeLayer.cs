using UnityEngine;
using System.Collections;

public class Flowers_ChangeLayer : MonoBehaviour {

	void Start(){
		if(GameObject.FindGameObjectWithTag(Global_Variables.PLAYER_TAG).transform.position.z > transform.position.z){
			gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1 * gameObject.GetComponent<SpriteRenderer>().sortingOrder;
		}
	}
}
