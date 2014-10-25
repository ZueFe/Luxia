using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Obsticle_Stats))]
public class Bridge_Activate_Lever : MonoBehaviour {

	public GameObject Bridge;

	private Obsticle_Stats stats;
	private bool switchToBridge = false;
	private float timer = 0;

	private float originalSpeed;

	// Use this for initialization
	void Start () {
		stats = GetComponent<Obsticle_Stats>();
	}

	void Update(){
		if(switchToBridge){
			timer += Time.deltaTime;

			if(timer >= Global_Variables.CAMERA_SMOOTH_TIME * 6){
				SwitchCameraBack();
			}
		}
	}
	
	void OnTriggerStay(Collider col){
		if(col.tag == Global_Variables.PLAYER_TAG && Input.GetButtonDown(Global_Variables.BYPASS_OBSTICLE)){
			GameObject player =  GameObject.FindGameObjectWithTag(Global_Variables.PLAYER_TAG);
			Player_Stats pStats = player.GetComponent<Player_Stats>();
			
			if(pStats.GetEnergy() >= stats.EnergyCost){
				Bridge_AnimHash hash = GetComponent<Bridge_AnimHash>();

				GetComponent<Animator>().SetBool(hash.Activated, true);

				pStats.ChangeEnergy(-1f * stats.EnergyCost);

				SwitchCamera();		
			}
		}
	}

	void LeverActivated(){
		Bridge_AnimHash hash = Bridge.GetComponent<Bridge_AnimHash>();
		
		Bridge.GetComponent<Animator>().SetBool(hash.Activated, true);

		BoxCollider[] cols = transform.parent.GetComponentsInChildren<BoxCollider>();

		foreach(BoxCollider c in cols){
			c.enabled = !c.enabled;
		}
	}

	void SwitchCamera(){
		Global_Variables.Instance.FreezeTime = true;
		switchToBridge = true;

		originalSpeed = Camera.main.GetComponent<Game_Camera>().TrackSpeed;
		GameObject player = Camera.main.GetComponent<Game_Manager>().Player;

		Camera.main.GetComponent<Game_Camera>().TrackSpeed = Global_Variables.CAMERA_SMOOTH_TIME;
		Camera.main.GetComponent<Game_Camera>().setTarget(Bridge.transform);
	}

	void SwitchCameraBack(){

		Camera.main.GetComponent<Game_Camera>().setTarget(GameObject.FindGameObjectWithTag(Global_Variables.PLAYER_TAG).transform);
		Camera.main.GetComponent<Game_Camera>().TrackSpeed = originalSpeed;
		
		Global_Variables.Instance.FreezeTime = false;
		switchToBridge = false;
	}
}
