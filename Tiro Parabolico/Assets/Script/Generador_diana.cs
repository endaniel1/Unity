using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generador_diana : MonoBehaviour
{
	public int marcador=0,repeticiones=5,segundos;
	public GameObject prefaDiana,segunderos;
	GameObject dianaActual;

	Coroutine cSegundero;

	bool finJuego=false;


	[SerializeField]
	public Vector3 p1,p2,p3,p4;


	// Use this for initialization
	void Start ()
	{
		StartCoroutine ( Generar(repeticiones,segundos) );
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(finJuego){
			if (marcador == repeticiones) {
				Gestor_scenes.instance.CambuiarScene ("Ganar");
			} else {
				Gestor_scenes.instance.CambuiarScene ("Perder");
			}
		}

	}

	IEnumerator Segundero(float seg){
		for (var i = 0; i < seg; i++) {
			segunderos.GetComponent<Text> ().text=(seg-i).ToString();	
			yield return new WaitForSeconds (1f);
		}
	}


	IEnumerator Generar(int rep,float seg){
		for(var i=0; i<rep ; i++){
					
			//print ("Creando Diana"+i.ToString());
			GeneradorDianaAleatoria (segundos);

			yield return new WaitForSeconds (seg);
		}
		finJuego = true;
	}

	void GeneradorDianaAleatoria(int seg){

		//borrar la actual
		if (dianaActual != null) {
			Destroy (dianaActual.gameObject);
			StopCoroutine (cSegundero);
		}
		float x=Random.Range(p1.x,p2.x);
		float y = Random.Range (p3.y,p2.y);

		dianaActual= Instantiate (prefaDiana,
			new Vector3( x , y ,0),
			transform.rotation);


		//iniciar segundero
		cSegundero= StartCoroutine(Segundero(seg));
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = new Color (1f , 0f , 0f , 0.1f);
		Gizmos.DrawCube(transform.position, new Vector3 (
			p2.x-p1.x,p2.y-p3.y,1));

	}
	void SumarPuntos(){
		marcador++;
	}

}

