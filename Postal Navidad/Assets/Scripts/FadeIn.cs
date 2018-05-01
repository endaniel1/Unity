using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeIn : MonoBehaviour {

    public float wait, duration; 
    public AudioSource audio;
    Text text;

	void Start () {
        text = GetComponent<Text>();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        StartCoroutine(Run());
    }

    IEnumerator Run(){
        yield return new WaitForSeconds(wait);
        text.DOFade(1, duration);
        if (audio != null) audio.Play();
    }
}
