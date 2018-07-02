using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsMenuNew : MonoBehaviour {

	// toggle buttons

	public GameObject showhudtext;
	public GameObject tooltipstext;
	public GameObject difficultynormaltext;
	public GameObject difficultynormaltextLINE;
	public GameObject difficultyhardcoretext;
	public GameObject difficultyhardcoretextLINE;
	

	// sliders
	public GameObject musicSlider;
	public GameObject sfxSlider;
	
	

	private float sliderValue = 0.0f;
	private float sliderValueSFX = 0.0f;
	

	public void  Start (){
		// check difficulty
		if(PlayerPrefs.GetInt("NormalDifficulty") == 1){
			//difficultynormaltext.GetComponent<Text>().text = "NORMAL";
			difficultynormaltextLINE.gameObject.SetActive(true);
			difficultyhardcoretextLINE.gameObject.SetActive(false);
			//difficultyhardcoretext.GetComponent<Text>().text = "hardcore";
		}
		else
		{
			//difficultynormaltext.GetComponent<Text>().text = "normal";
			//difficultyhardcoretext.GetComponent<Text>().text = "HARDCORE";
			difficultyhardcoretextLINE.gameObject.SetActive(true);
			difficultynormaltextLINE.gameObject.SetActive(false);

		}

		// check slider values
		musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume");
		sfxSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("SFXVolume");
	}

	public void  Update (){
		sliderValue = musicSlider.GetComponent<Slider>().value;
		sliderValueSFX = sfxSlider.GetComponent<Slider>().value;
        MusicSlider();
        SFXSlider();
	}


	public void  MusicSlider (){
		PlayerPrefs.SetFloat("MusicVolume", sliderValue);
       // Debug.Log(sliderValue);
	}

	public void  SFXSlider (){
		PlayerPrefs.SetFloat("SFXVolume", sliderValueSFX);
	}


	// the playerprefs variable that is checked to enable hud while in game
	public void  ShowHUD (){
		if(PlayerPrefs.GetInt("ShowHUD")==0){
			PlayerPrefs.SetInt("ShowHUD",1);
			showhudtext.GetComponent<Text>().text = "on";
		}
		else if(PlayerPrefs.GetInt("ShowHUD")==1){
			PlayerPrefs.SetInt("ShowHUD",0);
			showhudtext.GetComponent<Text>().text = "off";
		}
	}

	// show tool tips like: 'How to Play' control pop ups
	public void  ToolTips (){
		if(PlayerPrefs.GetInt("ToolTips")==0){
			PlayerPrefs.SetInt("ToolTips",1);
			tooltipstext.GetComponent<Text>().text = "on";
		}
		else if(PlayerPrefs.GetInt("ToolTips")==1){
			PlayerPrefs.SetInt("ToolTips",0);
			tooltipstext.GetComponent<Text>().text = "off";
		}
	}

	public void  NormalDifficulty (){
		//difficultynormaltext.GetComponent<Text>().text = "NORMAL";
		//difficultyhardcoretext.GetComponent<Text>().text = "hardcore";
		difficultyhardcoretextLINE.gameObject.SetActive(false);
		difficultynormaltextLINE.gameObject.SetActive(true);
		PlayerPrefs.SetInt("NormalDifficulty",1);
		PlayerPrefs.SetInt("HardCoreDifficulty",0);
	}

	public void  HardcoreDifficulty (){
		//difficultynormaltext.GetComponent<Text>().text = "normal";
		//difficultyhardcoretext.GetComponent<Text>().text = "HARDCORE";
		difficultyhardcoretextLINE.gameObject.SetActive(true);
		difficultynormaltextLINE.gameObject.SetActive(false);
		PlayerPrefs.SetInt("NormalDifficulty",0);
		PlayerPrefs.SetInt("HardCoreDifficulty",1);
	}

}