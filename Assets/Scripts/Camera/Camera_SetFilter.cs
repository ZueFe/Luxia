using UnityEngine;
using System.Collections;

public class Camera_SetFilter : MonoBehaviour {

	public GUITexture texture;

	// Use this for initialization
	void Start () {
		Rect r = new Rect(0f, 0f, Screen.width, Screen.height * 2);

		texture.pixelInset = r;
	}
}
