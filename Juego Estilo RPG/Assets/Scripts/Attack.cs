using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
	//comprobando si el colider a chocado 
	void OnTriggerEnter2D(Collider2D col){
		//aqui restamos 1 a la vida del enemigo 
		if(col.tag=="Enemy"){
			col.SendMessage ("Atacado");
		}
	}
}
