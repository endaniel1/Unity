using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_controller : MonoBehaviour {

	public float velocida = 2f;
	private Rigidbody2D rgb2d;//varible de Rigidbody2D q tiene el componente de Rigidbody2D

	// Use this for initialization
	void Start () {
		rgb2d = GetComponent<Rigidbody2D> ();//obtenemos el componente de Rigidbody2D
		rgb2d.velocity = Vector2.left * velocida;//ajutamos la velocida con ".velocity"
		//creamos un vector2 q se a la izquierdd q le vamos a sumar la velocida 
		//q es una velocida constante q se le suma a este cuerpo rigido
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//funcion q decteta una colicion
	void OnTriggerEnter2D(Collider2D other){//le pasamos un "Collider2D" y "other" q quiere decir el otro
		if(other.gameObject.tag=="Destroyer"){//comparamos si el "tag" del objeto q en este caso es "other"es "Destroyer"
			Destroy (gameObject);//aqui eliminamos el objeto q con q chocamos
		}
	}
}
