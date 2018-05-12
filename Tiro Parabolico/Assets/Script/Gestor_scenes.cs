using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gestor_scenes : MonoBehaviour {

	public static Gestor_scenes instance = null;


	void Awake(){

		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		//de esta manere le decimos q no destruya el objeto cuando cambiemeos de sceneas
		DontDestroyOnLoad (this);

	}

	void Update(){
		if(Input.GetKeyDown("1")){
			
			CambuiarScene ("Portada");

		}else if(Input.GetKeyDown("2")){
			
			CambuiarScene ("Tiro_Parabolico");

		}else if(Input.GetKeyDown("3")){
			
			CambuiarScene ("Perder");

		}else if(Input.GetKeyDown("4")){
			
			CambuiarScene ("Ganar");
		}
	}


	public void CambuiarScene(string name){
		SceneManager.LoadScene (name);
	}
}
