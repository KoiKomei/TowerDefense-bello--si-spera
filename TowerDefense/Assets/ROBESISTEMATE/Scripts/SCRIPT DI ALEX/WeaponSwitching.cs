using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour {

    /*Si lavora coi figli degli oggetti qui, selectedWeapon indica un "figlio" dell'oggetto a cui è attaccato questo script*/

    public int selectedWeapon = 0;
    

    /*childCount è a -6 perché oltre alle armi ci sono le dita e quelle non dobbiamo contarle*/
	
	void Start () {
        SelectWeapon();
	}
	
	
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
