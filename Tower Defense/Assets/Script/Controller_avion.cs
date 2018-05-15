using UnityEngine;
using System.Collections;

public class Controller_avion : MonoBehaviour
{

	public float hp=100f;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		

	}
	void Damage(int amount){
		hp-=amount;
		if(hp<=0){
			Destroy (gameObject);//destruimos la avioneta
		}
	}
}

