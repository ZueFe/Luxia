using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player_Physics))]
public class Player_Controller : MonoBehaviour {

	//Player handling variables
	public float Speed = 8;					//speed in which player moves
	//public float ClimbingSpeed = 5;
	public float Acceleration = 30;			//player's acceleration
	//public float Gravity = 20;				//gravity force
	//public float JumpHeight = 12;			//height of jump
	

	private float currentSpeed;				//to hold current speed of player
	private float targetSpeed;				//to hold speed to which player wants to speed up
	private float targetElevation;
	private float climbSpeed;
	private float currentElevation;

	private Vector2 amountToMove = new Vector2();		//vector representing player movement change
	private Player_Physics playerPhysics;	
	private Vector3 scale;

	private const float ADDED_ELEVATION = 0.5f;

	// Use this for initialization
	void Start () {
		playerPhysics = GetComponent<Player_Physics>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Global_Variables.Instance.FreezeTime){
			return;
		}

		ProcessLocomotion();
		ProcessPlayerInput();
	}

	//returns value in which player should move, in respect to current speed and acceleration factor
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

	private void ProcessLocomotion(){
		
		if(playerPhysics.MovementStopped){		//if player hit right/left wall -- to remove 'sticky' effect
			targetSpeed = 0;
			currentSpeed = 0;
		}
		
		//climbSpeed = Input.GetAxisRaw("Vertical") * ClimbingSpeed;
		
		//get targeted elevation and speed based on input and compute current elevation and speed based on acceleration
		targetElevation = Input.GetAxisRaw("Vertical") * Speed;
		targetSpeed = Input.GetAxisRaw("Horizontal") * Speed;
		//currentSpeed = incrementTowards(currentSpeed, targetSpeed, Acceleration);
		currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime * Speed);
		currentElevation = incrementTowards(currentElevation, targetElevation, Acceleration);
		
		
		/*if(playerPhysics.Grounded){
			//amountToMove.y = 0;  		//has to zero out, since grounded is set in physics class

			//Jump
			/*if(Input.GetButtonDown("Jump")){
				amountToMove.y = JumpHeight;
			}
		}*/
		
		scale = transform.localScale;
		
		if((targetSpeed != 0) && (Mathf.Sign(scale.x) != Mathf.Sign(targetSpeed))){
			scale.x = -1 * scale.x;
			transform.localScale = scale;
		}
		
		amountToMove.x = currentSpeed;
		amountToMove.y = currentElevation + AddedElevation();
		
		//if player is not hanging on noodle or is jumping on noodle
		/*if(!playerPhysics.Hanging || amountToMove.y /*- Gravity * Time.deltaTime > ClimbingSpeed){		
			amountToMove.y -= Gravity * Time.deltaTime;			//apply gravity
		}else{
			amountToMove.y = currentClimb;						//just let him climb
		}*/
		
		playerPhysics.Move(amountToMove * Time.deltaTime);
	}

	private void ProcessPlayerInput(){
		if(!Global_Variables.Instance.FollowersCharmed && Input.GetButtonDown(Global_Variables.TOOGLE_FOLLOW)){
			Global_Variables.Instance.FolloweresFollowing = !Global_Variables.Instance.FolloweresFollowing;
		}
	}
	

	private float AddedElevation(){
		float added = Time.time;

		added = Mathf.PingPong(added, 2 * ADDED_ELEVATION);
		added -= ADDED_ELEVATION;

		return added;
	}
}
