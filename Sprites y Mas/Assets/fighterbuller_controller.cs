using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fighterbuller_controller : MonoBehaviour {

	public float bulletSpeed = 1f;

	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0,bulletSpeed,0);
	}
	
	// Update is called once per frame
	void Update () {
		//monituerar ¿la posicion de la bala  para destruir

		if(transform.position.y >10.5){
			Destroy (gameObject);
			print ("disparo destruido");
		}
	}
}
