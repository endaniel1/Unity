using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fighter_controller : MonoBehaviour {

	public float speed=5f;//la varible de velocidad q por defecto carga 5
	public float padding=1f;
	public GameObject buller;//varible de objeto

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*//moviento horizontal 
		if(Input.GetKey(KeyCode.LeftArrow)){
			//comoviendo a la irsquierda
			transform.position+=new Vector3(-speed * Time.deltaTime,0,0);//tranforma la posicion del objeto crea un nuevo vecto en 3 dimenciones 
			//que los paramentros q resive son la de las cordenadas  x,y,z
			//se le va restando en el eje de las x
		}else if(Input.GetKey(KeyCode.RightArrow)){
			//moviewndo a la derrecha
			transform.position+=new Vector3(speed * Time.deltaTime,0,0);//tranforma la posicion del objeto crea un nuevo vecto en 3 dimenciones 
			//que los paramentros q resive son la de las cordenadas  x,y,z
		}
		*/

		//moviento horizontal otra forma
		//esta funcion decteta la acceleracion de la tecla q cuando dejamos y tocamos del teclado 
		float hInput = Input.GetAxis("Horizontal");
		transform.position+=new Vector3(hInput * speed * Time.deltaTime,0,0);

		//moviento vertical
		//esta funcion decteta la acceleracion de la tecla q cuando dejamos y tocamos del teclado 
		float vInput = Input.GetAxis("Vertical");
		transform.position+=new Vector3(0, vInput * speed * Time.deltaTime,0);

		//clamping,rectificacion
		//esta funcion lo q hace rectifica las posiciones para q nuestro objecto 
		//no se salga de la escena

		float newX= Mathf.Clamp(transform.position.x,-10 + padding,10 - padding);//esta funcion lo q rectifica las psosiciones
		//se le pasa el valor q en este caso es la posicion del objeto actual y los limites min y max
		//Q EN ESTE CASO MUESTRA ESCENA ES DE 10 Y -10
		float newY= Mathf.Clamp(transform.position.y,-10 + padding,10 - padding);
		transform.position = new Vector3 (newX,newY,0);

		//AHOAR SE RECTIFICA LA POSICION
		transform.position=new Vector3(newX,newY,transform.position.z);

		//DECTETANDO LA BALA O UN OBJETO 
		if(Input.GetKeyDown(KeyCode.Space)){//para cuando tiene la tecla de disparo precionada
			//poner un repetidor
			InvokeRepeating("Fire",0.001f,0.25f);//invoca un repetidor
			//q se le pasa el nombre de la funcion q vamos a repetir
			//el tiempo para q se ejecute por segundos en flotantes
			//y por ultimo cada cuntos segundo se quiere q se repita por segundo

		}else if(Input.GetKeyUp(KeyCode.Space)){//para cuando tiene la tecla de disparo suelta
			//para  parar el repetir
			CancelInvoke("Fire");//cancela la invocaion del repetido
			//se le pasa el nombre de la funcion q se quiera cancelar

		}
	}

	void Fire(){
		var Fighter = GameObject.Find ("Fighter");//Find busca una instancia dentro de una escena
		//con un tipo de objeto
		//ahora verificamos si no esta el objeto de la escena
		if(Fighter!=null){

			//SE RECTIFICA LA POSICION DEL OBJETO derecha y izquierda
			//izquierda
			Vector3 newLeftPosition=Fighter.transform.position +Vector3.up * 1.5f + Vector3.left * 0.5f;
			//se crea un nuevo vvector q cargue la posicion de nuestro objeto(nave)
			//y con "Vector3.up" se crea o le da una unida por encima del eje de nuestor objeto
			//y deespues se le suma con 
			//derecha "Vector3.left" o "Vector3.right" se crea o le da una unida por encima de derecha o izquierda
			//y para q no quede ta separada se le multiplica por las posiciones q deceas esto para q no sea una unida completa
			Vector3 newRigthPosition=Fighter.transform.position +Vector3.up * 1.5f + Vector3.right * 0.5f;

			Instantiate (buller,newLeftPosition,Quaternion.identity);
			Instantiate (buller,newRigthPosition,Quaternion.identity);
			//funcion q instance los objeto se le pasa la varible de objeto
			//y se le pasa la posicion del objeto q en nuestro caso es la nave
			//la rotacion q representa no se mucho de esto
		}
	
	}
}
