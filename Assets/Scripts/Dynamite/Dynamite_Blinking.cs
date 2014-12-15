using UnityEngine;
using System.Collections;

public class Dynamite_Blinking : MonoBehaviour {

	public Texture OriginalTexture;
	public Texture InvisibleTexture;
	public float BlinkingSpeed;
	public float BlinkingTime;
	[HideInInspector]
	public bool blinking;

	private Color blinkingColor;
	private Color t;
	private float timer;
	private Renderer mat;

	// Use this for initialization
	void Start() {
		blinking = true;
		blinkingColor = Color.black;
		mat = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(blinking){
			if(mat.material.shader != Shader.Find(Global_Variables.BLINKING_SHADER)){
				mat.material.shader = Shader.Find(Global_Variables.BLINKING_SHADER);
				mat.material.mainTexture = InvisibleTexture;
			}

			mat.material.color = Color.Lerp(mat.material.color, blinkingColor, Time.deltaTime * BlinkingSpeed);

			timer += Time.deltaTime;

			if(timer >= BlinkingTime){
				timer = 0;
				if(blinkingColor == Color.black){
					blinkingColor = Color.white;
				}else{
					blinkingColor = Color.black;
				}
			}
		}else{
			if(mat.material.shader != Shader.Find(Global_Variables.ORIGINAL_SHADER)){
				mat.material.shader = Shader.Find(Global_Variables.ORIGINAL_SHADER);
				mat.material.mainTexture = OriginalTexture;
				mat.material.color = Color.white;
			}
		}
	}
}
