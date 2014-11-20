using UnityEngine;
using System.Collections;

public class Wisp_MoveTrigger : MonoBehaviour {

	public float SmoothingTime;

	private float t;

	void FixedUpdate () {
		if(!Global_Variables.Instance.PlayerInSecondLevel){
			Vector3 pos = transform.position;

			pos.x = Mathf.SmoothDamp(pos.x, GameObject.FindGameObjectWithTag(Global_Variables.PLAYER_TAG).transform.position.x,
			                         ref t, SmoothingTime);

			transform.position = pos;
		}
	}
}
