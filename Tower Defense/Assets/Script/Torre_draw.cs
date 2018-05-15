using UnityEngine;
using System.Collections;

public class Torre_draw : MonoBehaviour
{

	public GameObject prefabTorreta;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{


		Vector2 mousePosition=Input.mousePosition;

		mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);

		transform.position = mousePosition;

		//print (mousePosition);

		//al hacer click se creara la trreta en la posicion de este objeto arrastrabele y se borrarar
		if(Input.GetMouseButtonUp(0)){
			
			Instantiate (prefabTorreta,transform.position,transform.rotation);
			Invoke ("DeleteInstance",0.01f);
		
		}

	}
	void DeleteInstance(){
		Destroy (gameObject);
	}

}

