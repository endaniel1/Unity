using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller_player : MonoBehaviour {
	//varible de animacion
	private Animator animator;//variable Animator q tiene la animacion
	//varibles de gameobject
	public GameObject game;//variable q tiene al jugador q vamos a importar sus funcionalidades desde el otro script
	public GameObject enemygenration;
	//de audio
	private AudioSource audioPlayer;
	public AudioClip jump_clip;
	public AudioClip point_clip;
	public AudioClip die_clip;

	private float startY;

	public ParticleSystem corre;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();//obtenemos el componente de la animacion cuando inicia el juego
		audioPlayer=GetComponent<AudioSource>();
		startY = transform.position.y;//posicion inicil del personaje con respecto al suelo osea cuando se empieza
	}
	
	// Update is called once per frame
	void Update () {
		bool Esta_Suelo=transform.position.y ==startY;
		//comprobamos la posicion del juego inical con la q estamos actualmente
		bool GamePlaying = game.GetComponent<gamer_controller> ().gameState == GameState.Playing;
		//comprobamos aqui el estado en el q andamos 
		bool usserAction=Input.GetKeyDown("up") || Input.GetMouseButtonDown(0);
		//si presionamos las tecla de arriba o la de raton

		//comprobamos si la psocion incial del juego es igual al q cambiamos
		//si el estado del juego es diferente a el de "Play"
		//y si presionamos las teclas
		if( Esta_Suelo && GamePlaying && usserAction){
			UpdateState ("Player_jump");

			audioPlayer.clip = jump_clip;
			audioPlayer.Play ();
		}
	}

	//funcion q cambia el estado de la animacion
	public void UpdateState(string states=null){
		if(states!=null){
			animator.Play (states);//cambiamos la animacion por la q le estamos enviando desde el otro scritp
		}
	}
	//funcion q decteta una colicion
	void OnTriggerEnter2D(Collider2D other){//le pasamos un "Collider2D" y "other" q quiere decir el otro
		if(other.gameObject.tag=="Enemy"){//comparamos si el "tag" del objeto q en este caso es "other"es "Destroyer"
			UpdateState ("player_dei");
			game.GetComponent<gamer_controller> ().gameState = GameState.End;
			//busca el estado del juego q en este caso es "End" de otro script q en este caso se llama "gamer_controller" 
			enemygenration.SendMessage("CancelGenerator",true);

			game.SendMessage ("ResetScaleTime",0.5f);

			//audio
			game.GetComponent<AudioSource> ().Stop();//entramos al componente de audio y paramos la musica
			audioPlayer.clip = die_clip;//cambiamos el componte clip por el de die_clip
			audioPlayer.Play ();//aqui ponemos en marcha la musica
			CorrerStop();//para parar la animacion de correr
		}else if(other.gameObject.tag=="Point"){//si chocamos o pasamos por el tag q se llama "Point"
			game.SendMessage ("IncremtPoint");//mandamos un mensaje q se ejecute la funcion "IncremtPoint"
			//audio
			audioPlayer.clip = point_clip;//cambiamos el componte clip por el de point_clip
			audioPlayer.Play ();//aqui ponemos en marcha la musica
		}
	}
	//funcion del juego esta listo
	void GameReady(){
		game.GetComponent<gamer_controller> ().gameState = GameState.Ready;
	}

	void CorrePlay(){
		corre.Play ();
	}
	void CorrerStop(){
		corre.Stop ();
	}
}
