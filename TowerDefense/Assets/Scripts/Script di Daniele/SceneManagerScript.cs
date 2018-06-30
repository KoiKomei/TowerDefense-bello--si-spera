using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("scene", 0);
        
	}
	
	// Update is called once per frame
	void Update () {

        loadGame();
        loadMenu();
        
	}

    void loadGame()
    {
        if (PlayerPrefs.GetInt("scene") == 1)
        {
            Debug.Log("loading game");
            SceneManager.UnloadSceneAsync("Menu_Scene");
            SceneManager.LoadScene("game", LoadSceneMode.Additive);
            PlayerPrefs.SetInt("scene", 2);

        }
    }

    void loadMenu()
    {
        if (PlayerPrefs.GetInt("scene") == 0)
        {
            Debug.Log("loading menu");
            SceneManager.LoadScene("Menu_Scene", LoadSceneMode.Additive);
            
            PlayerPrefs.SetInt("scene", 2);
           // SceneManager.UnloadSceneAsync("game");
        }
    }
}
