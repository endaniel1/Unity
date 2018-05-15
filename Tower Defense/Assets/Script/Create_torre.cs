using UnityEngine;
using System.Collections;

public class Create_torre : MonoBehaviour
{

	public GameObject prefabTorre_draw;

	// Use this for initialization
	public void CreateTowerDraw(){
		Instantiate (prefabTorre_draw);
	}
}

