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
        loadMenuFromGame();
    }

    void loadGame()
    {
        if (PlayerPrefs.GetInt("scene") == 1)
        {
            Debug.Log("loading game");
            SceneManager.UnloadScene("Menu_Scene");
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
            //SceneManager.UnloadScene("game");
            PlayerPrefs.SetInt("scene", 2);
        }
    }

    void loadMenuFromGame()
    {
        if (PlayerPrefs.GetInt("scene") == 3)
        {
            Debug.Log("loading menu");
            SceneManager.UnloadScene("game");
            SceneManager.LoadScene("Menu_Scene", LoadSceneMode.Additive);
            PlayerPrefs.SetInt("scene", 2);
        }
    }
}
