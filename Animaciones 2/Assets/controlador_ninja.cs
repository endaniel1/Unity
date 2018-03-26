using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlador_ninja : MonoBehaviour {

	public float offsetX=0f;
	public float offsetY=0f;

	public GameObject KunaiPregaf;//varible del objeto

	private Animator animator;//avariable de animacion en donde guardamos la animacion

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();//guardamos aqui todos los componentes de animacion 
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown("space")){
			animator.SetTrigger ("atack");//SetTrigger llama a la animacion
		}
		//este trigger es el de lanzar
		if(Input.GetKeyDown("z")){
			animator.SetTrigger ("lanzar");//SetTrigger llama a la animacion

		}
	}
	void Lanzarkunai(){
		GameObject Kunai= Instantiate (KunaiPregaf,transform.position,Quaternion.identity);
		Kunai.transform.position = new Vector3 (offsetX,offsetY,0);

	}
}
