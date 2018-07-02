using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidersAudios : MonoBehaviour {

    public GameObject musicSlider;
    public GameObject sfxSlider;

    private float sliderValue = 0.0f;
    private float sliderValueSFX = 0.0f;

    // Use this for initialization
    void Start () {
        musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("SFXVolume");
    }
	
	// Update is called once per frame

    public void Update()
    {
        sliderValue = musicSlider.GetComponent<Slider>().value;
        sliderValueSFX = sfxSlider.GetComponent<Slider>().value;
        MusicSlider();
        SFXSlider();
    }


    public void MusicSlider()
    {
        //Debug.Log("qui1");
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
        //Debug.Log("music"+sliderValue);
    }

    public void SFXSlider()
    {
        //Debug.Log("qui2");
        PlayerPrefs.SetFloat("SFXVolume", sliderValueSFX);
        //Debug.Log("sfx" + sliderValue);
    }
}
