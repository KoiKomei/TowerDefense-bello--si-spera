using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedWeapon : MonoBehaviour {

    [SerializeField] private Image weapon1;
    [SerializeField] private Image weapon2;
    [SerializeField] private Image weapon3;
    [SerializeField] private Image parentImage1;
    [SerializeField] private Image parentImage2;
    [SerializeField] private Image parentImage3;

    private int currentWeapon;
    public bool hasFirstGun;

	// Use this for initialization
	void Start () {
        hasFirstGun = false;
        currentWeapon = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasFirstGun) {
            if (parentImage1.gameObject.activeInHierarchy) {
                weapon1.gameObject.SetActive(true);
                hasFirstGun = true;
                currentWeapon = 0;
                Debug.Log("First Gun Taken");
            }
        }
        else if (Input.GetButtonDown("Weapon1")) selectFirstWeapon();
        else if (Input.GetButtonDown("Weapon2")) selectSecondWeapon();
        else if (Input.GetButtonDown("Weapon3")) selectThirdWeapon();
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
            nextWeapon();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
            previousWeapon();
        }
	}

    bool selectFirstWeapon() {
        if (parentImage1.gameObject.activeInHierarchy) {
            currentWeapon = 0;
            weapon1.gameObject.SetActive(true);
            weapon2.gameObject.SetActive(false);
            weapon3.gameObject.SetActive(false);
            return true;
        }
        return false;
    }

    bool selectSecondWeapon() {
        if (parentImage2.gameObject.activeInHierarchy) {
            currentWeapon = 1;
            weapon2.gameObject.SetActive(true);
            weapon1.gameObject.SetActive(false);
            weapon3.gameObject.SetActive(false);
            return true;
        }
        return false;
    }

    bool selectThirdWeapon() {
        if (parentImage3.gameObject.activeInHierarchy) {
            currentWeapon = 2;
            weapon3.gameObject.SetActive(true);
            weapon1.gameObject.SetActive(false);
            weapon2.gameObject.SetActive(false);
            return true;
        }
        return false;
    }

    void nextWeapon(){
        if (currentWeapon == 0) {
            if (selectSecondWeapon()){ } 
        }
        else if (currentWeapon == 1) {
            if (selectThirdWeapon()) { }
            else selectFirstWeapon();
        }
        else if (currentWeapon == 2) {
            selectFirstWeapon();
        }
    }

    void previousWeapon(){
        if (currentWeapon == 2) {
            if (selectSecondWeapon()){ } 
        }
        else if (currentWeapon == 0) {
            if (selectThirdWeapon()) { }
            else if (selectSecondWeapon()) { }
        }
        else if (currentWeapon == 1) {
            selectFirstWeapon();
        }
    }

    public int getSelectedWeapon() {
        return currentWeapon;
    }

    
}
