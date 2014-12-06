using UnityEngine;
using System.Collections;

public class Dwarf_Movement : MonoBehaviour {

	public float Speed;
	public float SpeedChangeTime = 1f;

	private Rigidbody rigidbody;
	private float direction = -1f;
	private Animator anim;
	private float timerFromLastChange = 0;
	private float usedSpeed = 0f;
	private float t;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Global_Variables.Instance.FreezeTime){
			return;
		}
		timerFromLastChange += Time.deltaTime;
		if(timerFromLastChange>7){
			timerFromLastChange = 0f;
			ToogleDirection();
		}
		usedSpeed = Mathf.SmoothDamp(usedSpeed, Speed,ref t, SpeedChangeTime);
		rigidbody.MovePosition(new Vector3(this.transform.position.x + direction * usedSpeed * Time.deltaTime, this.transform.position.y, this.transform.position.z));
	
	}

	private void ToogleDirection(){
		direction *= -1f;
		Vector3 newScale = this.transform.localScale;
		newScale.x *= -1f;
		
		this.transform.localScale = newScale;
	}
}
