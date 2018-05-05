using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Controller_warp : MonoBehaviour {

	public GameObject target;//varble q carga la posision del punto destino
	//este metodo se ejecuta antes q enpieze el juego
	public GameObject targetMap;//variable q carga a el mapa de cada target

	//variables para controllar la opasida de la transiscion de la camaara
	bool start=false;//para controlar si empieza o no la transicion
	bool isPadein=false;//para controlar si la transicion es de entrada o salida
	float alpha=0;//opasida inicial del cuadro de transicion
	float fadeTime=1f;//transicion de 1 segundo


	GameObject area;//varible GameObject q tiene el mapa

	void Awake(){
		
		Assert.IsNotNull (target);
		//asedemos al componete SpriteRenderer de nuestro objeto q carga este script y lo desativamso
		GetComponent<SpriteRenderer> ().enabled = false;
		//despues asedemos a el hijo de nuestro objeto y igualmente lo desactivamos
		//transform.GetChild (0) el 0 significa a el pirmer hijo
		transform.GetChild (0).GetComponent<SpriteRenderer> ().enabled = false;
	
		Assert.IsNotNull (targetMap);//aqui indicamos q nuestro mapa no este null

		//busacamos el GameObject con el tag Area, para tener guardado 
		area = GameObject.FindGameObjectWithTag("Area");
	}
	//metodo q se ejecuta cuando se entra en un trigger
	//deforma q quermos q haga varias cosas
	//investigar para q sirve los enumeradores o corrutiva
	IEnumerator OnTriggerEnter2D(Collider2D other){
		//aqui desactivamos los componetes animator y el script
		other.GetComponent<Animator> ().enabled=false;
		other.GetComponent<Player_controller> ().enabled=false;

		FadeIn ();

		//ahora lo q queremos es esperardo un tiempor para ejecutar lo de mas codigo o lo demas
		yield return new WaitForSeconds (fadeTime);//con esto esperaremos un tiempo antes de ejecutar lo demas en este caso el tiempo es de 1 seguendo por fadeTime

		if(other.tag=="Player"){//detectamso si chocamos con el tag Player
			//y aqui colocamos nuestra posision q es de nuestro player
			//y despues hacedemos a la varible target a su hijo y a su posisicion
			//esta linea lo q hace es q nuestro palayer se mueva a la possiom del hijo del target
			other.transform.position = target.transform.GetChild (0).transform.position;

			//mandomos a llamar aqui del script Controller_camera a Establecer_Limite y le pasamos el targetMap
			Camera.main.GetComponent<Controller_camera>().Establecer_Limite(targetMap);

			FadeOut ();
			//y aqui activamos otra vez lo componetes
			other.GetComponent<Animator> ().enabled=true;
			other.GetComponent<Player_controller> ().enabled=true;

			//investigar que son corrutinas
			//est codigo lo q hace es q mandamos el nombre del nuestro mapa
			//q ya lo tenemos guardado en targetMap y se lo enviamos
			//al mentos ShowArea q se encuentra en el script Area_conttoller
			StartCoroutine (area.GetComponent<Area_conttoller>().ShowArea(targetMap.name));
		}
	}
	//metodo q dibuja el cuadro con opacidad encima de la pantalla simulando un transicion
	void OnGUI(){
		//comparamos si iniciamos o empezamos una transicion
		if(!start){
			//para salir directamente 
			return;
		}
		//creamso un nuevo color con un opacidad inicial de 0
		//asiganndole a GUI.color
		GUI.color = new Color (GUI.color.r,GUI.color.g,GUI.color.b,alpha);

		//creamos aqui un textura temporar para rellenar la pantalla
		Texture2D textura;
		textura = new Texture2D (1,1);//la creamos q sea de 1 pixel por 1 pixel q es lo mas pequeño
		textura.SetPixel (0,0,Color.black);//aqui la dibujamos rellenamos del pun 0 ,0 de color blanco
		textura.Apply ();//aqui aplicamos la textura

		//dibujamos la textura sobre toda la pantalla
		//con GUI.DrawTexture dibujamos las textura
		//creando un nuevo cuadrado o rectangulo q va de la esquina superior derecha q es 0,0
		//hasta la esquina inferion derecha con Screen.height , Screen.height
		GUI.DrawTexture(new Rect(0 , 0 , Screen.height, Screen.height),textura);

		//contolamos la transparencia
		if (isPadein) {
			//si es la de parecer se le suma la opacidad
			//a alpha tenemos q ir sumando progresimanente la opacidad y con
			// Mathf.Lerp q se le pasa lo q queremos q se sume
			//en cuanto y el tiempo q lo haga
			alpha = Mathf.Lerp (alpha, 1.1f, fadeTime * Time.deltaTime);
		} else {//si es lo contrario seria lo meismo pero restandole
			//si es la de desaparecer se le resta la opacidad
			alpha = Mathf.Lerp (alpha, -0.1f, fadeTime * Time.deltaTime);
			if (alpha < 0)//y si alpha es completamente < 0 es porque ya es totamente transparente
				start = false;//y al start la volvemos a colocal en false
		}
	}
	//metodos para contralar las transicion

	//para activar la transicion de entrada
	void FadeIn(){//esto es para q empiezce todo lo q es la transicion en aparecer
		start = true;
		isPadein = true;
	}
	//para activar la transicion de salida
	void FadeOut(){//esto es para 
		isPadein = false;
	}
}
