using UnityEngine;
using System.Collections;

public class Game_FollowerDeath : MonoBehaviour {

	public float ToReachDeath;
	public float MaxRandomParam;
	public float MinRandomParam;

	private float deathTimer;
	private int lastFollowerIndex;
	private GameObject[] followers;
	private Light playerLight;
	private float speedIncreasePerDeath;
	private float currentReachSpeed;

	private bool switchToFollower;
	private float originalSpeed;
	private float timer;

	void Start(){
		followers = Camera.main.gameObject.GetComponent<Game_Manager>().followerInstances;
		playerLight = GameObject.FindGameObjectWithTag(Global_Variables.PLAYER_TAG).GetComponentInChildren<Light>();
		speedIncreasePerDeath = ToReachDeath / followers.Length;
		currentReachSpeed = ToReachDeath;
		lastFollowerIndex = followers.Length - 1;
	}

	void Update(){
		if(switchToFollower){
			timer += Time.deltaTime;
			
			if(timer >= Global_Variables.CAMERA_SMOOTH_TIME * 4){
				SwitchCameraBack();
			}
		
		}

		if(Global_Variables.Instance.FreezeTime || lastFollowerIndex < 0){
			return;
		}

		if(GetDistanceWithPlayer() >= playerLight.range){
			deathTimer += Time.deltaTime;

			if(deathTimer > currentReachSpeed *  Random.Range(MinRandomParam, MaxRandomParam)){
				SetUpDeath();
				SwitchCamera();
			}
		}else{
			currentReachSpeed = ToReachDeath;
			deathTimer = 0;
		}
	}

	private void SetUpDeath(){
		currentReachSpeed -= speedIncreasePerDeath;
		deathTimer = 0f;

		Follower_AnimHash hash = followers[lastFollowerIndex].GetComponent<Follower_AnimHash>();
		followers[lastFollowerIndex].GetComponent<Animator>().SetBool(hash.Dying, true);

		lastFollowerIndex--;
	}

	void SwitchCamera(){
		Global_Variables.Instance.FreezeTime = true;
		timer = 0f;
		switchToFollower = true;
		
		originalSpeed = Camera.main.GetComponent<Game_Camera>().TrackSpeed;
		GameObject player = Camera.main.GetComponent<Game_Manager>().Player;
		
		Camera.main.GetComponent<Game_Camera>().TrackSpeed = Global_Variables.CAMERA_FOLLOWER_DEATH_SMOOTH_TIME;
		Camera.main.GetComponent<Game_Camera>().setTarget(followers[lastFollowerIndex + 1].transform);
	}
	
	void SwitchCameraBack(){
		
		Camera.main.GetComponent<Game_Camera>().setTarget(GameObject.FindGameObjectWithTag(Global_Variables.PLAYER_TAG).transform);
		Camera.main.GetComponent<Game_Camera>().TrackSpeed = originalSpeed;
		
		Global_Variables.Instance.FreezeTime = false;
		switchToFollower = false;
	}

	public float GetDistanceWithPlayer(){
		Vector3 posFol = followers[0].transform.position;
		Vector3 posPlay = GameObject.FindGameObjectWithTag(Global_Variables.PLAYER_TAG).transform.position;
		
		return Mathf.Pow(posFol.x - posPlay.x, 2) + Mathf.Pow(posFol.y - posPlay.y, 2) + Mathf.Pow(posFol.z - posPlay.z, 2);
	}

	public float GetCurrentDeathTime(){
		return (currentReachSpeed - deathTimer) / currentReachSpeed;
	}

	public int NumberOfLivingFollowers(){
		return lastFollowerIndex + 1;
	}
}
