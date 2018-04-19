using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ckeck_ground : MonoBehaviour {

	private Player_controller player;//creamos un stancia del objeto Player_controller osea el script

	// Use this for initialization
	void Start () {
		player=GetComponentInParent<Player_controller> ();//busacamos el componete pero en este caso del padre
		//y asedemos buscando el script Player_controller

	}
	//funcion q es cuando entramos en una colicion
	void OnCollisionStay2D(Collision2D col){
		if(col.gameObject.tag=="Ground"){
			player.ground = true;//cambiamos el valor del Gruond
		}

	}
	//funcion q es cuando salimos en una colicion
	void OnCollisionExit2D(Collision2D col){
		if(col.gameObject.tag=="Ground"){
			player.ground = false;//cambiamos el valor del Gruond
		}
	}
}
