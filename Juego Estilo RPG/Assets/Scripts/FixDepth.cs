using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixDepth : MonoBehaviour {

	public bool fixEveryFrame;//varible para ctualizar la posicion por fotograma
	SpriteRenderer spr;//varible para gestionar el spriterender

	void Start () {
		spr = GetComponent<SpriteRenderer>();//recuperamos el componte spriterende y se lo accimanso 
		spr.sortingLayerName = "Player";//aqui recuperamos la capa Player q es la misma q tiene el jugador
		//modifacamos al comenzar el sortingOrder de nuestro objeto
		spr.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
		//la altura q tiene nuestro objeot en la scena en el eje y pero negada
		//despues con Mathf.RoundToInt la reedondemos pero se nesecita un entero por eso se multiplica por 100  
	}

	void Update () {
		//igualmente en el update
		//comprobamos si posimos q quermeos q se modifique 
		if (fixEveryFrame) {//i de igualmanera q lo demas aqui
			spr.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
		}
	}
}