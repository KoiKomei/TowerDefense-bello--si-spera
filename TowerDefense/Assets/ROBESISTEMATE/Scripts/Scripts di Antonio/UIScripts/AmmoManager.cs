using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour {

    InventoryManager inventory;
    WeaponManager weapon;

    [SerializeField] private Text currentAmmoText;
    [SerializeField] private Text totalAmmoText;

    // Use this for initialization
	void Start () {
        inventory = Managers.Inventory;
        weapon = Managers.Weapon;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (weapon.getCurrentWeapon() != null && weapon.changeWeapon) {
            currentAmmoText.text = weapon.getCurrentWeapon().getCurrentAmmo().ToString();
            if (inventory.GetAmmoDict().ContainsKey(weapon.getCurrentAmmoType())) {
                totalAmmoText.text = inventory.GetAmmoDict()[weapon.getCurrentAmmoType()].ToString();
            }
            else {
                totalAmmoText.text = "0";     
            }
        }
	}
}
