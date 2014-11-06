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
		if(col.tag == Global_Variables.PLAYER_TAG && Input.GetButtonUp(Global_Variables.BYPASS_OBSTICLE)){
			GameObject player = GameObject.FindGameObjectWithTag(Global_Variables.PLAYER_TAG);

			if(player.GetComponent<Player_Inventory>().HasKey){
				OpenGate ();
				player.GetComponent<Player_Inventory>().HasKey = false;
			}else if(player.GetComponent<Player_Stats>().GetEnergy() >= stats.EnergyCost){

				OpenGate();				
				player.GetComponent<Player_Stats>().ChangeEnergy(-1 * stats.EnergyCost);
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
				c.enabled = !c.enabled;
		}
		
		gameObject.layer = Global_Variables.COLLISION_LAYER;
	}
}
