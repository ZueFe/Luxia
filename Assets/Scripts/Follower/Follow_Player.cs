﻿using UnityEngine;
using System.Collections;

public class Follow_Player : MonoBehaviour {

	public float Offset;
	public GameObject Follows;
	public float Speed = 5f;
	public float MaxFallDistance = 3f;
	public bool followsPlayer;

	private Light playerLight;
	private bool hitPlayer = false;
	private const float FALL_OFFSET = 1.2f;

	// Use this for initialization
	void Start () {
		if(followsPlayer){
			//player = GameObject.FindGameObjectWithTag("Player");
			playerLight = Follows.GetComponentInChildren<Light>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		FollowPlayer();
	}

	void OnColliderEnter(Collision col){
		if(col.collider.tag == "Player" || col.collider.tag == "Follower"){
			hitPlayer = true;
		}else{
			hitPlayer = false;
		}
	}

	private void FollowPlayer(){
		float dist = GetDistanceWithPlayer();
		float direction = 0;
		float currentX = transform.position.x;

		if(followsPlayer && dist >= playerLight.range){
			return;
		}

		direction = Follows.transform.position.x - transform.position.x;

		if((!followsPlayer ||dist > Offset) &&
		   !(Follows.transform.position.x - Offset < transform.position.x && 
		 	Follows.transform.position.x + Offset > transform.position.x) &&
		   !hitPlayer){

			currentX = incrementTowards(transform.position.x, Follows.transform.position.x + Mathf.Sign(direction) * Offset, Speed);

			if(CheckForHole(currentX)){
				currentX = transform.position.x;
			}
		}

		Vector3 moveTo = new Vector3(currentX, transform.position.y, transform.position.z);

		rigidbody.MovePosition(moveTo);
		

	}

	private float GetDistanceWithPlayer(){
		Vector3 posFol = transform.position;
		Vector3 posPlay = Follows.transform.position;

		return Mathf.Pow(posFol.x - posPlay.x, 2) + Mathf.Pow(posFol.y - posPlay.y, 2) + Mathf.Pow(posFol.z - posPlay.z, 2);
	}

	private float incrementTowards(float n, float target, float acceleration){
		if(n == target){			//if player moves in target speed
			return n;
		}
		
		float dir = Mathf.Sign(target - n);			//get sign of acceleration (either speed up or down)
		n += acceleration * Time.deltaTime * dir;	//accelerate (up or down) based on acceleration speed
		
		if(dir == Mathf.Sign(target - n)){			//if target speed is not reached return n
			return n;
		}
		
		return target;								//if target speed is reached (or is smaller) return traget speed
		//so you won't ever go faster than target speed
	}

	private bool CheckForHole(float currentX){
		RaycastHit hit;

		if(!Physics.Raycast(new Vector2(currentX + FALL_OFFSET, transform.position.y), Vector3.down, MaxFallDistance + FALL_OFFSET)){
			return true;
		}

		if(!Physics.Raycast(new Vector2(currentX - FALL_OFFSET, transform.position.y), Vector3.down, MaxFallDistance + FALL_OFFSET)){
			return true;
		}

		return false;
	}
}
