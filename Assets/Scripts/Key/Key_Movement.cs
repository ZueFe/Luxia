using UnityEngine;
using System.Collections;

public class Key_Movement : MonoBehaviour {

	public float RotationSpeed;
	public float MovementOffset = 0.5f;
	

	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(Time.deltaTime * RotationSpeed, 0f, 0f));

		transform.position = new Vector3(transform.position.x, transform.position.y + AddedElevation() * Time.deltaTime, transform.position.z);
	}

	private float AddedElevation(){
		float added = Mathf.PingPong(Time.time, 2 * MovementOffset);
		return added - MovementOffset;
	}
}
