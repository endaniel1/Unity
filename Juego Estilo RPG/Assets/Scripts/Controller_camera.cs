using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_camera : MonoBehaviour {

	Transform target;//varble q carga la posicion de un objetivo
	float TopX,TopY,buttonX,buttonY;//ESTA varilbes carga las referencia de los limites de la parte superior o parte inferior de nuestro map

	Vector2 velocity;//varible tipo vector2 q indica la velocity de ref velocity

	public float smootTime=3f;//aqui varible tipo float q suavisa el movimiento

	void Awake(){
		//q aql iniciar busque a el objeto con el tag Player y almacena su tranform
		target = GameObject.FindGameObjectWithTag ("Player").transform;

	}

	void Start(){
		//esto lo q hace forza la resolucion en patalla completa
		Screen.SetResolution (800,800,true);
	}


	// Update is called once per frame
	void Update () {
		//comprovbamos si no estamso en pantalla completa Screen.fullScreen
		//y de eso de q si la pantalla es cuadrada de eso de 1 a 1
		if(!Screen.fullScreen || Camera.main.aspect !=1){
			//volvemos a forzar q sea a pantalla completa
			Screen.SetResolution (800,800,true);
		}
		//esto es para cerrar el juego cuando querramos
		if (Input.GetKey ("escape"))
			Application.Quit ();

		//varibles tipo float posX y posY que indica el movimiento de la camara despues de un periodo de tiempo
		//Mathf.Round redondea una cifra decimal a 2 decimales
		//por eso tododo lo q esta dentro de Mathf.Round lo multiplicamos y despues lo dividimos entre 100 esto para dar mas exactitu a la hora de redondear
		//Mathf.SmoothDamp funcion q es la q progrecivamente hace el moviemiento
		//q le pasamos la pocision altual de la camara en el eje x
		//se le indica la posicion del desltino q en este caso es la variable target en la poscion x
		//ref velocity q indica q internamente guarda una posicion y q en nuestro coaso vamos a utilizar su posicion x
		//y por ultimo el tiempo de ejecucion a medida q haga el calculo o en nuestro caso una reposicion
		//en nuestor caso es smootTime
		float posX = Mathf.Round ( 
			Mathf.SmoothDamp(transform.position.x,target.position.x, ref velocity.x,smootTime) 
			* 100) / 100;

		float posY= Mathf.Round ( 
			Mathf.SmoothDamp(transform.position.y,target.position.y, ref velocity.y,smootTime) 
			* 100) / 100;

		//aqui actualisaremos su posicion
		transform.position = new Vector3 (//creando un nu8evo vector q tenga
			//target.position.x posisicoin de nuestro jugador en el eje x
			//target.position.y posisicoin de nuestro jugador en el eje y
			Mathf.Clamp(posX,TopX,buttonX),//con clamp limitamos q no sea menor q topX ni mayo q buttonX
			Mathf.Clamp(posY,buttonY,TopY),//con clamp limitamos q no sea menor q  buttonY ni menor q topY
			transform.position.z//aqui su misma posicion en el eje z

		);
	}
	//esto establece  el limites q resive como parametro el objeto map 
	public void Establecer_Limite(GameObject map){
		//Tiled2Unity.TiledMap hace referencia al sscript q tiene cada uno de nuestro mapas, q cargamos esto en una varible llamada config
		//ahora recuperamos el componente Tiled2Unity.TiledMap de map
		Tiled2Unity.TiledMap config = map.GetComponent<Tiled2Unity.TiledMap> ();

		//aqui creamos una varible tipo float q carga el size de nuestra camara(dinamicamente)
		//q con Camera.main.orthographicSize lo carga automatico
		float cameraSize = Camera.main.orthographicSize;

		//despues ya listo todo eso estabelecemos lo limites top y button de nuestra camara

		//map.transform.position.x es la posiscion q se encuentra el mapa en el eje x
		//map.transform.position.y es la posiscion q se encuentra el mapa en el eje y 
		//cameraSize es el tamaño de la camara
		//config.NumTilesWide el numero de tiled q confooma el mapa
		TopX = map.transform.position.x + cameraSize;

		TopY = map.transform.position.y - cameraSize;

		buttonX = map.transform.position.x + config.NumTilesWide + cameraSize;

		buttonY = map.transform.position.y - config.NumTilesHigh - cameraSize;

		//llamamos a fastMov() para q rectifique estos limites
		fastMov ();
	}

	//aregalndo el rebote de la camara UN CAMBIO RAPIDO
	//esto ocurere porque limitamos la camara y en el sigueinte fotograma lo rectifica
	public void fastMov(){

		//rectificamos la poscion actual de neustra camara creando un nuevo vector3
		//q indique la nueva posicion
		transform.position = new Vector3 (
			target.position.x,//la posicion de nuestro destino en el eje X q lo encontramos en la varible target
			target.position.y,//la posicion de nuestro destino en el eje Y q lo encontramos en la varible target
			transform.position.z//possicon actual de nuestra camara en su eje z
		);


	}
}
