using UnityEngine;
using System.Collections;

public class Wisp_Life : MonoBehaviour {

	public float Lifetime;
	[HideInInspector]
	public bool isDead;
	private float timer;
	private Bandurko_AnimHash hash;

	void Start(){
		hash = GetComponent<Bandurko_AnimHash>();
	}

	void FixedUpdate(){
		if(!isDead){
			timer += Time.deltaTime;

			if(timer >= Lifetime){
				isDead = true;
				GetComponent<Animator>().SetBool(hash.Dying, true);
			}
		}
	}

	public void DestroyWisp(){
		Destroy(transform.parent.gameObject);
	}
}
