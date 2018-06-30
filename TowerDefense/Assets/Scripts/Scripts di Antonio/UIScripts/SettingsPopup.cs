using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour, IDisplayableUIObject {

    [SerializeField] private AudioClip sound;
    public GameObject Player;
    public GameObject PlayerCamera;

    // Use this for initialization
    void Start() {

    }
	
	// Update is called once per frame
	void Update () {

    }

    public void Open() {
        this.gameObject.SetActive(true);
        Player.GetComponent<TPSMovement2>().enabled = false;
        Player.GetComponent<Mouselook>().enabled = false;
        PlayerCamera.GetComponent<Mouselook>().enabled = false;
    }

    public void Close() {
        Player.GetComponent<TPSMovement2>().enabled = true;
        Player.GetComponent<Mouselook>().enabled = true;
        PlayerCamera.GetComponent<Mouselook>().enabled = true;
        this.gameObject.SetActive(false);
    }

    public void OnSoundValue (float volume) {
        Managers.Audio.soundVolume = volume;
    }

    public void OnMusicValue (float volume) {
        Managers.Audio.musicVolume = volume;
    }

    public void MainMenuScene()
    {
        PlayerPrefs.SetInt("scene", 3);
    }

    public void ExitScene()
    {
        Application.Quit();
    }


}
