using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealHeath : MonoBehaviour {

	public Image heal;

	float hp,maxhp=100f;

	// Use this for initialization
	void Start () {
		hp = maxhp;//cuando inicia el juego q el hp sea al maxhp
	}

	//metodo q ejecuta el daño q resivimos
	public void TakeDamage(float amunt){//varilbe q tiene el daño
		//Mathf.Clamp recortamos la cantida de daño q en nuestro caso q no sea menor q 0 ni mayor q la vida q en este caso 1
		hp = Mathf.Clamp (hp-amunt , 0f ,maxhp);//entoces hp menor q la amunt q le pasamos q no sea menor q 0 y tampoco mayor q maxph
		//con esto controlamos los puntos de vida con base a 100 puntos

		//controlamos el escalado de la barra de vida q tiene el heal
		heal.transform.localScale = new Vector2 (hp/maxhp,1);//cremao un nuevo vector con el escalado
		// en eje X divimos el hp/maxph q ya lo tenemos haciendo referencia para q no se pase de 0 y en el eje  Y q sea 1 q es su valor
		Debug.Log("vida q queda "+hp);//aqui lo q hago es para ver cuanta vida le queda y se pueda reiniciar el juego 
		//eso lo del reinicio tengo q hacerlo y mismo
	}
}
