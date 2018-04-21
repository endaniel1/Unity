using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ckeck_ground : MonoBehaviour {

	private Player_controller player;//creamos un stancia del objeto Player_controller osea el script
	private Rigidbody2D rgb2d;//cremoa un varvle q sea de Rigidbody2D para aceder a ella y buscar la velocity

	// Use this for initialization
	void Start () {
		player=GetComponentInParent<Player_controller> ();//busacamos el componete pero en este caso del padre
		//y asedemos buscando el script Player_controller
		rgb2d=GetComponentInParent<Rigidbody2D>();//recoletamos aqui la posicion del inicio del padre q esta en el script
	}

	//funcion q es cuando entramos la primera vez  en una colicion
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag=="Plaform"){
			rgb2d.velocity = new Vector3 (0f,0f,0f);
			player.transform.parent = col.transform;//aqui si chocamos con la plataforma le accinaremos q tenga la psocion del padre q en este caso choco
			//con la varible de condicion es col de hay esta 
			player.ground = true;//cambiamos el valor del Plaform
		}
	}

	//funcion q es cuando entramos y ocurre o estamos en una colicion
	void OnCollisionStay2D(Collision2D col){
		if(col.gameObject.tag=="Ground"){
			player.ground = true;//cambiamos el valor del Gruond
		}
		if(col.gameObject.tag=="Plaform"){
			player.transform.parent = col.transform;//aqui si chocamos con la plataforma le accinaremos q tenga la psocion del padre q en este caso choco
			//con la varible de condicion es col de hay esta 
			player.ground = true;//cambiamos el valor del Plaform
		}

	}
	//funcion q es cuando salimos en una colicion
	void OnCollisionExit2D(Collision2D col){
		if(col.gameObject.tag=="Ground"){
			player.ground = false;//cambiamos el valor del Plaform
		}
		if(col.gameObject.tag=="Plaform"){
			player.transform.parent = null;//aqui si no chocamos con la plataforma le accinaremos q no este el la poscion del padre q en esta caso sea null
			//con la varible de condicion es col de hay esta 
			player.ground = false;//cambiamos el valor del Plaform
		}
	}
}
