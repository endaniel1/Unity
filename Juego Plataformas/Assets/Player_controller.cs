using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour {

	public float maxSpeed=5f;

	public float speed = 2f;

	public bool ground;

	private Rigidbody2D rig2d;//caturamos el componente Rigidbody en una varible
	private Animator anim;//caturamos el componente Animator en una varible
	// Use this for initialization
	void Start () {
		rig2d = GetComponent<Rigidbody2D> ();//detetamos el componente rigidbody al inciar el jugo
		//de nnuestro personaje
		anim = GetComponent<Animator> ();//detetamos el componente Animator al inciar el jugo
		//de nnuestro personaje
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat ("Speed",Mathf.Abs(rig2d.velocity.x));//anim.SetFloat envia al animator 
		//Mathf.Abs obtine el valor absoluto de un numero
		anim.SetBool("Ground",ground);
	}


	void FixedUpdate () {

		float h = Input.GetAxis ("Horizontal");//detetamos la direcion horizontalmente

		rig2d.AddForce (Vector2.right * speed * h);//se le anñane un vector de 2 dimensiones q vaya a la derecha
		//despues se le multiplica por la velocidad q tenemos guardada y por la direcion
		/*
		//rectificamos si nos movemos mas rapido q la velocidad maxima en el eje horizontal y acipnamos la nueva velocidad
		if(rig2d.velocity.x > maxSpeed ){
			rig2d.velocity = new Vector2 (maxSpeed , rig2d.velocity.y);
		}
		if(rig2d.velocity.x < -maxSpeed ){
			rig2d.velocity = new Vector2 (-maxSpeed , rig2d.velocity.y);
		}*/
		//otra manera
		float limitSpeed = Mathf.Clamp (rig2d.velocity.x,-maxSpeed,maxSpeed);
		rig2d.velocity = new Vector2 (limitSpeed , rig2d.velocity.y);


		if(h > 0.1f){
			transform.localScale = new Vector3 (1f,1f,1f);//acedemos a la localizacion de la escala y le 
			//le cremos un nuevo vector para cambiarsela
		}
		if(h < -0.1f){
			transform.localScale = new Vector3 (-1f,1f,1f);
		}
		Debug.Log (rig2d.velocity.x);



	}
}
