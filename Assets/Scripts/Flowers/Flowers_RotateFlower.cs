using UnityEngine;
using System.Collections;

public class Flowers_RotateFlower : MonoBehaviour {

	
	void Start(){
		Transform lever = null;

		foreach(GameObject g in transform.parent.GetComponent<Obsticle_Spawn_Trigger>().Levers){
			if(g.activeInHierarchy){
				lever = g.transform;
				break;
			}
		}

		SpriteRenderer[] flowers = GetComponentsInChildren<SpriteRenderer>();

		foreach(SpriteRenderer f in flowers){
			float x = f.transform.position.x - lever.position.x;

			Vector3 scale = f.transform.localScale;
			scale.x *= Mathf.Sign(x);
			f.transform.localScale = scale;
		}
	}
}
