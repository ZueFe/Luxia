using UnityEngine;
using System.Collections;

public class FinalBoss_GrowCrystalLight : MonoBehaviour {

	public float GrowingSpeed;

	private Vector3 finalScale;
	private bool activated = true;
	private Vector3 t;
	private Light l;

	// Use this for initialization
	void Start () {
		finalScale = transform.localScale;
		transform.localScale = Vector3.zero;
		l = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if(activated){
			if(!l.enabled){
				l.enabled = true;
			}
			transform.localScale = Vector3.SmoothDamp(transform.localScale, finalScale, ref t, GrowingSpeed);
		}
	}
}
