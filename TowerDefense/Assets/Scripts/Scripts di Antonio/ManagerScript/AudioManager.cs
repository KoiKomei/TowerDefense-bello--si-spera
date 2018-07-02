using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager {

    public ManagerStatus status { get; private set;}

    public float soundVolume {
        get { return AudioListener.volume; }
        set { AudioListener.volume = value; }
    }

    public bool soundMute {
        get { return AudioListener.pause; }
        set { AudioListener.pause = value; }
    }

    public float musicVolume {
        get { return musicSource.volume; }
        set { if (musicSource != null) {
                musicSource.volume = value;
            }
        }
    }

    public bool musicMute {
        get { if (musicSource != null) {
                return musicSource.mute;
            }
            return false;
        }
        set { if (musicSource != null) {
                musicSource.mute = value;
            }
        }
    }

    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private string Background;
    [SerializeField] private string Lose;
	[SerializeField] private string Win;

    public void Startup() {
        Debug.Log("Audio Manager Starting...");
        musicSource.ignoreListenerVolume = true;
        musicSource.ignoreListenerPause = true;
        soundVolume = PlayerPrefs.GetFloat("SFXVolume");
        musicVolume = PlayerPrefs.GetFloat("MusicVolume");
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
        PlayMusic((AudioClip) Resources.Load("Music/" + Background));
    }

    public void PlayLevelMusic() {
        PlayMusic((AudioClip) Resources.Load("Music/" + Lose));
    }

	public void PlayWinMusic() {
		PlayMusic((AudioClip)Resources.Load("Music/" + Win));
	}

    private void PlayMusic(AudioClip clip) {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopMusic() {
        musicSource.Stop();
    }
}
