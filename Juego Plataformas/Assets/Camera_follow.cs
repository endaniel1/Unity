using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour {

	public GameObject Follow;//varible tipo GameObject q es donde tenemos al objeot q quermos seguir

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float posX = Follow.transform.position.x;//otenemos aui la posicion por cada fotograma del objeot a q queremos seguir aqui en este caso es de la psosicion x
		float posY=Follow.transform.position.y;//otenemos aui la posicion por cada fotograma del objeot a q queremos seguir aqui en este caso es de la psosicion y

		transform.position = new Vector3 (posX,posY,transform.position.z);
		//le reaccinamos la posicion al objeto q en ete caso es la camara por medio de un nuevo vector q tenga siempre las posiciones de cada fotograma y en el eje z sea siempre igual
	}
}
