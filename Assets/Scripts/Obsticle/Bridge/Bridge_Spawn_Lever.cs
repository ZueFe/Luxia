using UnityEngine;
using System.Collections;

public class Bridge_Spawn_Lever : MonoBehaviour {
	public GameObject[] Levers;

	void Start(){
		int pick = Random.Range(0, Levers.Length);

		Levers[pick].SetActive(true);
	}
}
