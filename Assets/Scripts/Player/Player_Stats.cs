using UnityEngine;
using System.Collections;

public class Player_Stats : MonoBehaviour {
	public float maxIntensity = 7f;
	public float minIntensity = 0f;
	public float maxRange;
	public float minRange = 6f;

	private float energy;

	// Use this for initialization
	void Start () {
		energy = 100f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
