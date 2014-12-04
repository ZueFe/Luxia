using UnityEngine;
using System.Collections;

public class Enemy_SpawnWithDelay : MonoBehaviour {

	public float Delay;
	public GameObject Enemy;

	private float timer;

	// Update is called once per frame
	void Update () {
		Final_PlayerEntered pe = transform.parent.GetComponent<Final_PlayerEntered> ();

		if (pe != null && pe.PlayerEntered) {
			timer += Time.deltaTime;

			if (timer >= Delay) {
				Enemy.SetActive (true);
				this.gameObject.SetActive (false);
			}
		}
	}
}
