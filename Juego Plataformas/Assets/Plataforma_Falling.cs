using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_Falling : MonoBehaviour {

	public float tiempo_caer = 1f;
	public float tiempo_volver = 5f;

	private Rigidbody2D rgb2d;
	private PolygonCollider2D pc2d;
	private Vector3 start;

	// Use this for initialization
	void Start () {
		rgb2d = GetComponent<Rigidbody2D> ();

		pc2d = GetComponent<PolygonCollider2D> ();

		start = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.CompareTag("Player")){//comparamos si estamos chocando con el tag Player
			Invoke("Fall",tiempo_caer);//mmandamos a llamar al metodo Fall al cabo de el tiempo de q le pasamos en la varible
			Invoke("Respawn",tiempo_caer + tiempo_volver);//mandamos a llamar al metodo Respawn al cabo del tiempo q le pasamos q es la suma de las dos varibles
		}
	}
	//metodo de caer
	void Fall(){
		rgb2d.isKinematic = false;//aqui le quitamos la propieda isKinematic
		pc2d.isTrigger=true;//aqui activamos q sea un trigger
	}
	//metodo de volver a posicionar la plataforma
	void Respawn(){
		transform.position = start;//le acinamos el objeto su posision inicial q es la varible start
		rgb2d.isKinematic = true;//volvemos a ativar la funcion isKinematic
		rgb2d.velocity = Vector3.zero;//volvemos a accinar la velocidad en el rg2d con Vector3.zero q ya da las velocidades iniciales
		pc2d.isTrigger = false;//y volvemos a desactivar el istrigger a pc2d para q sea una colcion normal como antes
	}
}
