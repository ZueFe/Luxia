using UnityEngine;
using System.Collections;

public class Obsticle_Spawn_Trigger : MonoBehaviour {
	public GameObject[] Levers;

	void Start(){
		int pick = Random.Range(0, Levers.Length);

		Levers[pick].SetActive(true);
	}
}
