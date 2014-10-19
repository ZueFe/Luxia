using UnityEngine;
using System.Collections;

public class Bandurko_Charm_Followers : MonoBehaviour {

	private bool charmed = false;

	void OnTriggerEnter(Collider col){
		if(col.tag == Global_Variables.FOLLOWER_TAG){
			ChangeFollowing(gameObject, false, true);

			/*GameObject firstFollower = Camera.main.GetComponent<Game_Manager>().followerInstances[0];
			Follow_Player fp = firstFollower.GetComponent<Follow_Player>();

			fp.Follows = gameObject.gameObject;
			fp.followsPlayer = false;
			charmed = true;*/
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

	private void ChangeFollowing(GameObject follows, bool followsPlayer, bool charmed){
		GameObject firstFollower = Camera.main.GetComponent<Game_Manager>().followerInstances[0];
		Follow_Player fp = firstFollower.GetComponent<Follow_Player>();
		
		fp.Follows = follows;
		fp.followsPlayer = followsPlayer;
		this.charmed = charmed;
	}

}
