using UnityEngine;
using System.Collections;

public class Lights_ScaleBoat : MonoBehaviour {

	public float EndScale;

	private bool startScaling;
	private const float ERROR_MARGIN = 0.05f;

	void Update(){
		if(startScaling){
			Vector3 scale = transform.localScale;
			scale = Vector3.Lerp(scale, new Vector3(EndScale, EndScale, EndScale), Time.deltaTime);

			transform.localScale = scale;

			if(scale.y >= EndScale - ERROR_MARGIN){
				startScaling = false;
			}
		}
	}

	public void StartScaling(){
		startScaling = true;
	}
}
