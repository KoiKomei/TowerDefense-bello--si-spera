using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager {

    public ManagerStatus status { get; private set;}

    public float soundvolume {
        get { return AudioListener.volume; }
        set { AudioListener.volume = value; }
    }

    public bool soundMute {
        get { return AudioListener.pause; }
        set { AudioListener.pause = value; }
    }

    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private string introBGMusic;
    [SerializeField] private string levelBGMusic;

    public void Startup() {
        Debug.Log("Audio Manager Starting...");
        soundvolume = 1f;
        status = ManagerStatus.Started;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySound(AudioClip clip) {
        soundSource.PlayOneShot(clip);
    }

    public void PlayIntroMusic() {
        PlayMusic((AudioClip) Resources.Load("Music/" + introBGMusic));
    }

    public void PlayLevelMusic() {
        PlayMusic((AudioClip) Resources.Load("Music/" + levelBGMusic));
    }

    private void PlayMusic(AudioClip clip) {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopMusic() {
        musicSource.Stop();
    }
}
