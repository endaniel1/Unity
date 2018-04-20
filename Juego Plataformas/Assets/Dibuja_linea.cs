using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dibuja_linea : MonoBehaviour {

	public Transform form;//variable q tiene la posicion desde
	public Transform tu;//variable q tiene la posicion destino

	//este metodo se llamara automaticmente cuando un objeto se cliquea o se posiciona con un objeot en una escena
	void OnDrawGizmosSelected(){
		//comprobamos si son distint de null
		if(form!=null && tu!=null){
			Gizmos.color = Color.cyan;//esto es para el color de la linea
			//Gizmos.DrawLine dibuja un linia
			Gizmos.DrawLine(form.position,tu.position);//este metodo es para crear la linea
			//y lo q nesecita es la psoscion de donde empieza hasta donde termina
			//Gizmos.DrawSphere dibuja una esfera en la psosicion q queremos y se le da el tamoño
			Gizmos.DrawSphere(form.position,0.15f);
			Gizmos.DrawSphere(tu.position,0.15f);
		}
	}
}
