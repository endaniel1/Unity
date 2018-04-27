using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script2 : MonoBehaviour {

	//public Script1 script;//forma 1 creando una varible tipo script q tenga el componente tipo script del objeto
	public GameObject objeto1;//forma 2 creamos una varible tipo  GameObject q tenga el objeto en donde anda el script

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")){//cada vez q apretamos space
			//script.numero *= 2;//se va a multiplicar el numero q esta en el otro script por 2
			//script.DevuelNumero ();//aqui llamamos de esta forma a el metodo
			//objeto1.SendMessage("ValorNumeroMultiplicar",2);//accedemos a los metodos llamandolos y pasandole un valor con SendMessage
			//objeto1.SendMessage("DevuelNumero");//y q nos muestres

			Script1 script = objeto1.GetComponent<Script1> ();//creamos una varilbe tipo Script1 q tenga los componentes de nuestro script q se encuentra en la varible objecto

			script.numero *= 2;//despues llamamos al numero para asignarle un valor nuevo

			script.DevuelNumero ();//y llamamos al metodo q lo muestra
		}
	}
}
