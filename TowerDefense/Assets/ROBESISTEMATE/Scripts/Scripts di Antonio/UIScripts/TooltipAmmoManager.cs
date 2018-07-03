using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipAmmoManager : MonoBehaviour {

    InventoryManager inventory;
    [SerializeField] private List<Text> ammoTexts;

	// Use this for initialization
	void Start () {
        inventory = Managers.Inventory;
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < ammoTexts.Count; i++) {
            if (ammoTexts[i].gameObject.activeInHierarchy) {
                string name = inventory.GetWeaponsList()[i];
                string ammo = ""; int value = 0;
                if (name.StartsWith("m4")){
                    ammo = "heavyammo";
                }
                else if (name.StartsWith("revolver")){
                    ammo = "lightammo";
                }
                else if (name.StartsWith("pump")){
                    ammo = "bullets";
                }
                if (inventory.GetAmmoDict().ContainsKey(ammo)){ 
                    value = inventory.GetAmmoCount(ammo);
                }
                ammoTexts[i].text = value.ToString();
            }
        }
	}
}

