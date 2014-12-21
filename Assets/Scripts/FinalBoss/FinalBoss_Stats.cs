using UnityEngine;
using System.Collections;

public class FinalBoss_Stats : MonoBehaviour {

	public float MaxHealth;

	private float currentHealth;

	void Start(){
		currentHealth = MaxHealth;
	}

	public float GetCurrentHealth(){
		return currentHealth;
	}

	public void ChangeHP(float dmg){
		currentHealth += dmg;

		if(currentHealth <= 0){
			currentHealth = 1;
		}
	}
}
