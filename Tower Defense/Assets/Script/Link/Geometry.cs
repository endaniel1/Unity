using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geometry : MonoBehaviour {

	public static float AngeBetweenVector(Vector2 vect1,Vector2 vect2){
		Vector2 dif = vect2 - vect1;
		float angle = Vector2.Angle (Vector2.right,dif);
		float sing = (vect2.y < vect1.y) ? -1.0f : 1.0f;
		//Debug.Log (angle);
		return angle *sing;
	}
}
