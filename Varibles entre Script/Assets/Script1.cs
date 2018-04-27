using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script1 : MonoBehaviour {

	public int numero=1;

	public void DevuelNumero(){
		print (numero);
	}
	public void ValorNumeroMultiplicar(int valor){
		numero *= valor;
	}
}
