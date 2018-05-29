using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

    //riferimento alla struttura dati
    private InventoryManager manager;

    //Slots dell' inventario
    [SerializeField] private List<Image> bgWeaponsImages;
    [SerializeField] private List<Image> bgAmmoImages;
    [SerializeField] private List<Image> bgConsumablesImages;
    [SerializeField] private List<Image> weaponsImages;
    [SerializeField] private List<Image> ammoImages;
    [SerializeField] private List<Image> consumablesImages;

    //Sprites degli oggetti
    [SerializeField] private Sprite medikitSprite;

	// Use this for initialization
	void Start () {
        manager = Managers.Inventory;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (manager.somethingChanged) {
            Debug.Log("Something changed in Inventory");
            RenderItems();
            manager.somethingChanged = false;
        }
	}

    private void RenderItems() {
        int count = 0;
        Debug.Log("Rendering Inventory");
        foreach (KeyValuePair<string, int> item in manager.GetConsumablesDict()) {
            Debug.Log("Count: " + count);
            if (item.Key == "Medikit") consumablesImages[count].sprite = medikitSprite;
            bgConsumablesImages[count].gameObject.SetActive(true);
            count++;
            Debug.Log("Count incremented: " + count);
        }
        Debug.Log("Completed Rendering Inventory");
    }
}
