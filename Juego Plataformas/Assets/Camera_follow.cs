using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour {

	public GameObject Follow;//varible tipo GameObject q es donde tenemos al objeot q quermos seguir
	public Vector2 maxCamPos,minCamPos;//varibles q tiene el minimo yel maximo de la posicion de la camara q va a llegar ella
	public float smothTime;

	private Vector2 velocity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float posX = Mathf.SmoothDamp(transform.position.x,
			Follow.transform.position.x, ref velocity.x,smothTime);
		//otenemos aui la posicion por cada fotograma del objeot a q queremos seguir aqui en este caso es de la psosicion x
		//con Mathf.SmoothDamp hacemos el efecto para suavizar el movimiento de la camara y lo q nesecitamos es
		//la posicion de inicio q en este caso es donde se encuntra la camara en el eje x
		//la psoscion a donde se quiere llegar q la carga follow.tranform.psocion.x
		//q ref es la variable q el gestiona para hacer la velocida
		//y luego la varible q nosostros vamos a q nosostros cremamos q es la q tiene el tiempo 

		//aqui abao es exactamente lo mismo pero con el eje y
		float posY= Mathf.SmoothDamp(transform.position.y,
			Follow.transform.position.y,ref velocity.y,smothTime);//otenemos aui la posicion por cada fotograma del objeot a q queremos seguir aqui en este caso es de la psosicion y
		//le reaccinamos la posicion al objeto q en ete caso es la camara por medio de un nuevo vector q tenga siempre las posiciones de cada fotograma y en el eje z sea siempre igual

		transform.position = new Vector3 (
			Mathf.Clamp(posX , minCamPos.x , maxCamPos.x),//con Mathf.Clamp recortamos la posicion q queremos en la camara tenga
			Mathf.Clamp(posY , minCamPos.y , maxCamPos.y),
			transform.position.z);
		
	}
}
