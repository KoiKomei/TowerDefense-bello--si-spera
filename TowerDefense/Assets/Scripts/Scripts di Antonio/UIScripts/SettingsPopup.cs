﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopup : MonoBehaviour, IDisplayableUIObject {

    [SerializeField] private AudioClip sound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Open() {
        this.gameObject.SetActive(true);
    }

    public void Close() {
        this.gameObject.SetActive(false);
    }

    public void OnSoundToggle() {
        Managers.Audio.PlaySound(sound);
        Managers.Audio.soundMute = !Managers.Audio.soundMute;
    }

    public void OnSoundValue (float volume) {
        Managers.Audio.soundVolume = volume;
    }

    public void OnMusicToggle() {
        Managers.Audio.PlaySound(sound);
        Managers.Audio.musicMute = !Managers.Audio.musicMute;
    }

    public void OnMusicValue (float volume) {
        Managers.Audio.musicVolume = volume;
    }
    
    public void OnPlayMusic(int selector) {
        Managers.Audio.PlaySound(sound);
        switch (selector) {
            case 1:
                Managers.Audio.PlayIntroMusic();
                break;
            case 2:
                Managers.Audio.PlayLevelMusic();
                break;
            default:
                Managers.Audio.StopMusic();
                break;
        }
    }

}
