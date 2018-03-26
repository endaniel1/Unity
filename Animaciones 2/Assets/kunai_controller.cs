using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kunai_controller : MonoBehaviour {


	public float speed=5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}


	void OnBecameInvisible() {//funcion automatica q tecteta cuando un objeto sale de la escena
		Destroy(gameObject);
	}
}
