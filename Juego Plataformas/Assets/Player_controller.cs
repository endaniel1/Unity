using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour {

	public float maxSpeed= 4f;

	public float speed = 1f;

	public bool ground;

	public float jumpPower=6.5f;

	private bool jump;
	private bool doublejump;

	private Rigidbody2D rig2d;//caturamos el componente Rigidbody en una varible
	private Animator anim;//caturamos el componente Animator en una varible
	private SpriteRenderer spr;//caturamos el componente SpriteRenderer en una varible q es el color
	private bool movement=true;//varible q tiene el movimiento
	private GameObject RealHeath;//varilbe q tiene el objeto Image q es el q tiene lo de la vida

	// Use this for initialization
	void Start () {
		rig2d = GetComponent<Rigidbody2D> ();//detetamos el componente rigidbody al inciar el jugo
		//de nnuestro personaje
		anim = GetComponent<Animator> ();//detetamos el componente Animator al inciar el jugo
		//de nnuestro personaje
		spr = GetComponent<SpriteRenderer>();//detetamos el componente SpriteRenderer al inciar el jugo
		//de nnuestro personaje
		RealHeath=GameObject.Find("RealHeath");//Find buscamos en la gerarquia de objetos el q se llama RealHeath
		//no es muy recomendable utilizar ese metodo porquue puede relentizar pero como tenemos poco se se puede
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat ("Speed",Mathf.Abs(rig2d.velocity.x));//anim.SetFloat envia al animator 
		//Mathf.Abs obtine el valor absoluto de un numero
		anim.SetBool("Ground",ground);
		//para el salto de precaucion 
		if(ground){//comprobamos si estamos tocando el suelo 
			doublejump = true;//y abilitamos el doble salto
		}

		if(Input.GetKeyDown(KeyCode.UpArrow) ){//detectando cuando presiona la tecla hacia arriba
			if(ground){//comprovamos si estamos tocando el suelo
				jump=true;
				doublejump = true;//avilitamos para el doble salto q este caso sea true
			}else if(doublejump){//ahora si doublejump es verdadero
				jump=true;
				doublejump = false;//inavilitamos para el doble salto q este caso sea false
			}
		}
	}


	void FixedUpdate () {

		Vector3 fixedVelocity = rig2d.velocity;//creamos un nuevo vectot q tenga de una vez los valores de la velocidad del rig2d
		fixedVelocity.x *=0.75f;//AQUI POR CADA FOTOGRAMA LO MULTIPLICAREMOS 0.75

		if(ground){//Y CUANDO TOQUEMOS EL SUELO
			rig2d.velocity = fixedVelocity;//a velocity le añadiremos ese valor
		}

		float h = Input.GetAxis ("Horizontal");//detetamos la direcion horizontalmente
		if(!movement) h=0;//esto lo q indica si la varible de movimiento no es verdadera la h vale 0

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
		//Debug.Log (rig2d.velocity.x);



	}
	//este metodo es para cuendo el player sale fuera de la escena
	void OnBecameInvisible(){
		transform.position = new Vector3 (3.07f, 3.56f, 0);//aqui su posiscion cambia a la q le asignamos
	}

	//este metoto es para saltar despues q destruimos al enemigo
	public void Enemy_Jump(){
		jump = true;//aqui jump cambia a true
	}
	//metodso q tiene cuando se choca con un enemigo
	public void Enemy_Choque(float EnemyPosX){

		RealHeath.SendMessage ("TakeDamage",15f);//aqui lo q hacemos es mandar un mensaje a otro srcipt q ejeuta la funcion TakeDamage y le pasamo 15f q es el damño

		jump = true;//aqui jump cambia a true
		float side = Mathf.Sign(EnemyPosX - transform.position.x);
		rig2d.AddForce (Vector2.left * side * jumpPower, ForceMode2D.Impulse);//esto lo q fenerara es una fuerza diagonal cuando se choca con el enemyigo

		movement=false;//cambiamos la varible de movimiento a flase para q no se pueda mover mientra se choca
		Invoke("EnableMovemnt",0.7f);//aqui mandamos a invocar la funcion EnableMovemnt despues de 0.7 segundo

		Color color = new Color (255f/255f,106f/255f,0f/255f);//aasi creamos un nuevo color q nosostros mismo queremos
		spr.color=color;//aqui cambimos el color a nuestro jugador q este caso es de rojo para cuando chocamos
	}
	//este metodo es para activar el movimiento 
	public void EnableMovemnt(){
		movement = true;
		spr.color=Color.white;//aqui cambimos el color a nuestro jugador q este caso es de blanco porque no se liga con ninguncolor
	}

}
