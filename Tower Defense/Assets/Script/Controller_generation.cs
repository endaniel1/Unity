using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_generation : MonoBehaviour {

	public GameObject enemy;
	public float starTime = 3f;
	public float repetTime= 5f;


	// Use this for initialization
	void Start () {

		InvokeRepeating ("Genera", starTime, repetTime);

	}
	
	// Update is called once per frame
	void Genera() {
		Instantiate (enemy);
	}
}
