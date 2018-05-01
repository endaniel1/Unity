using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//libreria q hace para cambiar de escenas o manipularlar

public class Menu : MonoBehaviour {

	public GameObject flecha, lista;//varble tipo objeto q tiene las flecha y la lista del menu

	int indice=0;//indice de la lista

	// Use this for initialization
	void Start () {
		Dibujar ();//metodo q dibuja la flecha
	}
	
	// Update is called once per frame
	void Update () {

		bool InputUp = Input.GetKeyDown ("up");//varible boleana q tiene si precion la tecla de arrba
		bool InputDown = Input.GetKeyDown ("down");//varible boleana q tiene si precion la tecla de abajo
		bool InputEnter = Input.GetKeyDown ("return");//varible boleana q tiene si precion la tecla de enter

		if (InputUp) //si es verdadero q se  preciona la tecla acia arriba 
			indice--;//se resta indice
		if (InputDown)//si es verdadero q se  preciona la tecla acia abajo 
			indice++;//se suma indice
		//filtro para q uotomaticamente se ponga en el 0 o en el ultimo lugar
		//lista.transform.childCount - 1 tiene el ultimo objerto de la lista 
		if (indice > lista.transform.childCount - 1) //comprobamos si el indice es mayor a la cantida de objetos q tenemos en la lista
			indice = 0;//y lo pondiramos a 0
		else if (indice < 0)//en caso de q sea menor q 0 
			indice = lista.transform.childCount - 1;//lo pondriamos al final del objeto de la lista

		if (InputUp || InputDown) //es verdadero q preionamos la tecla de arriba o la de abajo 
			Dibujar ();//llamamos otra vez al metodo dibujar q Dibujar la flecha

		if (InputEnter)//si es verdadero q presionamos la tecla enter
			Accion ();//llamamos al metodo Accion q es q hace una hacion
	}
	//metodo q dibuja la flecha
	void Dibujar(){
		//creamos uan varible de tipo Tranform LLAMADA opcion
		Transform opcion = lista.transform.GetChild (indice);
		//haceddemos a la posicion del hijo de objeto lista y le pasamos la varible indice
		//aciendo referencia con el metodo .GetChild
		flecha.transform.position=opcion.position;
	}
	//metodo q hace una aaccion
	void Accion(){//recuperamos a el elementeo  a q hacemos referencia
		Transform opcion = lista.transform.GetChild (indice);

		if (opcion.gameObject.name == "Salir") {//si el nombre del objeto es Salir
			print("Salir de juego");
			Application.Quit ();//salir del juego o de la aplicacion
		} else {//sino
			SceneManager.LoadScene (opcion.gameObject.name);//SceneManager.LoadScene carga una nueva escena 
			//opcion.gameObject.name saca el nombre del objeto a q hacemos referencia  
		}
	}
}
