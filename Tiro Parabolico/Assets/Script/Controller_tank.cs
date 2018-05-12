using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_tank : MonoBehaviour {

	public GameObject canon,punta;

	public GameObject prefabsProyectil,barra;

	public float fuerza=200f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//rotacion del caño
		var point = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		var angles = Geometry.AngleBetweenVectors (canon.transform.position,point);

		angles = Mathf.Clamp (angles,-15,65);

		//print (angles); angulo
		canon.transform.rotation = Quaternion.Euler (new Vector3(0,0,angles));


		//dectetamos cuando dejamos de disparar y cuando no para graduar la fuerza
		if(Input.GetMouseButtonDown(0)){//epieza carga
			barra.SendMessage("Carga");
		}
		if(Input.GetMouseButtonUp(0)){//finalñiza la carga
			
			//crear disparao con potencia carga
			GameObject proyectil =Instantiate (
				prefabsProyectil,
				punta.transform.position,
				punta.transform.rotation);

			float factorFuerza = barra.GetComponent<Controller_barra> ().GetFuerza();

			proyectil.SendMessage ("Disparar",fuerza * factorFuerza);

			proyectil.GetComponent<Controller_proyectil> ().angles=angles;

			//parar la barra luego de crear el disparo
			barra.SendMessage("Parar");
		}
	}
}
