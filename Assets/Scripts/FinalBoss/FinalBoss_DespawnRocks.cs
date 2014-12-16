using UnityEngine;
using System.Collections;

public class FinalBoss_DespawnRocks : MonoBehaviour {

	public float MaxDespawnTime;

	private Rigidbody rig;
	private bool startDespawning;
	private float timer;
	private float maxTimer;

	void Start(){
		rig = GetComponent<Rigidbody>();
	}

	void Update(){
		if (!Global_Variables.Instance.FreezeTime) {
			if (startDespawning) {
				timer += Time.deltaTime;

			if (timer >= 2) {
				gameObject.SetActive (false);
			}
		}


		if (!rig.isKinematic && !startDespawning) {
			maxTimer += Time.deltaTime;

			if (maxTimer >= MaxDespawnTime) {
				startDespawning = true;
			}

			if (rig.velocity.magnitude < 0.5f) {
				startDespawning = true;
			}
		}
	}
 }
}
