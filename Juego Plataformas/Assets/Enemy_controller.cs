using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_controller : MonoBehaviour {

	public float maxSpeed= 1f;
	public float speed = 1f;

	private Rigidbody2D rig2d;//caturamos el componente Rigidbody en una varible

	// Use this for initialization
	void Start () {
		rig2d = GetComponent<Rigidbody2D> ();//detetamos el componente rigidbody al inciar el jugo
		//de nnuestro enemigo
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		rig2d.AddForce (Vector2.right	 * speed);//se le anñane un vector de 2 dimensiones q vaya a la derecha

		float limitSpeed = Mathf.Clamp (rig2d.velocity.x,-maxSpeed,maxSpeed);
		rig2d.velocity = new Vector2 (limitSpeed , rig2d.velocity.y);

		//detectamos si la velocidad en el eje x es cercano a 0 bien sea mayor positivo o negativo
		if(rig2d.velocity.x > -0.01f && rig2d.velocity.x < 0.01f){
			speed = -speed;//le cambiamos el signo y se lo asignamos de nuevo a la varible
			rig2d.velocity = new Vector2 (speed , rig2d.velocity.y);//aqui le indicamos la nueva velocida q en la q deberia ir q en este caso es el speed
		}

		//en este caso si el speed es menor q 0 es porque esta llegndo a la derecha
		if(speed < 0){
			transform.localScale = new Vector3 (1f,1f,1f);//acedemos a la localizacion de la escala y le 
			//le cremos un nuevo vector para cambiarsela 
		}else if(speed > 0){
			transform.localScale = new Vector3 (-1f,1f,1f);
		}
	}
	//dectetamos si collisionamos con un trigger
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){//comprobamos si estamos chocando con el player

			float yOffet = 0.4f;//esta varible se crea para indentificar q esta el player por encima de esta distancia
			//osea si se le suma y es menor ocurre
			if(transform.position.y+yOffet < col.transform.position.y){//aqui dectetamos si estmos por encima del enemygo
				col.SendMessage("Enemy_Jump");//con la varible col q es la q tiene el objeto q se choca 
				//enviamos un mensaje para q se ejecute el metodo 
				Destroy (gameObject);//y aqui los destroimos
			}else{
				col.SendMessage("Enemy_Choque",transform.position.x);//le enviamos como parametro la psosicion en el eje x del enemigo
			}
		}
	}
}
