using UnityEngine;
using System.Collections;

public class Bandurko_Charm_Followers : MonoBehaviour {

	public GameObject BandurkoEye;

	private Animator anim;
	private Obsticle_Stats stats;
	private bool dead = false;
	private bool charming = false;

	void Start(){
		anim = GetComponent<Animator>();
		stats = GetComponent<Obsticle_Stats>();
	}


	void OnTriggerEnter(Collider col){
		if(col.tag == Global_Variables.FOLLOWER_TAG && !GetComponent<Bandurko_Movement>().dead){
			ChangeFollowing(gameObject, false, true);
			GetComponent<Bandurko_Movement>().charming = true;
			Global_Variables.Instance.FolloweresFollowing = true;
			Global_Variables.Instance.FollowersCharmed = true;
		}

		if(col.tag == Global_Variables.PLAYER_TAG && !GetComponent<Bandurko_Movement>().dead){
			GetComponent<Bandurko_Movement>().fleeing = true;
		
			if(GetComponent<Bandurko_Movement>().charming){
				if(!GetComponent<AudioSource>().isPlaying){
					gameObject.GetComponent<AudioSource>().clip = (AudioClip) Resources.Load("Sounds/bandurko death2", typeof(AudioClip));
					gameObject.GetComponent<AudioSource>().audio.Play();
				}
			}

		}
	}

	void OnTriggerExit(Collider col){
		if(col.tag == Global_Variables.PLAYER_TAG && !GetComponent<Bandurko_Movement>().dead){
			GetComponent<Bandurko_Movement>().fleeing = false;
		}
	}

	void OnTriggerStay(Collider col){
		if(!dead && col.tag == Global_Variables.PLAYER_TAG &&
		   Input.GetButtonDown(Global_Variables.BYPASS_OBSTICLE)){
			Player_Stats pStats = col.gameObject.GetComponent<Player_Stats>();

			if(pStats.GetEnergy() >= stats.EnergyCost){

				gameObject.GetComponent<AudioSource>().clip = (AudioClip) Resources.Load("Sounds/bandurko death", typeof(AudioClip));
				gameObject.GetComponent<AudioSource>().audio.Play();
				pStats.ChangeEnergy(-1f * stats.EnergyCost);
				ChangeFollowing(col.gameObject, true, false);

				anim.SetBool(GetComponent<Bandurko_AnimHash>().Dying, true);
				GetComponent<Bandurko_Movement>().dead = true;
				dead = true;
				Global_Variables.Instance.FollowersCharmed = false;
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
