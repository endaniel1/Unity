using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_Movil : MonoBehaviour {

	public Transform target;//q referencia al target
	public float speed;//q referencia a la velocidad en q se va a mover

	private Vector3 start,end;//las posisciones de la patafoma y del target
	// Use this for initialization
	void Start () {
		if(target!=null){//comprovamos si no es null el target
			target.parent = null;//aqui lo q hacemos es le quitamos la independencia al target q no sea el hijo
			start=transform.position;//la posicion de la platforma 
			end=target.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		if(target!=null){//comprovamos si no es null el target
			float fixedspeed=speed*Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position,target.position,fixedspeed);
			// se le pasa una varible tipo vector 3 con el punto en donde estamos
			// se le pasa otra varible tipo vector 3 con el objetivo a donde vamos 
			//y la distancia maxima multiplicada por e tiempo delta

		}

		if(transform.position == target.position){//comprovamos ccuando la psosicion de la platafoma es igual a la del target
			//acemos una condicion ternaria para acinarle la nnueva posicion 
			target.position=(target.position == start) ? end : start;
			//le cambimso la posicion diciendo con el operador ternario q si es igual a la poscion de incio sea igual a el target sino sea igual a start
		}
	}
}
