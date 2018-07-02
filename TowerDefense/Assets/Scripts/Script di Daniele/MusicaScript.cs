using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaScript : MonoBehaviour {

    AudioSource musica;

	// Use this for initialization
	void Start () {

        musica = GetComponent<AudioSource>();
        musica.volume = PlayerPrefs.GetFloat("MusicVolume");

    }
	
	// Update is called once per frame
	void Update () {

		
	}
}
