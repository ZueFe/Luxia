using UnityEngine;
using System.Collections;

public class Player_Stats : MonoBehaviour {
	public float MaxIntensity = 7f;
	public float MinIntensity = 0f;
	public float MaxRange;
	public float MinRange = 6f;
	public float MinToDie = 0.5f;

	private float energy;
	private Light playerLight;
	private float energyLosePerSec;
	private const float SEC_IN_MIN = 60f;

	// Use this for initialization
	void Start () {
		energy = 100f;
		energyLosePerSec = energy / (MinToDie * SEC_IN_MIN);
		playerLight = gameObject.GetComponentInChildren<Light>();
		playerLight.intensity = MaxIntensity;
		playerLight.range = MaxRange;
	}
	
	// Update is called once per frame
	void Update () {
		ChangeEnergy(-1 * energyLosePerSec * Time.deltaTime);
		Debug.LogError(energy);
	}

	public void ChangeEnergy(float change){
		float energyPercentage;

		if(energy + change >= 0){
		energy += change;
	    
		}else{
			energy = 0;
		}

		energyPercentage = energy / 100f;

		playerLight.intensity = (MaxIntensity - MinIntensity) * energyPercentage + MinIntensity;
		playerLight.range = (MaxRange - MinRange) * energyPercentage + MinRange;
		
	}
}
