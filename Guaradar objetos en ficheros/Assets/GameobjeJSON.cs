using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameobjeJSON : MonoBehaviour {

	string filePath;
	string jsonString;

	void Awake(){
		filePath=Application.dataPath + "/Persona.json";
		jsonString = File.ReadAllText (filePath);
		Persona persona = JsonUtility.FromJson<Persona> (jsonString);
		print (persona);

		persona.nivel = 5;
		jsonString = JsonUtility.ToJson (persona);
		File.WriteAllText (filePath, jsonString);

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
[System.Serializable]
public class Persona{
	public string nombre;
	public string profesion;
	public int nivel;

	public override string ToString ()
	{
		return string.Format ("{0}: {1} nivel {2}",nombre,profesion,nivel);
	}
}
