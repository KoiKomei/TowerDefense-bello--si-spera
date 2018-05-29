using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour, IGameManager {

    public ManagerStatus status { get; private set; }

    //strutture dati
    private List<string> weapons;
    private Dictionary<string, int> consumables;
    private Dictionary<string, int> ammo;

    //campi di utilita
    private int numWeapons;
    private int numAmmo;
    private int numConsumables;
    [SerializeField] private int maxWeapons;
    [SerializeField] private int maxAmmo;
    [SerializeField] private int maxConsumables;
    public bool somethingChanged;

    public void Startup() {
        status = ManagerStatus.Started;
        somethingChanged = false;
        consumables = new Dictionary<string, int>();
        ammo = new Dictionary<string, int>();
        weapons = new List<string>();
    }

    // Use this for initialization
    void Start () {
        numWeapons = 0;
        numAmmo = 0;
        numConsumables = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void DisplayItems() {
        string itemsDisplayed = "List of Items: ";
        foreach (KeyValuePair<string, int> item in consumables) {
            itemsDisplayed += item.Key + "(" + item.Value + ")";        
        }
        foreach (KeyValuePair<string, int> item in ammo) {
            itemsDisplayed += item.Key + "(" + item.Value + ")";        
        }
        foreach (string item in weapons) {
            itemsDisplayed += "(" + item + ")";
        }
        Debug.Log(itemsDisplayed);
    }
    
    public void AddItem(string name, Categoria type, Rarity rarity) {
        if (type == Categoria.Weapon) {
            if (numWeapons >= maxWeapons) {
                ReplaceWeapon();
            } else {
                weapons.Add(name);
                numWeapons++;
            }
        }
        else if (type == Categoria.Ammo) { 
            if (ammo.ContainsKey(name)) {
                ammo[name]++;
            } else {
                ammo[name] = 1;
            } 
        }
        else if (type == Categoria.Consumable) { 
            if (consumables.ContainsKey(name)) {
                consumables[name]++;
            } else {
                consumables[name] = 1;
            } 
        }
        somethingChanged = true;
        DisplayItems();
    }

    public void ConsumeItem(string name, Categoria type) { 
        if (type == Categoria.Ammo){
            if (ammo.ContainsKey(name)) {
                ammo[name]--;
                if (ammo[name] == 0) {
                    ammo.Remove(name);    
                }
            } else {
                Debug.Log("Cannot consume" + name);
            }
        }
        else if (type == Categoria.Consumable){
            if (consumables.ContainsKey(name)) {
                consumables[name]--;
                if (consumables[name] == 0) {
                    consumables.Remove(name);    
                }
            } else {
                Debug.Log("Cannot consume" + name);
            }
        }
        somethingChanged = true;
        DisplayItems();
    }

    public Dictionary<string, int> GetConsumablesDict() {
        return consumables;
    }

    public int GetConsumablesCount(string name) { 
        if (consumables.ContainsKey(name)) {
            return consumables[name];    
        }
        return 0;
    }

    public void ReplaceWeapon() { 
    
    }
}
