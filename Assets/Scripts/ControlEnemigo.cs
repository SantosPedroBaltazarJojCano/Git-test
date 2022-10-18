using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Using TEXTMESHPRO
using TMPro;


public class ControlEnemigo : MonoBehaviour
{
    public float vel = -1f;
    Rigidbody2D rgb;
	Animator anim;
	//new components
	public Slider slider;
	//text 
	public TMP_Text textenemy;
	//energy
	public float energy=100;

	public GameObject bulletPrototype;
	public int orcocerca=20;
    // Start is called before the first frame update
    void Start()
    {
        rgb=GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
    }

	void Update(){
		if(energy <= 0){
			energy = 0;
			anim.SetTrigger ("Morir");
		}
		slider.value = energy;
		textenemy.text = energy.ToString ();

	}

    private void FixedUpdate()
    {
        Vector2 v = new Vector2(vel, 0);
        rgb.velocity=v;

		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Caminando") && Random.value < 1f / (60f * 3f)){
			anim.SetTrigger("Apuntar");
		}else if(anim.GetCurrentAnimatorStateInfo (0).IsName ("Apuntar")){
			if (Random.value < 1f / 3f) {
				anim.SetTrigger("Disparar");
			}else{
				anim.SetTrigger("Caminar");
			}
		}

    }

	void OnTriggerEnter2D(Collider2D other){
		Flip ();
	}

	void Flip(){
		vel *= -1;

		var s = transform.localScale;
		s.x *= -1;
		transform.localScale = s;
	}

	public void Disparar(){
		anim.SetTrigger ("Apuntar");
	}
	/*
	public void EmitirBala(){
		GameObject bulletCopy = Instantiate(bulletPrototype);
		bulletCopy.transform.position = new Vector3(transform.position.x,transform.position.y,-1f);
		bulletCopy.GetComponent<ControlBala>().direction = new Vector3 (transform.localScale.x,0,0);
		energy--;
	}*/
	public void BajarPuntosPorOrcoCerca(){
		energy -= orcocerca;
	}	
}
