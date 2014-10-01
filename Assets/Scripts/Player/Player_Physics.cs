using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class Player_Physics : MonoBehaviour {

	public LayerMask CollisionMask;

	[HideInInspector]
	public bool Grounded{get;set;}
	[HideInInspector]
	public bool MovementStopped{get;set;}
	/*[HideInInspector]
	public bool Hanging{get;set;}*/

	private BoxCollider col;
	private Vector3 size;
	private Vector3 center;

	private Ray ray;
	private Ray rayForward;
	private RaycastHit hit;
	private RaycastHit hitForward;

	private float skin = 0.0005f; 		//to keep space between collider and ground

	void Start(){
		col = GetComponent<BoxCollider>();
		size = col.size;
		center = col.center;
	}


	public void Move(Vector2 moveAmount){
		float deltaY = moveAmount.y;
		float deltaX = moveAmount.x;
		Vector2 playerPosition = transform.position;
		Vector2 finalTransform;

		//Grounded = false;
		MovementStopped = false;

		for(int i = 0; i < 3; i++){
			float x = (playerPosition.x + center.x - size.x /2) + size.x/2 * i;
			float y = (playerPosition.y + center.y + size.y/2 * Mathf.Sign(deltaY));



			ray = new Ray(new Vector2(x,y), new Vector2(0, Mathf.Sign(deltaY)));

			if(Physics.Raycast(ray, out hit, Mathf.Abs(deltaY) + skin, CollisionMask)){
				float dst = Vector3.Distance(ray.origin, hit.point);

				//Stop player from moving down if distance to ground is <= than skin variable
				if(dst > skin){
					deltaY = dst * Mathf.Sign(deltaY) - skin * Mathf.Sign(deltaY);
				}else{
					deltaY = 0;
				}

				//Grounded = true;
				break;
			}


		
		}

		for(int i = 0; i < 3; i++){
		
		float xF = playerPosition.x + center.x + size.x/2 * Mathf.Sign (deltaX);
		float yF = (playerPosition.y + center.y - size.y /2) + size.y/2 * i;

		rayForward = new Ray(new Vector2(xF,yF), new Vector2(Mathf.Sign(deltaX), 0));
			if(Mathf.Abs(deltaX) > 0){
				if(Physics.Raycast(rayForward, out hitForward, Mathf.Abs(deltaX) + skin, CollisionMask)){
					float dst = Vector3.Distance(rayForward.origin, hitForward.point);
				
					if(dst > skin){
						deltaX = dst * Mathf.Sign (deltaX) - skin * Mathf.Sign (deltaX);
					}else{
						deltaX = 0;
					}
				
					MovementStopped = true;
					break;
			
				}
			}
		}

		/*if(/*!Grounded && !MovementStopped){
			Vector3 playerDirection = new Vector3(deltaX, deltaY);
			Vector3 o = new Vector3(playerPosition.x + center.x + size.x/2 * Mathf.Sign (deltaX), 
		                      	  (playerPosition.y + center.y + size.y/2 * Mathf.Sign(deltaY)));
				
			ray = new Ray(o, playerDirection.normalized);

				if(Physics.Raycast(ray, Mathf.Sqrt(deltaX * deltaX + deltaY * deltaY), CollisionMask)){
					//Grounded = true;

				deltaY = 0;
			}
		}*/


		finalTransform = new Vector2(deltaX, deltaY);

		transform.Translate(finalTransform);
	
}


}
