using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	//varible para gestionar el radio de vision y la velocidad
	public float radio_vision;
	public float speed;

	GameObject player;//varible q tiene al jugador

	Vector3 posicion_incial;

	// Use this for initialization
	void Start () {

		//al coomenzr buscaremos el tag  llamado Player osea recuperamos al jugador
		player = GameObject.FindGameObjectWithTag ("Player");

		//guardamos nuestra posicion inicial esta caso es el enemigo
		posicion_incial=transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		//creamos una varible vector3 q tenga la posicion de destino y q por defecto tenga la posicion de inicio
		Vector3 destino = posicion_incial;

		//utilizamos un metodo llamado Distance de la clase Vector3 
		//q resive dos vectores de 3 dimenciones
		//uno con la posicion q tiene el jugador
		//y otro con la pocion actual de nuestro objeto osea el enemigo
		float distancia = Vector3.Distance (player.transform.position,transform.position);

		//aqui se el radio de viusion es menor q la distancia q tenemos 
		//el destino va a hacer igual a la posicion de y q tiene nuestro player
		if(distancia < radio_vision) destino = player.transform.position;

		//despues creamos o retificamos la vcelocida de movimiento
		//q tenga la velocida y el tiempo por cad fotograma
		float fixedspeed =speed * Time.deltaTime;

		//ya listo lo q hacemos es mover nuestro objeto hacia ese punto de destino
		//cambiamos la posicion del objeto con transform.position
		//llamamos al vector3 y su metodo MoveTowards 
		//y le pasamos la posicion actual de nuestor objeto
		//la distancia q la cargamos en la varible destino
		//y la velocida q rectificamos con el fixedspeed
		transform.position=Vector3.MoveTowards(transform.position,destino,fixedspeed);

		//y con Debug.DrawLine esto es obcional dibujamos un linea
		//desde la poscion actual de nuestro objeto transform.position
		//hasta la posicion de destino destino
		//de X color
		Debug.DrawLine (transform.position,destino,Color.green);
	}
	//este metodo dibuja el radio de vision
	void OnDrawGizmos(){

		Gizmos.color = Color.yellow;//dibuja el color del radio
		//y Gizmos.DrawWireSphere dibuja el radio 
		//y le pasomos la posicion y el radio q nosostro queremos q en este caso es la varible radio de vision
		Gizmos.DrawWireSphere (transform.position,radio_vision);
	}
}
