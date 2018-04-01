using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemygenerator_controller : MonoBehaviour {

	public GameObject enemyPrefab;
	public float generatorTimer = 1.75f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//funcion q crea a los enemigos
	void CreateEnemy(){
		//resive el objeto(prefab) la psosicion y la toracion
		Instantiate (enemyPrefab,transform.position,Quaternion.identity);
	}
	//funcion de repetidor 
	public void StarGenerator(){
		//resive el nombre la funcion el tiempo y el tiempo de repeticion
		InvokeRepeating ("CreateEnemy",0f,generatorTimer);
	}
	//funcion q cancela a la creacion de los enemygos
	public void CancelGenerator(bool clean=false){
		CancelInvoke ("CreateEnemy");
		if(clean){//si la varible es verdadera ariamos un limpieza de los enemigos
			object[] allenemies = GameObject.FindGameObjectsWithTag ("Enemy");
			//se crea una varible tipo objeto en forma de arreglo
			//y se busca todos los objetos de la escena q tenga un el tag "Enemy" .FindGameObjectsWithTag ("Enemy");
			foreach(GameObject enemy in allenemies){
				Destroy (enemy);
			}
		}
	}
}
