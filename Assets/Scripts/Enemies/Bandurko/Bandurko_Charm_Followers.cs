using UnityEngine;
using System.Collections;

public class Bandurko_Charm_Followers : MonoBehaviour {

	private bool charmed = false;

	void OnTriggerEnter(Collider col){
		if(col.tag == Global_Variables.FOLLOWER_TAG){
			GameObject firstFollower = Camera.main.GetComponent<Game_Manager>().followerInstances[0];
			Follow_Player fp = firstFollower.GetComponent<Follow_Player>();

			fp.Follows = gameObject.gameObject;
			fp.followsPlayer = false;
			charmed = true;
		}
	}
}
