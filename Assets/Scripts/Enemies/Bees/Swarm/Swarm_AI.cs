using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Bee_Movement))]
public class Swarm_AI : MonoBehaviour {
	void FixedUpdate () {
		if(!Global_Variables.Instance.PlayerInSecondLevel){
			gameObject.GetComponent<Bee_Movement>().ResolveMovement();
		}
	}
}
