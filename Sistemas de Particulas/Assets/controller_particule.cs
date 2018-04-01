using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller_particule : MonoBehaviour {

	private ParticleSystem ps;//guarda en un varible tipo particula a la particula

	// Use this for initialization
	void Start () {
		ps = GetComponent <ParticleSystem> ();//obtenmos los componentes de la particula
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")){
			if (ps.isEmitting) {
				ps.Stop ();//para la particulas
				Debug.Log ("particula detenida");
			} else {
				ps.Play ();//inicia la particula
				Debug.Log ("particula play");
			}
		}
	}
}
