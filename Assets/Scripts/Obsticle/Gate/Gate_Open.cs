using UnityEngine;
using System.Collections;

public class Gate_Open : MonoBehaviour {
	
	public GameObject Obsticle;
	
	private Obsticle_Stats stats;
	private MeshRenderer mesh;
	
	// Use this for initialization
	void Start () {
		stats = gameObject.GetComponent<Obsticle_Stats>();
	}
	
	void OnTriggerStay(Collider col){
		if(col.tag == Global_Variables.PLAYER_TAG && Input.GetButtonDown(Global_Variables.BYPASS_OBSTICLE)){
			if(col.gameObject.GetComponent<Player_Inventory>().HasKey){
				OpenGate ();
				col.gameObject.GetComponent<Player_Inventory>().UseKey();
			}else if(col.gameObject.GetComponent<Player_Stats>().GetEnergy() >= stats.EnergyCost){

				OpenGate();				
				col.gameObject.GetComponent<Player_Stats>().ChangeEnergy(-1 * stats.EnergyCost);
			}else{
				//not enough energy!
			}
		}
	}

	private void OpenGate(){

		Obsticle_AnimHash hash = Obsticle.GetComponent<Obsticle_AnimHash>();
		Obsticle.GetComponent<Animator> ().SetBool (hash.Activated, true);
		
		BoxCollider[] colliders = transform.parent.GetComponentsInChildren<BoxCollider> ();
		foreach (BoxCollider c in colliders) {
			if(c.gameObject.GetComponent<Key_Take>() == null){
				c.enabled = !c.enabled;
			}
		}
		
		gameObject.layer = Global_Variables.COLLISION_LAYER;
	}
}
