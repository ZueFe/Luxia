using UnityEngine;
using System.Collections;

public class Bandurko_Charm_Followers : MonoBehaviour {

	public GameObject BandurkoEye;

	private Animator anim;
	private Obsticle_Stats stats;
	private bool dead = false;

	void Start(){
		anim = GetComponent<Animator>();
		stats = GetComponent<Obsticle_Stats>();
	}


	void OnTriggerEnter(Collider col){
		if(col.tag == Global_Variables.FOLLOWER_TAG && !GetComponent<Bandurko_Movement>().dead){
			ChangeFollowing(gameObject, false, true);
		}
	}

	void OnTriggerStay(Collider col){
		if(!dead && col.tag == Global_Variables.PLAYER_TAG &&
		   Input.GetButtonDown(Global_Variables.BYPASS_OBSTICLE)){
			GameObject player =  GameObject.FindGameObjectWithTag(Global_Variables.PLAYER_TAG);
			Player_Stats pStats = player.GetComponent<Player_Stats>();

			if(pStats.GetEnergy() >= stats.EnergyCost){
				pStats.ChangeEnergy(-1f * stats.EnergyCost);
				ChangeFollowing(GameObject.FindGameObjectWithTag(Global_Variables.PLAYER_TAG), true, false);

				anim.SetBool(GetComponent<Bandurko_AnimHash>().Dying, true);
				GetComponent<Bandurko_Movement>().dead = true;
				dead = true;
			}else{
				//not enough energy!
			}


		}
	}

	/*void OnTriggerExit(Collider col){
		if(col.tag == Global_Variables.FOLLOWER_TAG){
			ChangeFollowing(GameObject.FindGameObjectWithTag(Global_Variables.PLAYER_TAG), true, false);

			/*GameObject firstFollower = Camera.main.GetComponent<Game_Manager>().followerInstances[0];
			Follow_Player fp = firstFollower.GetComponent<Follow_Player>();
			
			fp.Follows = GameObject.FindGameObjectWithTag(Global_Variables.PLAYER_TAG);
			fp.followsPlayer = true;
			charmed = false;
		}
	}*/

	private void ChangeFollowing(GameObject follows, bool followsPlayer, bool activeEye){
		GameObject firstFollower = Camera.main.GetComponent<Game_Manager>().followerInstances[0];
		Follow_Player fp = firstFollower.GetComponent<Follow_Player>();
		
		fp.Follows = follows;
		fp.followsPlayer = followsPlayer;

		BandurkoEye.SetActive(activeEye);
	}

	private void DestroyObject(){
		Destroy(gameObject);
	}

}
