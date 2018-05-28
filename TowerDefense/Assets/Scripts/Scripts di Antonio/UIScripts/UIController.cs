using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    [SerializeField] private SettingsPopup settingsPopup;
    [SerializeField] private WeaponTooltip revolverImage;
    [SerializeField] private WeaponTooltip m4Image;
    [SerializeField] private WeaponTooltip shotgunImage;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Text healthLabel;

    private bool isPopupOpen = false;

	// Use this for initialization
	void Start () {
        LockCursor();
        initializeUI();
	}

    // Update is called once per frame
    void Update()
    {
        healthLabel.text = healthBar.value.ToString();
        manageSettingsPopup();
    }
    
    private void manageSettingsPopup() {
        if (Input.GetButtonDown("Cancel") && !isPopupOpen)
        {
            isPopupOpen = true;
            OnOpenSettings();
            UnlockCursor();
        }
        else if (Input.GetButtonDown("Cancel") && isPopupOpen)
        {
            isPopupOpen = false;
            OnCloseSettings();
            LockCursor();
        }
    }

    private void initializeUI() {
        settingsPopup.Close();
        revolverImage.Close();
        m4Image.Close();
        shotgunImage.Close();
    }

    private void OnOpenSettings() {
        settingsPopup.Open();
    }

    private void OnCloseSettings() {
        settingsPopup.Close();
    }

    private void LockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void UnlockCursor() {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void RestartScene() {
        SceneManager.LoadScene("Game");
    }

    public void MainMenuScene() {
        SceneManager.LoadScene("Menu_Scene");
    }

    public void ExitScene() {
        SceneManager.LoadScene("TestAnt");
    }
	
	
}
