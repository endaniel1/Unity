using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//modulo para manejar objetos de GUI
using UnityEngine.SceneManagement;//modulo para manejar las scenas

public enum GameState{Idle,Playing,End,Ready};
public class gamer_controller : MonoBehaviour {

	[Range(0f,0.020f)]
	public float parallaxSpeed = 0.02f;
	public RawImage background;
	public RawImage planform;
	public GameObject ui_idle;
	public GameObject ui_point;


	public GameState gameState = GameState.Idle;

	public GameObject player;//varible de objeto q tiene al jugador
	public GameObject enemygenerator;//varible de objeto q tiene al enemigo

	public AudioSource musicPlayer;

	//varibles del tiempo del juego
	public float scaleTime = 6f;//tiempo de scala
	public float scaleInc = 0.25f;//tiempo de scala inicial

	private int point = 0;//varible q tiene los puntos a incrementar
	public Text pointText;
	public Text recordText;

	// Use this for initialization
	void Start () {
		musicPlayer = GetComponent<AudioSource> ();
		recordText.text = "Record: " + GameMaxScore ().ToString ();
	}
	
	// Update is called once per frame
	void Update () {

		bool userAction = Input.GetKeyDown ("up") || Input.GetMouseButtonDown (0);
		//cuando el juego empieza empieza el juego
		if(gameState == GameState.Idle && userAction){
			gameState = GameState.Playing;
			ui_idle.SetActive (false);//desactiva el objeto 
			ui_point.SetActive (true);//activamos el objeto de point o de puntos
			player.SendMessage("UpdateState","playerrun");//mandamos a llamar a la funcion q tenemos en el otro script
			//le pasamos el nombre y el valor q en este caso es la animacion 
			enemygenerator.SendMessage("StarGenerator");//mandamos a llamar a la funcion q tenemio ene el otro script
			//q le mandamos un mensaje q nos llame a la funcion "StarGenerator"
			musicPlayer.Play();//inicia la musica del juego
			InvokeRepeating("GameScaleTime",scaleTime,scaleTime);//acemos un llamado la funcion
			//se la pasa los segundo de retraso q en este caso son 6 y se le llama cada 6 segundo
			player.SendMessage("CorrePlay");//mandamos a llamar a la funcion de "CorrePlay" desde aqui
		}//juego en marcha
		else if(gameState == GameState.Playing){
			Parallax ();
		}
		//juego preparado para reiniciarse
		else if(gameState == GameState.Ready){
			if(userAction){
				RestarGame ();//funcion q reinicia el juego cuando se acaba
			}
		}
	}
	//funcion q hace el efecto de parallax
	void Parallax(){
		float finalSpeed = parallaxSpeed * Time.deltaTime;
		background.uvRect = new Rect (background.uvRect.x + finalSpeed,0f,1f,1f);
		planform.uvRect = new Rect (planform.uvRect.x + finalSpeed * 4,0f,1f,1f);
	}
	//funcion de reinicio de juego
	public void RestarGame(){
		ResetScaleTime ();//se llama a la funcion de reinicio de escala
		SceneManager.LoadScene ("Juego");//cargamos otra scena q en nuestro caso seria la del mismo juego
	}
	//funcion de escala del tiempo de juego
	void GameScaleTime(){
		Time.timeScale += scaleInc;//q la suma del tiempo de escala se valla incrmentando por el tiempo incial q definimos
		Debug.Log ("rimot incrmentado "+Time.timeScale.ToString());

	}
	//funcion q restablece la velocidad del juego
	//cuando se mueraa ya q si no se cambia cuando se vuelva e empezar el juego esto no le afetara a la invocacion de veleocida
	public void ResetScaleTime(float newTimerScale=1f){
		CancelInvoke ("GameScaleTime");//canle la invocaion de la funcion
		Time.timeScale = 1f;//tiempo de scala es de 1
		Debug.Log ("ritmo restablecido "+Time.timeScale.ToString());
	}
	//funcion q incrementa los puntos
	public void IncremtPoint(){
		pointText.text = (++point).ToString ();//cambia el texto para incrementar los puntos
		if(point>=GameMaxScore()){//aqui si es mayor a los puntos guardados 
			recordText.text = "Record: " + point.ToString ();//muestra aqui el puntaje 
			SaveScore (point);//aqui llama a la funcion q los guarda
		}
	}
	//funcion donde se obtiene la maxima puntacion es un GET
	public int GameMaxScore(){
		return PlayerPrefs.GetInt ("Puntación Maxima ",0);
	}
	public void SaveScore(int currentPoint){
		PlayerPrefs.SetInt ("Maxima Puntuación",currentPoint);
	}
}
