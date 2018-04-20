using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour {

	public float maxSpeed= 4f;

	public float speed = 1f;

	public bool ground;

	public float jumpPower=6.5f;

	private bool jump;
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

		if(Input.GetKeyDown(KeyCode.UpArrow) && ground){//detectando cuando presiona la tecla hacia arriba
			jump=true;
		}
	}


	void FixedUpdate () {

		Vector3 fixedVelocity = rig2d.velocity;//creamos un nuevo vectot q tenga de una vez los valores de la velocidad del rig2d
		fixedVelocity.x *=0.75f;//AQUI POR CADA FOTOGRAMA LO MULTIPLICAREMOS 0.75

		if(ground){//Y CUANDO TOQUEMOS EL SUELO
			rig2d.velocity = fixedVelocity;//a velocity le añadiremos ese valor
		}

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
			//le crem	os un nuevo vector para cambiarsela
		}
		if(h < -0.1f){
			transform.localScale = new Vector3 (-1f,1f,1f);
		}
		//detetaqmos si preciono la tecla arriba porque jump es true
		if(jump==true){
			rig2d.velocity = new Vector2 (rig2d.velocity.x, 0);//eso cancela la velocidad si estmaos saltando por encima de una plataforma
			//le añadimos una fuerza q le pasamos un vector2 q va hacia arriba y le decimos q la fuerza es un impulso
			rig2d.AddForce (Vector2.up * jumpPower, ForceMode2D.Impulse);
			jump = false;//y volvemos a reacinarle el valor a jump
		}
		Debug.Log (rig2d.velocity.x);



	}
	void OnBecameInvisible(){
		transform.position = new Vector3 (-1, 0, 0);
	}
}
