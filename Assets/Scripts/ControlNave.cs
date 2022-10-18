using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Using TEXTMESHPRO
using TMPro;

public class ControlNave : MonoBehaviour
{
	//Components
	Rigidbody2D rgb;
	Animator anim;
	//others components
	public Slider slider;
	//text canvas
	public TMP_Text textnave;
	//life
	public float life=100;
	//joysticks
	bool enFire1=false;
	bool haciaDerecha = true;
	public float maxVel = 5f;
	public bool uyd;


	// Start is called before the first frame update
	void Start()
	{
		rgb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		life = 100;	
		//controls
		uyd = true;
	}

	void Update(){


	}
		void FixedUpdate()
	{
		///MOVED PLAYER
		if(uyd){ 
		float v = Input.GetAxis ("Horizontal");
		float v2 = Input.GetAxis("Vertical");
		//
		rgb.velocity = new Vector2(v, v2) * maxVel;
		Vector2 vel = new Vector2 (0,rgb.velocity.y);
		v *= maxVel;
		vel.x = v;
		rgb.velocity = vel;
		anim.SetFloat("speed",vel.x);
		if (haciaDerecha && v < 0){
			haciaDerecha = false;
			Flip();
		}
		else if (!haciaDerecha && v > 0){
			haciaDerecha = true;
			Flip();
		}
	//end uyd
		}

	//more code
	}



	//class flip
	void Flip() {
		var s = transform.localScale;
		s.x *= -1;
		transform.localScale = s;
	}



}