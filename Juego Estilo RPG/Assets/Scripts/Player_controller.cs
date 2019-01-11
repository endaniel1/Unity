using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player_controller : MonoBehaviour {

	public float speed = 4f;//VARIBLE Q CONTROLA LA VELOCIDA DE MOVIMIENTO
	Animator animacion;//varible tipo animacion q controla las animaciones de nuestro jugador

	public GameObject initalMap;//mapa inicial en donde empieza el jugador
	public GameObject slangPrefab;//varible tipo objeto q carga nuestro objeto tajo en el cual vamos a instancialor

	bool movimientoPrevent;//variable cooleana q tiene para q no se mueva el personaje

	Vector2 movimiento;//varible de vector2 q carga el moviemeitno de nuestro persosnaje
	Rigidbody2D rgb2d;//varible Rigidbody2D q carga el rigibody de nuestro player

	CircleCollider2D  acttackCollider;//varible q tiene la colision del actaque

	Arua_controller aura;//varible q carga el script de arua_controller

	//metodo q se ejecuta antes q el start
	void Awake(){
		//esto es para ver si no le hemos hacidnado nada nuestro objetos GameObject y nos de una alerta antes de empezar el juego
		Assert.IsNotNull (initalMap);//esto es para el mapa
		Assert.IsNotNull (slangPrefab);//y esto es para el Prefab del tajo
	}

	// Use this for initialization
	void Start () {

		animacion = GetComponent<Animator> ();//aqui recuperamos el componente Animator de nuestro jugador
		rgb2d = GetComponent<Rigidbody2D> ();//aqui recuperamos el componente Rigidbody2D de nuestro jugador

		//nos referimos al objeto camara, a su componente acemos referencia al script
		//y manandamos a llamar al metodo Establecer_Limite y le pasamo el initalMap
		//y de esta forma nos comunicamos con el script
		//y asi le passamoe el gameobjet 
		Camera.main.GetComponent<Controller_camera>().Establecer_Limite(initalMap);
	
		//acemos refereranci a el hijo de nuestro personaje y buscamos el componete CircleCollider2D para poder haceder a el
		acttackCollider =transform.GetChild(0).GetComponent<CircleCollider2D> ();
		//luego q lodectetamos lo desactivamos
		acttackCollider.enabled=false;

		//aqui recuperamos el componete osea el script Arua_controller del segundo hijo de nuestro player
		aura = transform.GetChild (1).GetComponent<Arua_controller> ();
	}
	
	// Update is called once per frame
	void Update () {

		Movimiento ();//llamamos a el metodo q carga el movimiento 

		Animacion();//y llamamso al metodo q carga las animaciones cuando se mueve

		SworAttack();//y llamamos el metodo q hace el ataque de nuestro jugador

		SlangActtack ();

		MovientoPrevent();//metodo q hace la prevencion de movimiento de nuestro personaje
	}
	void FixedUpdate () {
		//acedemos al compondete rigibody2d con el metod .MovePosition
		rgb2d.MovePosition (rgb2d.position + movimiento * speed * Time.deltaTime);
		//se le pasa la posisicon alctual en donde este el rigibody2d y 
		//se le suma el vector de movieento multiplicado por la velocida y por el tiempo
	}

	//METODO Q DECTECTA EL MOVIEMTNO DE NUESTOR PERSONAJE
	void Movimiento(){
		//vamos a utilizar el moviemiento q contiene el compondete Rigidbody2D
		//pero para esto tenemos q utilizarlo en el FixedUpdate
		movimiento = new Vector2(
			Input.GetAxisRaw("Horizontal"),//aqui si vamos a hacer un moviemiento horizontal eje x, q devuelve -1 si presionamos a la izquierda y 1 a la derecha y 0 si no presionamos nada
			Input.GetAxisRaw("Vertical")//aqui si vamos a hacer un moviemiento vertical eje y, q devuelve -1 si presionamos a la izquierda y 1 a la derecha y 0 si no presionamos nada
		); 

		//variable vector3 para el movimiento
		//Vector3 movimiento = new Vector3 (//creamos un nuevo vector q tenga las posisciones
		//	Input.GetAxisRaw("Horizontal"),//aqui si vamos a hacer un moviemiento horizontal eje x, q devuelve -1 si presionamos a la izquierda y 1 a la derecha y 0 si no presionamos nada
		//	Input.GetAxisRaw("Vertical"),//aqui si vamos a hacer un moviemiento vertical eje y, q devuelve -1 si presionamos a la izquierda y 1 a la derecha y 0 si no presionamos nada
		//	0
		//);

		//cambiamos la posicion de nuestor objetos
		//creando un nuevo vector y con el metodo MoveTowards
		//transform.position = Vector3.MoveTowards (
		//	transform.position,//indicamos la posicion de nuestor objeot
		//	transform.position + movimiento,//hacia donde ceremos ir 
		//	speed * Time.deltaTime//y la velocidad
		//);
	}
	//metodo de las animaciones
	void Animacion(){
		if (movimiento != Vector2.zero) {
			//aqui le enviamos los valor a las varible q tiene los parametros de la animacion
			animacion.SetFloat ("MovX", movimiento.x);//le enviamos los nuevos parametros q deben de tener  en este caso buscamos el parametro MovX
			//q le asignamos el valor q tiene nuestro movimiento en el eje x 

			animacion.SetFloat ("MovY", movimiento.y);//aqui en este caso es el de MovY en el eje Y

			animacion.SetBool ("Caminando", true);//y aqui cambiamos el parametro q indica la animacion de caminado si es true el valor
		} else {
			animacion.SetBool ("Caminando", false);//y aqui cambiamos el parametro q indica la animacion de caminado si es false el valor no hace nada
		}
	}
	//metodo q hace q funciones la cuestion de los ataques
	void SworAttack(){
		//revisamos el status actual mirando la informacion del animator 
		AnimatorStateInfo stateInfo = animacion.GetCurrentAnimatorStateInfo (0);
		bool acttack = stateInfo.IsName ("Player_Attack");

		//aqui llamamso a la animacion Attack si presionamos la tecla x 
		if(Input.GetKeyDown("x") && !acttack){
			animacion.SetTrigger ("Attack");
		}


		//actualizacion de la poscion de la colision de nuestro actaque
		//comprobamos si el movimeitno es diferente de 0 (los valores q arroja son -1,1,0)
		//lo q indicamos es q si el vector de movimento es distien de q el movimiento
		if(movimiento !=Vector2.zero){
			//cambiamos la posicion del offset a nuestor collider
			//y lo dividemos entre 2 por q los valores son 1,-1
			acttackCollider.offset = new Vector2 (movimiento.x/2,movimiento.y/2);
		}

		//activamos la varible de colicion 
		//a la mitad de la animacion

		if(acttack){
			float playerbackTime = stateInfo.normalizedTime;//stateInfo.normalizedTime nos guarda cuanto tiempo hace q empiza la animacion
			//con un pequeño calculo devidimos esa animacion en tres partes
			//y mas o menos seria 0.33f
			//ahora acemdo una comprobacion q ese tiemp sea mayor q 0.22 y q no se pases de 0.44 osea q este mas o meno en la mitad
			//print(playerbackTime); si queremos ver el tiempo de moviemento
			if (playerbackTime > 0.24f && playerbackTime < 0.44f) {//y en esa fracion de tiempo hace
				acttackCollider.enabled = true;//activamos la colicion de actaque
			} else {
				acttackCollider.enabled = false;//desactivamos la colicion de actaqua
			}
		}
	}

	void SlangActtack(){
		//revisamos el status actual mirando la informacion del animator 
		AnimatorStateInfo stateInfo = animacion.GetCurrentAnimatorStateInfo (0);
		bool loading = stateInfo.IsName ("Player_Slang");

		//comprobamos si presiono la tecla z en mi caso
		if(Input.GetKeyDown("z")){
			
			animacion.SetTrigger ("Loading");//y aqui enviamos q haga el trigger de loading

			aura.AuraStart ();

		}else if(Input.GetKeyUp("z")){//ahoara si soltamos la tecla z 
			animacion.SetTrigger("Attack");
			if(aura.IsLoaded()){

				//consegimos la rotacion a partir de un vector
				//q va hacer en grados	
				//Mathf.Atan2 nos consigue apartir de un vectro de 2 dimenciones
				//la direcion donde esta mirando
				//despues buscamos el moviemtndo q esta almasedado en las varibles de animacion
				float angulo=Mathf.Atan2(
					animacion.GetFloat("MovY"),//animacion.GetFloat buscamos lo q esta almacenado
					animacion.GetFloat("MovX")
				) * Mathf.Rad2Deg;//Mathf.Rad2Deg combierte valores de radianos a grado
				//con eso ya tenso el angulo a q quermos q mire nuestro tajo o slang

				//se crea la instancia de Slang
				//se le pasa el objeto q vamos a instanciar
				//en nuestro caso la paosicion donde esta el jugador 
				//y la rotacion q se la pasamos con Quaternion.AngleAxis
				//q se la pasa el angulo y un vector3 q tenga una fuerza hacia adelante
				GameObject slanObj=Instantiate(
					slangPrefab,transform.position,
					Quaternion.AngleAxis(angulo,Vector3.forward)
				);

				//se otorga el moviemento inicial
				//recuperando el script del slang q lo controla 
				Controller_slang slang=slanObj.GetComponent<Controller_slang>();
				//y recupermso los valores del tajo con lo q tenosmos guardaro en las varibles de animacion q carga los movientos y se lo hacinamos
				slang.mov.x = animacion.GetFloat ("MovX");
				slang.mov.y = animacion.GetFloat ("MovY");
			}

			aura.AuraStop ();

			//esperar unos momentos y antes de hacer el ataque
			StartCoroutine(SegundoMovientos(0.4f));
		}

		//previeneidno el moviento miestras cargamos
		if (loading) {
			movimientoPrevent = true;
		} 
	}
	void Atacado(){
		print ("Resivistes daño");
	}
	//metodo q carga para q no s mueva el persoaje
	void MovientoPrevent(){
		if(movimientoPrevent){//si es verdadera movimientoPrevent
			movimiento = Vector2.zero;//el vector de movimiento va a ser 0 osea sin q se mueva	
		}
	}
	IEnumerator SegundoMovientos(float seconds){
		yield return new WaitForSeconds (seconds);
		movimientoPrevent = false;
	}
}
