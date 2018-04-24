using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_controller : MonoBehaviour {

	bool active;//varible q se tiene la activacion de pausa
	Canvas canvas;//varible DE TIPO Canvas q tiene el canvas
	// Use this for initialization
	void Start () {
		canvas = GetComponent<Canvas> ();//obtenmos los valores del canvas de nuestra escenas
		canvas.enabled = false;//aqui desimos q se desative cuando inicia el juego

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")){//si presiona la tecla space hace
			active = !active;//q active sea negado
			canvas.enabled = active;//q se active o se desactive el canvas dependiendo del valor de active
			Time.timeScale = (active) ? 0 : 1f;//y Time.timeScale tiene el tiempo normal a q va el juego q por defecto es 1
			//con una condicion ternaria indicamos si active es verdader le asignamos q el tiempo sea 0 q este dectenido en caso contrario q sea 1  normal
		}
	}
}
