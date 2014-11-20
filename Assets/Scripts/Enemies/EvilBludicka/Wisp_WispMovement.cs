using UnityEngine;
using System.Collections;

public class Wisp_WispMovement : MonoBehaviour {

	public float SmoothingTime;

	private Vector3 colSize;
	private float newX;
	private float newY;
	private Vector3 t;
	private Wisp_Life mov;
	private const float HEIGHT_OFFSET = 0.5f;

	void Start(){
		colSize = transform.parent.GetComponent<BoxCollider>().size;
		mov = GetComponentInChildren<Wisp_Life>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(mov.isDead){
			return;
		}

		newX = Random.Range(-colSize.x, colSize.x);
		newY = Random.Range(-HEIGHT_OFFSET - colSize.y, colSize.y + HEIGHT_OFFSET);

		Vector3 pos = transform.parent.position;

		pos.x += newX;
		pos.y += newY; 

		transform.position = Vector3.SmoothDamp(transform.position, pos, ref t, SmoothingTime);
	}
}
