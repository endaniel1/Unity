using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum States{Idle,Attack}

public class Controller_torre : MonoBehaviour {

	//Animator anim;

	public float rotationSpeed=2f;

	GameObject target;
	public GameObject prefabsBole,canonLeft,canonRight;

	States state;



	// Use this for initialization
	void Start () {
		target = null;
		//anim = GetComponent<Animator> ();
		StartCoroutine (Disparar ());

	}
	
	// Update is called once per frame
	void Update () {

		if (target == null) {
			
		} 

	}


	void FixedUpdate () {
		//si hay target miramos el objetivo

		if(target==null){
			transform.Rotate (new Vector3(0f,0f,rotationSpeed));

			//	transform.rotation =  Quaternion.Euler (0f, 0f, transform.rotation.z + rotationSpeed);

		}else if(target!=null){
			//print ("mirando al objetivo");
			float angle = Geometry.AngeBetweenVector (transform.position,target.transform.position);
			transform.rotation = Quaternion.Euler (0f,0f,angle-90f);
			//print (angle);
		}

	}

	IEnumerator Disparar() {
		while(true){
			if (target != null) {
				Instantiate (prefabsBole, canonLeft.transform.position, transform.rotation);
				Instantiate (prefabsBole, canonRight.transform.position, transform.rotation);
			}
			yield return new WaitForSeconds(1f);
		}

	}

	void OnTriggerStay2D(Collider2D col){

		if(target==null && col.CompareTag("Enemy")){
			//anim.SetBool ("Attack",true);
			target = col.gameObject;
		}

		if(col.CompareTag("Enemy")){
			//print ("Enemy encontrado");
		}

	}

	void OnTriggerExit2D(Collider2D col){

		//cuando se sale un enemigo del radio de ataque
		//comprabamos si su id de instancia es el mismo
		//q el del target y si lo es desactivamo el target


		if(target!=null){
			if( target.GetInstanceID() ==  col.gameObject.GetInstanceID()){
				//anim.SetBool ("Attack",false);
				target=null;
			}
		}
	

	}

	//esto pone lenteja la pc pero sirve como guia para ve a donde esta apuntando la torreta
	/*void OnDrawGizmosSelected(){
		if(target!=null){
			Gizmos.color = Color.blue;
			Gizmos.DrawLine (transform.position,target.transform.position);
		}

	}*/


}
