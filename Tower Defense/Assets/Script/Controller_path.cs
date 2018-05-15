using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_path : MonoBehaviour {

	public float speed;

	private int puntoActual;

	public Vector2[] puntos;

	// Use this for initialization
	void Start () {
		transform.position=puntos[0];
		puntoActual = 1;
	}




	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate () {

		/* Rotacion Tranform.rotation
		0 = Derecha
		90 = arriba
		100 = izquierda
		270 = abajo
		*/

		float angle = Geometry.AngeBetweenVector (puntos [puntoActual - 1], puntos [puntoActual]);

		transform.rotation=Quaternion.Euler(0f , 0f , angle);


		float fixedSpeed = speed * Time.deltaTime;

		Vector3 puntoDestino =	new Vector3 (
			puntos [puntoActual].x, 
			puntos [puntoActual].y, 
			0f);

		transform.position = Vector3.MoveTowards (
			transform.position,
			puntoDestino,
			fixedSpeed);

		if(transform.position == puntoDestino){
			//puntos[puntoActual] == puntos[puntos.Length-1]
			if(puntoActual == puntos.Length-1){
				Destroy (gameObject);
			}
			puntoActual++;
		}

	}


	void OnDrawGizmosSelected(){
		Gizmos.color = Color.blue;

		for (int i=0;i<puntos.Length-1;i++){
			Gizmos.DrawLine (
				new Vector3(puntos[i].x,puntos[i].y,0f),
				new Vector3(puntos[i+1].x,puntos[i+1].y,0f)
			);
		}

	}
}
