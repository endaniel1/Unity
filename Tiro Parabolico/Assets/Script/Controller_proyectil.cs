using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_proyectil : MonoBehaviour {

	public float angles;

	public Vector3 point;

	Rigidbody2D rgb2d;

	GameObject generadorDiana;


	// Use this for initialization
	void Awake () {
		rgb2d = GetComponent<Rigidbody2D> ();

		if (Gestor_scenes.instance == null) {
			Gestor_scenes.instance = new Gestor_scenes ();
		}
		if(generadorDiana==null){
			generadorDiana=GameObject.FindWithTag ("Generador_Diana");
		}

		//rgb2d.AddForce ( transform.right * 200);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 v = rgb2d.velocity;
		var angle = Mathf.Atan2 (v.y,v.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle,Vector3.forward); 
	}

	void Disparar(float fuerza){
		rgb2d.AddForce ( transform.right * fuerza);

	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Suelo")) {
			Destroy (gameObject);
		} else if (col.CompareTag ("Diana")) {
			print ("1 punto");
			Destroy (gameObject);
			Destroy (col.gameObject);
			generadorDiana.SendMessage("SumarPuntos");
		} else if (col.CompareTag ("Patito") || col.CompareTag ("Tanke")) {
			print ("Has perdido");
			Destroy (gameObject);
			Destroy (col.gameObject);
			//var gestor = GameObject.FindGameObjectWithTag ("Gestor_Scenes");
			//gestor.SendMessage ("CambuiarScene","Perder");

			Gestor_scenes.instance.CambuiarScene ("Perder");
		
		} 

	}
	//borrar a salir de l scenana
	void OnBecameInvisible(){
		if(transform.position.y < 0  ){
			Destroy(gameObject);
		}


	}
}
