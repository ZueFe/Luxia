using UnityEngine;
using System.Collections;

public class Light_WaypointTrigger : MonoBehaviour {

	public Transform[] ConnectedTo;
	public Transform[] OutOfMaze;
	

	void OnTriggerEnter(Collider col){
		if(col.tag == Global_Variables.LIGHT_OBST_TAG){
			if(!col.gameObject.GetComponent<Lights_Movement>().FoundByPlayer){
				int r = Random.Range(0, ConnectedTo.Length);
				col.gameObject.GetComponent<Lights_Movement>().HeadedTowards = ConnectedTo[r];
			}else if(col.gameObject.GetComponent<Lights_Movement>().WayOutOfMaze.Length == 0){
				col.gameObject.GetComponent<Lights_Movement>().WayOutOfMaze = OutOfMaze;
			}else{
				col.gameObject.GetComponent<Lights_Movement>().ofMazeIndex++;
			}
		}
	}

}
