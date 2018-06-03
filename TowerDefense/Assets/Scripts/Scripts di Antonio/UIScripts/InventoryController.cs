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
    [SerializeField] private Sprite healthpotionSprite;
    [SerializeField] private Sprite shieldpotionSprite;
    [SerializeField] private Sprite rushpotionSprite;
    [SerializeField] private Sprite revolverSprite;
    [SerializeField] private Sprite m4Sprite;
    [SerializeField] private Sprite pumpSprite;
    [SerializeField] private Sprite bulletsSprite;
    [SerializeField] private Sprite heavyammoSprite;
    [SerializeField] private Sprite lightammoSprite;

    //utility
    private Color purple;
    private Color orange;

	// Use this for initialization
	void Start () {
        manager = Managers.Inventory;
        purple = new Color(0.6f, 0f, 0.65f);
        orange = new Color(1.0f, 0.5f, 0f);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (manager.somethingChanged) {
            Debug.Log("Something changed in Inventory");
            RenderItems();
            manager.canRenderHUD = true;
            manager.somethingChanged = false;
        }
	}

    private void RenderItems() {

        int count = 0;
        Debug.Log("Rendering Inventory");

        foreach (KeyValuePair<string, int> item in manager.GetConsumablesDict()) {
            Image current = consumablesImages[count];
            Image currentBackground = bgConsumablesImages[count];
            Text value = current.GetComponentInChildren<Text>();
            value.text = item.Value.ToString();

            assignBackgroundAndSprite(item.Key, current, currentBackground);

            currentBackground.gameObject.SetActive(true);
            count++;
        }
        for (int i = count; i < bgConsumablesImages.Count; i++) {
            bgConsumablesImages[count].gameObject.SetActive(false);
        }

        count = 0;
        foreach (KeyValuePair<string, int> item in manager.GetAmmoDict()) {
            Image current = ammoImages[count];
            Image currentBackground = bgAmmoImages[count];
            Text value = current.GetComponentInChildren<Text>();
            value.text = item.Value.ToString();
            
            assignBackgroundAndSprite(item.Key, current, currentBackground);

            bgAmmoImages[count].gameObject.SetActive(true);
            count++;
        }
        for (int i = count; i < bgAmmoImages.Count; i++) {
            bgAmmoImages[count].gameObject.SetActive(false);
        }

        count = 0;
        foreach (string item in manager.GetWeaponsList()) {

            assignBackgroundAndSprite(item, weaponsImages[count], bgWeaponsImages[count]);

            bgWeaponsImages[count].gameObject.SetActive(true);
            count++;
        }
        for (int i = count; i < bgWeaponsImages.Count; i++) {
            bgWeaponsImages[count].gameObject.SetActive(false);
        }

        Debug.Log("Completed Rendering Inventory");
    }

    private void assignBackgroundAndSprite(string name, Image mainImage, Image backgroundImage) {
        if (name == "healthpotion"){
            mainImage.sprite = healthpotionSprite;
            backgroundImage.color = Color.gray;
        }
        if (name == "shieldpotion"){
            mainImage.sprite = shieldpotionSprite;
            backgroundImage.color = Color.gray;
        }
        if (name == "rushpotion"){
            mainImage.sprite = rushpotionSprite;
            backgroundImage.color = Color.gray;
        }
        else if (name == "revolvercommon"){
            mainImage.sprite = revolverSprite;
            backgroundImage.color = Color.white;
        }
        else if (name == "revolveruncommon"){
            mainImage.sprite = revolverSprite;
            backgroundImage.color = Color.green;
        }
        else if (name == "revolverrare"){
            mainImage.sprite = revolverSprite;
            backgroundImage.color = Color.blue;
        }
        else if (name == "revolverepic"){
            mainImage.sprite = revolverSprite;
            backgroundImage.color = purple;
        }
        else if (name == "revolverlegendary"){
            mainImage.sprite = revolverSprite;
            backgroundImage.color = orange;
        }
        else if (name == "m4uncommon"){
            mainImage.sprite = m4Sprite;
            backgroundImage.color = Color.green;
        }
        else if (name == "m4rare"){
            mainImage.sprite = m4Sprite;
            backgroundImage.color = Color.blue;
        }
        else if (name == "m4epic"){
            mainImage.sprite = m4Sprite;
            backgroundImage.color = purple;
        }
        else if (name == "m4legendary"){
            mainImage.sprite = m4Sprite;
            backgroundImage.color = orange;
        }
        else if (name == "pumpuncommon"){
            mainImage.sprite = pumpSprite;
            backgroundImage.color = Color.green;
        }
        else if (name == "pumprare"){
            mainImage.sprite = pumpSprite;
            backgroundImage.color = Color.blue;
        }
        else if (name == "pumpepic"){
            mainImage.sprite = pumpSprite;
            backgroundImage.color = purple;
        }
        else if (name == "pumplegendary"){
            mainImage.sprite = pumpSprite;
            backgroundImage.color = orange;
        }
        else if (name == "bullets"){
            mainImage.sprite = bulletsSprite;
            backgroundImage.color = Color.gray;
        }
        else if (name == "heavyammo"){
            mainImage.sprite = heavyammoSprite;
            backgroundImage.color = Color.gray;
        }
        else if (name == "lightammo"){
            mainImage.sprite = lightammoSprite;
            backgroundImage.color = Color.gray;
        }
    }

    public List<Image> getWeaponsImages() {
        return weaponsImages;
    }

    public List<Image> getBgWeaponsImages() {
        return bgWeaponsImages;
    }
}
