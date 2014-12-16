using UnityEngine;
using System.Collections;

public class FinalBoss_GrowCrystalLight : MonoBehaviour {

	public float GrowingSpeed;
	public float ShuttingSpeed;
	[HideInInspector]
	public bool activated;

	private Vector3 finalScale;
	private float lightIntensity;

	private Vector3 t;
	private Vector3 u;
	private Light l;
	private float i;
	private float k;

	// Use this for initialization
	void Start () {
		activated = false;

		finalScale = transform.localScale;
		transform.localScale = Vector3.zero;
		l = GetComponent<Light>();
		lightIntensity = l.intensity;
		l.intensity = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(!Global_Variables.Instance.FreezeTime){
			if(activated){
				GrowCrystal();
			}else{
				ShutDownCrystal();
			}
		}
	}

	private void GrowCrystal(){
		if(!l.enabled){
			l.enabled = true;
		}
		transform.localScale = Vector3.SmoothDamp(transform.localScale, finalScale, ref t, GrowingSpeed);
		l.intensity = Mathf.SmoothDamp(l.intensity, lightIntensity, ref i, GrowingSpeed);

	}

	private void ShutDownCrystal(){
		if(l.enabled){
			l.enabled = false;
		}

		GetComponentInParent<FinalBoss_ActivateCrystal>().Activated = false;

		transform.localScale = Vector3.SmoothDamp(transform.localScale, Vector3.zero, ref u, ShuttingSpeed);
		l.intensity = Mathf.SmoothDamp(l.intensity, 0f, ref k, ShuttingSpeed);
	}
}
