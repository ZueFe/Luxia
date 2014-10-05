using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class Crystal_Flicker : MonoBehaviour {

	public float MaxRange = 3f;
	public float MinRange = 2f;
	public float SmoothingTime = 0.15f;


	private Light light;
	private float t;

	// Use this for initialization
	void Start () {
		light = gameObject.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		ChangeLightRange();
	}

	public void ChangeLightRange(){
		float currentRange = light.range;
		currentRange = Mathf.SmoothDamp(currentRange, Random.Range(MinRange, MaxRange), ref t, SmoothingTime);

		light.range = currentRange;

	}
}
