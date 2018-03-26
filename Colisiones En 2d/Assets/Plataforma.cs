using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour {


	//funcion q sirva para dectetar una colicion
	//un objeto q tiene fuerza o q se le pueden apliccar
	void OnCollisionEnter2D(Collision2D  Collision){
		print("A pasado Un Evento de Colion!");
	}
	//funcion q sirva para dectetar un trigger 
	void OnTriggerEnter2D(Collider2D Collider){
		print("A pasado Un Evento de Trigger!");
	}
}
