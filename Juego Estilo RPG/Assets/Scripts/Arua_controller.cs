using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arua_controller : MonoBehaviour {

	// Tiempo de precarga
	public float waitBeforePlay;

	Animator anim;//una varible de animacion q controla la animacion 
	Coroutine manager;//una varible corrutiana 
	bool loaded;//y una varible boleana q es la q tiene si se a ternimando de cargar o no

	void Start () {
		anim = GetComponent<Animator>();//aqui recuperams el componetne de animacion cuando incia el juego
	}

	public void AuraStart() {
		manager = StartCoroutine(Manager());
		anim.Play("Aura_idle");
	}

	public void AuraStop() {
		StopCoroutine(manager);
		anim.Play("Aura_idle");
		loaded = false;
	}

	// Método para comprobar si ya hemos cargado suficiente
	public IEnumerator Manager() {
		yield return new WaitForSeconds(waitBeforePlay);
		anim.Play("Aura_paly");
		loaded = true;
	}

	// Método para comprobar si ya hemos cargado suficiente
	public bool IsLoaded() {
		return loaded;
	}
}
