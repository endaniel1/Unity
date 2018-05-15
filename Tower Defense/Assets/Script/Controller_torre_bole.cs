using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_torre_bole : MonoBehaviour {

	public float speed=5f;



	// Use this for initialization
	void Update () {
		float fixedSpeed = speed * Time.deltaTime;
		transform.Translate (Vector2.up * fixedSpeed);
	}

	void OnBecameInvisible(){
		//print ("destruido " + GetInstanceID());
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Enemy")) {

			col.SendMessage ("Damage",10);
			Destroy (gameObject);
		
		}
	}

}
