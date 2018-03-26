using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlador : MonoBehaviour {
	//con esta funcion cambia de escenas 
	public void CambiarEscena(string nombre){//varible q se le pasa para ver a q escena quiere ir
		print ("Cambiando  la ESCENA "+nombre);//aqui imprimo para ver
		SceneManager.LoadScene (nombre);//y todo esto me cambia de escena solo necesita la varible de cambio 
	}
	//con esta funcion sale del juego
	public void salir(){
		print ("Saliendo de juego");
		Application.Quit();
	}
}
