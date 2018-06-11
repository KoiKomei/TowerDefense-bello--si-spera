using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapons : MonoBehaviour {

    [SerializeField] private InventoryController controller;
    [SerializeField] private List<Image> weapons;
    [SerializeField] private List<Image> bgWeapons;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (Managers.Inventory.canRenderHUD) {
            List<Image> weaponsImages = controller.getWeaponsImages();
            List<Image> bgWeaponsImages = controller.getBgWeaponsImages();
            int i = 0;
            while (i < bgWeapons.Count) {
                weapons[i].sprite = weaponsImages[i].sprite;
                bgWeapons[i].color = bgWeaponsImages[i].color;
                if (bgWeaponsImages[i].gameObject.activeSelf) bgWeapons[i].gameObject.SetActive(true);
                else bgWeapons[i].gameObject.SetActive(false);
                i++;
            }
            Managers.Inventory.canRenderHUD = false;
        }
	}
}
