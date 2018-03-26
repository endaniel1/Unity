using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class music_player : MonoBehaviour {

	public AudioClip[] clip;
	private int index=0;//variable para jugar con el indice de las canciones
	private AudioSource player;
	private Text title,time;
	private Animator animator;

	// Use this for initialization
	void Start () {
		player = GetComponent<AudioSource> ();
		player.clip=clip[index];

		title = transform.Find ("Title").gameObject.GetComponent<Text> ();
		//arriba buscamos el texto q es hijo de "music_player" q se llam "Title" y buscamos el componente Text
		title.text=player.clip.name;//aqui le pasamos a la variable "title" el nombre de la cancion q se esta escuchando

		time = transform.Find ("Time").gameObject.GetComponent<Text> ();
		animator=transform.Find ("Image").gameObject.GetComponent<Animator> ();
		animator.enabled = false;
	}

	//funcion para hacer q inicie la cancion
	public void Play(){
		if (ChekNullSong()) return;//aqui se llama a una funcion

		if (!player.isPlaying) {//comprovamos si se esta reproducion la musica con ".isPlaying"
			player.Play ();//funcion q se ejecuta para la musica cuando inica el juego
			animator.enabled = true;

			CancelInvoke ("Next");
			Invoke ("Next",player.clip.length - player.time + 1f);
		}else{
			player.Pause ();//funcion q pausa la cancion".Pause ()"
			animator.enabled = false;
			CancelInvoke ("Next");
		}
	}


	//funcion q detiene la cancion
	public void Stop(){
		player.Stop ();//funcion q para la cancion osea q vuelva desde un principo ".Stop ()"
		animator.enabled = false;
		CancelInvoke ("Next");
	}


	//funcion de la siguiente cancion
	public void Next(){
		player.clip=clip[++index % clip.Length];
		if (ChekNullSong()) return;//aqui se llama a una funcion
		player.Play ();//funcion q se ejecuta para la musica cuando inica el juego
		title.text=player.clip.name;//aqui le pasamos a la variable "title" el nombre de la cancion q se esta escuchando
		animator.enabled = true;

		CancelInvoke ("Next");
		Invoke ("Next",player.clip.length + 1f);
	}
	//funcion de la anterior cancion
	public void Prev(){
		if (--index < 0) index = clip.Length;
		player.clip=clip[index % clip.Length];
		if (ChekNullSong()) return;//aqui se llama a una funcion
		player.Play ();//funcion q se ejecuta para la musica cuando inica el juego
		title.text=player.clip.name;//aqui le pasamos a la variable "title" el nombre de la cancion q se esta escuchando
		animator.enabled = true;


		CancelInvoke ("Next");
		Invoke ("Next",player.clip.length + 1f);
	}


	// Update is called once per frame
	void Update () {
		int minutos = (int) player.time / 60;// ".time"funcion q tiene el tiempo de reproducin de un audio 
		//lo malo es q devuelve el timpo por segunddo, se divide entre "60" por q cada segundo vale un 1 
		//pero no lo da en flotantes por eso tranformamos ese valor en entero
		int segundos=(int) player.time % 60;

		//ahora cambiamos el texto
		time.text=minutos.ToString("00")+":"+segundos.ToString("00");//aqui cambiamos el texto del audio
		//cy cambiamos a las varibles de tipo "int" a "strings" con "ToString()"
	}
	//funcion q chequea si la cancion no existes o si su valor es null
	bool ChekNullSong(){
		if(player.clip== null){
			title.text="Pista no Encontrada";//aqui le pasamos a la variable "title" el nombre de la cancion q se esta escuchando
			animator.enabled = false;

			CancelInvoke ("Next");
			Invoke ("Next",3f);
			return true;

		}
		return false;



	}
}
