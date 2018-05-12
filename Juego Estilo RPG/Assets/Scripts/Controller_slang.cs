using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_slang : MonoBehaviour {

	[Tooltip("Esperar X segundos antes de destruir el objeto")]//este mensjae nos va a parecer si dejamos el raton ensima del campo
	public float waitBeforeDestroy;//varable floante q es la q hace q espermos unos segundo antes de destruir el objeto

	[HideInInspector]//esot lo q hace es esconder la varible vecto2 en el inspetor
	public Vector2 mov;//variable vector2 q tiene el movimento osea la direcion en donde va el objeto

	public float speed;//varible float q carga la velocida en la q va el objeto

	void Update () {
		//aqui actulizamos la posicion de movimento 
		//sumandole un nuevo vector3 q tenga el el vomiento en el eje X y Y Q NOSOSTRO LE INDIQUEMOS por la velocidad(speed) y Time.deltaTime
		transform.position += new Vector3(mov.x,mov.y,0) * speed * Time.deltaTime;
	}
	//metodo q se ejecuta cuiendo entramos en un trigger 
	//pero esta vez como una corrutina para esperar un tiempo para q se ejecute algo
	IEnumerator OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Object"){ //comprobamos si chocamos con un objeto q tenga el tag Object
			yield return new WaitForSeconds(waitBeforeDestroy);//esperamos unos segundo 
			Destroy(gameObject);//aqui desturimos el tajo o slang
			//esot esperara un tiempo antes de destruirse y si choca con varios lo destruira
		} else if (col.tag != "Player" && col.tag != "Acttack"){ //comprobaremso igual aqui q no choquemos ni con el tag jugador ni con el Acttack

			//aqui retamos la vida del enemigo
			if(col.tag=="Enemy") col.SendMessage("Atacado");//mandamos un mes q ejecute el metod Atacando


			Destroy(gameObject);//igualmente aqui se destruira este objetos
		}
	}
}
