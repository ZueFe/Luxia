using UnityEngine;
using System.Collections;

public class Key_Movement : MonoBehaviour {

	public float RotationSpeed;
	

	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(Time.deltaTime * RotationSpeed, 0f, 0f));
	}
}
