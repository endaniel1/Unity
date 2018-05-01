using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;//libreria de manejo de fichero de c#

public class GameobjeJSON : MonoBehaviour {

	string filePath;//varible tipo cadena q tiene el directorio del fichero (archivo)
	string jsonString;//varible tipo cadena en donde vamos a cargar o importar el fichero

	//es el metodo para cargar ficheros o datos maxivo y q se ejecuta antes de q inicie el juego
	void Awake(){
		filePath=Application.dataPath + "/Personas.json";//con esta linea recuperamos la ruta del fichero o en en este caso la guardamos en la varible
		jsonString = File.ReadAllText (filePath);//File.ReadAllText lee el texto q hay en el fichero y q lo devuelve a la cadena q nosotros estamos guardando osea la varible
		//creamos un objeto de tipo JSON a partir de nustro jsonString q es q carga nuestro archivo
		//creamos un objeto de tipo Persona 
		//llamaos a la libreria JsonUtility y a su metodo FromJson
		//en <> le indicamos el tipo de objeto serialisable q queremos utilizar en nuestro caso es Persona
		//y () le indicamos en donde tenemos q importarlo q es desde jsonString q carga la ruta
		//Persona persona = JsonUtility.FromJson<Persona> (jsonString);
		//
		//print (persona);//aqui mostramos para ver los datos

		//ya q tenemos guardado datos de nuestro personaje en nuestro Json
		//aqui vamos a editar sus datos
		//persona.nivel = 5;//aqui y asi editamos en este caso su nivel
		//en este cas sobreesrcibimos nuestra cadena q cargga jsonString 
		//jsonString = JsonUtility.ToJson (persona);//JsonUtility.ToJson tranformama el objeto a una cadena en JSON para poder escribirla en el fichero 
		//y pasamos el objeto serializable q es la varible persona
		//ahora tenemso q escribierlo en el fichero 
		//aciendo uso de la clase File y su metos WriteAllText
		//File.WriteAllText (filePath, jsonString);//resive como parametor la ruta del archivo filePath y lo q quermeos q se escriba q en nuestro caso es lo q tiene la varible jsonString


		//EN VEZ DE CREAR UNA VARIBLE TIPO Persona crearemos una de tipo listo
		//esto es para la lectura
		ListaPersonas listapersona = JsonUtility.FromJson<ListaPersonas> (jsonString);// en este caso le pasaremos la clase de ListaPersonas
		listapersona.Lista();//aqui nos acemos referencia a la clase listapersona y a su meto Lista

		//try es para a q al moemento de eejcutar este codigo q si no da error lo caturamos
		try{
			//para editar los datos 
			listapersona.personas.Find(p => p.nombre == "Enriquee").profesion="Programos en PHP";//con Find buscamos un dato
			//p indica al la persoan lo buscamos por su nombre q en este caso Enrique y despues le asignamos q a su profescion otro valor

			//aqui es para sobreescribir el fichero
			jsonString=JsonUtility.ToJson(listapersona);
			File.WriteAllText (filePath,jsonString);
		
		}catch(System.NullReferenceException e){//aqui si la referencia es nula entonces es porque no existe la persona
			print ("Persona no encontrada \n" + e);//mensaje q mostramos q dice q no exixiste
		}


	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

//creamos una clase q tenga los datos q guardamos en nuestro fichero q sea serialisable
//y se tiene q llamar igual y exactamente como esta escrito en nuestro fichero.s
[System.Serializable]//aqui decimos q la clases es serialisable
//esta class guarada los datos de una sola persona 
public class Persona{
	//los camopos tienen q se publicos para poder usarlos externamente
	public string nombre;
	public string profesion;
	public int nivel;

	//reescribimos los datos de nuestra clase q carga los datos de nuestro JSON
	public override string ToString ()
	{
		//{0} {1 {2}} ES EL ORDEN DE COMO SE ENCUENTRA EN EL JSON y despues le indicmaos a q esta haciendo referencia 
		return string.Format ("{0}: {1} nivel {2}",nombre,profesion,nivel);
	}
}

//esta clase guarda la lista de varias personas 
[System.Serializable]
public class ListaPersonas{
	public List<Persona> personas;//creamos una varible tipo lista q se llama Persona q va a guardar la lista de persona
	//es muy importante q el nombre de la varible sea igual al de la lista de nuestro JSON 

	//si quermos ver los datos o en nuestro caso flitrarlos
	//creasmo un metodo dentro de nuestra clase

	public void Lista(){
		//con el ciclo foreach nos paseaamos para cada elemento
		//le indicamos q vamos a recorrer un persona
		//dentro de la lista de persona de cada iteracion
		foreach(Persona persona in personas){
			//y no se utiliza print porque es algo q utiliza en la clase de MonoBehaviour osea de unity
			Debug.Log (persona);//y asi lo mostraremos por pantalla
			//esot automaticamente va a busacar la cadena q se genera al mostrar por pantalla a una persona
		}

	}

}
