using UnityEngine;
using System.Collections;

public class gui : MonoBehaviour {
	public GameObject messageBoard;
	public GameObject bottomPanel;
	public GameObject healthbarForeground;
	public GameObject healthbarBackground;
	public GameObject healthbarLight;
	public GameObject keyIconCircle;
	public GameObject keyIcon;
	public GameObject pilgrimHealthbarForeground;
	public GameObject pilgrimHealthbarBackground;
	public GameObject pilgrimHealthbarLight;
	public GameObject head1;
	public GameObject head2;
	public GameObject head3;
	public GameObject head4;
	public GameObject health;
	public GameObject pilgrimsLife;
	public GameObject message;



	void start(){
		messageBoard =  GameObject.Find("MessageBoard");
		bottomPanel =  GameObject.Find("BottomPanel");
		healthbarForeground =  GameObject.Find("HealthbarForeground");
		// -||-
	}
	
}
