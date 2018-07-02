using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    [SerializeField] private SettingsPopup settingsPopup;
    [SerializeField] private InventoryPopup inventoryPopup;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Text healthLabel;
    [SerializeField] private Slider payloadHealthBar;
    [SerializeField] private Text payloadHealthLabel;
	[SerializeField] private Text lost;


	private bool isSettingsPopupOpen = false;
    private bool isInventoryPopupOpen = false;
    public static bool isPaused = false;
    // Use this for initialization
    void Start () {
        LockCursor();
        initializeUI();
        isPaused = false;
	}

    // Update is called once per frame
    void Update()
    {
        healthLabel.text = healthBar.value.ToString();
        payloadHealthLabel.text = payloadHealthBar.value.ToString();
        manageSettingsPopup();
    }
    
    private void manageSettingsPopup() {

        //Apertura e Chiusura Menu
        if (Input.GetButtonDown("Cancel") && !isSettingsPopupOpen)
        {
            isSettingsPopupOpen = true;
            OnOpenSettings();
            UnlockCursor();
            isPaused = true;
        }
        else if (Input.GetButtonDown("Cancel") && isSettingsPopupOpen)
        {
            isPaused = false;
            isSettingsPopupOpen = false;
            OnCloseSettings();
            if (!isSettingsPopupOpen && !isInventoryPopupOpen) LockCursor();
        }

        //Apertura e Chiusura Inventario
        if (Input.GetButtonDown("Inventory") && !isInventoryPopupOpen)
        {
            isInventoryPopupOpen = true;
            OnOpenInventory();
            UnlockCursor();
        }
        else if (Input.GetButtonDown("Inventory") && isInventoryPopupOpen)
        {
            isInventoryPopupOpen = false;
            OnCloseInventory();
            if (!isSettingsPopupOpen && !isInventoryPopupOpen) LockCursor();
        }
    }

    private void initializeUI() {
        settingsPopup.Close();
    }

    private void OnOpenSettings() {
        settingsPopup.Open();
    }

    private void OnCloseSettings() {
        settingsPopup.Close();
    }

    private void OnOpenInventory()
    {
        inventoryPopup.Open();
    }

    private void OnCloseInventory()
    {
        inventoryPopup.Close();
    }

    private void LockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    private void UnlockCursor() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void MainMenuScene() {

        Debug.Log("premuto");
        //PlayerPrefs.SetInt("scene", 3);
        SceneManager.LoadScene("Menu_Scene");
    }

    public void ExitScene() {

        Application.Quit();
    }
	
	private void lose1()
	{

		lost.text = "SEI MORTO";
		isSettingsPopupOpen = true;
		OnOpenSettings();
		UnlockCursor();
		isPaused = true;
	}
	private void lose2()
	{
		lost.text = "IL CARICO E' STATO DISTRUTTO";
		isSettingsPopupOpen = true;
		OnOpenSettings();
		UnlockCursor();
		isPaused = true;
	}
	private void win()
	{
		lost.text = "HAI VINTO!";
		isSettingsPopupOpen = true;
		OnOpenSettings();
		UnlockCursor();
		isPaused = true;
	}

}
