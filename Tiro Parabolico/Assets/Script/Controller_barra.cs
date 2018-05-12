using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_barra : MonoBehaviour {

	public GameObject fuerza;

	Coroutine cargar=null;


	public void Carga(){
		cargar= StartCoroutine (Incrementar());
	}
	public void Parar(){
		StopCoroutine (cargar);
		Reiniciar ();
	}

	IEnumerator Incrementar(){
		while (true) {

			float size = Mathf.Clamp (fuerza.transform.localScale.x + 0.015f, 0f, 1f);

			if (size >= 1f)
				Parar ();

			fuerza.transform.localScale = new Vector3 (size, 1f, 1f);
			yield return null;
	
		}
	}

	public void Reiniciar(){
		fuerza.transform.localScale=new Vector3(0,1f,1f);
	}
	public float GetFuerza(){
		return fuerza.transform.localScale.x;
	}

}
