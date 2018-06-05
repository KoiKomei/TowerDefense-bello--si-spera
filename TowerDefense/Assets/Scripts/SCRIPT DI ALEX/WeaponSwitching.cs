using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour {

    public int selectedWeapon = 0;
    


	// Use this for initialization
	void Start () {
        SelectWeapon();
	}
	
	// Update is called once per frame
	void Update () {
       
        int previousWeapon = selectedWeapon;
        if (TPSMovement.isReloading == true)
            return;
        if (Input.GetAxis("Mouse ScrollWheel")>0f) {
            if (selectedWeapon >= transform.childCount - 6)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f) {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 6;
            else
                selectedWeapon--;
        }

        if (previousWeapon != selectedWeapon) {
            SelectWeapon();
        }
	    
	}

    void SelectWeapon() {
        int i = 0;
        foreach (Transform weapon in transform) {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);

            }
            else {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }

}
