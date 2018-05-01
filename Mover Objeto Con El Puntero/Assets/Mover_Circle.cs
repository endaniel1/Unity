using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_Circle : MonoBehaviour {
	//varuible tipo flotante q carga la velocida
	public float speed = 1f;
	//varible tipo vector3 q carge el punto de destno
	Vector3 destino;

	// Use this for initialization
	void Start () {
		//al iniciar el juego q tenga la varible destino el punto inicil q tiene nuestro objeto
		destino = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		//destetamos cuando asemos clik izquierdo
		if(Input.GetMouseButtonDown(0)){
			//bucamos la posinion del clik con respecto a la escena
			//Camera.main dectetala camra principal
			//y con ScreenToWorldPoint le pasamos la posicion del mouse q la tenemos asi  Input.mousePosition
			destino= Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//restablecemos la posicion en el eje z porque esto la estable mal
			destino.z = 0f;
		}

		//ya listo lo q hacemos es mover nuestro objeto hacia ese punto de destino
		//cambiamos la posicion del objeto con transform.position
		//llamamos al vector3 y su metodo MoveTowards 
		//y le pasamos la posicion actual de nuestor objeto
		//la distancia q la cargamos en la varible destino
		//y la velocida a la q nos quermos mover q la cargamos en speed
		transform.position=Vector3.MoveTowards(transform.position,destino,speed*Time.deltaTime);

		//y con Debug.DrawLine esto es obcional dibujamos un linea
		//desde la poscion actual de nuestro objeto transform.position
		//hasta la posicion de destino destino
		//de X color
		Debug.DrawLine (transform.position,destino,Color.green);
	}
}
