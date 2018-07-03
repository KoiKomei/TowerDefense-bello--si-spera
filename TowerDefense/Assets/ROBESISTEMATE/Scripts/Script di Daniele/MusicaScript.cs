using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaScript : MonoBehaviour {

    AudioSource musica;

	// Use this for initialization
	void Start () {
        Debug.Log("start music");
        //musica = GetComponent<AudioSource>();
        //musica.volume = PlayerPrefs.GetFloat("MusicVolume");

    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("update musica");
		if (UIController.isPaused)
        {
           // musica.volume = PlayerPrefs.GetFloat("MusicVolume");
            Debug.Log(PlayerPrefs.GetFloat("MusicVolume")+"volumeset");
        }
	}
}
