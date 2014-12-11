using UnityEngine;
using System.Collections;

public class Game_Camera : MonoBehaviour {

	public float TrackSpeed = 10;

	private Transform target;
	private float t1;
	private float t2;


	public void setTarget(Transform t){
		target = t;
	}

	public Transform getTarget(){
		return target;
	}

	void LateUpdate(){
		if(target == null){
			return;
		}

		float x = Mathf.SmoothDamp(transform.position.x, target.position.x, ref t1, TrackSpeed);
		float y = Mathf.SmoothDamp(transform.position.y, target.position.y, ref t2, TrackSpeed);

		transform.position = new Vector3(x,y,transform.position.z);
	}
}
