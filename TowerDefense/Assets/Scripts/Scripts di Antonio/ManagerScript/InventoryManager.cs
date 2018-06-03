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

    private int maxWeapons;
    private int maxAmmo;
    private int maxConsumables;

    [SerializeField] private int numBullets;
    [SerializeField] private int numHeavyAmmo;
    [SerializeField] private int numLightAmmo;

    public bool somethingChanged;
    public bool canRenderHUD;

    public void Startup() {
        status = ManagerStatus.Started;
        somethingChanged = false;
        canRenderHUD = false;
        consumables = new Dictionary<string, int>();
        ammo = new Dictionary<string, int>();
        weapons = new List<string>();
    }

    // Use this for initialization
    void Start () {
        numWeapons = 0;
        numAmmo = 0;
        numConsumables = 0;
        maxWeapons = 5;
        maxAmmo = 5;
        maxConsumables = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //for debugging
    private void DisplayItems() {
        string itemsDisplayed = "List of Items: Consumables: ";
        foreach (KeyValuePair<string, int> item in consumables) {
            itemsDisplayed += item.Key + "(" + item.Value + ")";        
        }
        itemsDisplayed += "Ammo: ";
        foreach (KeyValuePair<string, int> item in ammo) {
            itemsDisplayed += item.Key + "(" + item.Value + ")";        
        }
        itemsDisplayed += "Weapons: ";
        foreach (string item in weapons) {
            itemsDisplayed += "(" + item + ")";
        }
        Debug.Log(itemsDisplayed);
    }
    
    public void AddItem(string name, Categoria type) {
        if (type == Categoria.Weapon) {
            if (numWeapons >= maxWeapons) {
                ReplaceWeapon();
            } else {
                weapons.Add(name);
                numWeapons++;
            }
        }
        //TODO: optimize
        else if (type == Categoria.Ammo) { 
            if (ammo.ContainsKey(name)) {
                if (name == "heavyammo") ammo[name] += numHeavyAmmo;
                else if (name == "bullets") ammo[name] += numBullets;
                else if (name == "lightammo") ammo[name] += numLightAmmo;
            } else {
                if (name == "heavyammo") ammo[name] = numHeavyAmmo;
                else if (name == "bullets") ammo[name] = numBullets;
                else if (name == "lightammo") ammo[name] = numLightAmmo;
                numAmmo++;
            } 
        }
        else if (type == Categoria.Consumable) { 
            if (consumables.ContainsKey(name)) {
                consumables[name]++;
            } else {
                consumables[name] = 1;
                numConsumables++;
            } 
        }
        somethingChanged = true;
        //DisplayItems();
    }

    public void ConsumeItem(string name, Categoria type) { 
        if (type == Categoria.Weapon) {
            if (weapons.Contains(name)) {
                weapons.Remove(name);
                numWeapons--;
            } else {
                Debug.Log("Cannot consume" + name);
            }  
        }
        else if (type == Categoria.Ammo){
            if (ammo.ContainsKey(name)) {
                ammo[name]--;
                if (ammo[name] == 0) {
                    ammo.Remove(name);
                    numAmmo--;
                }
            } else {
                Debug.Log("Cannot consume" + name);
            }
        }
        else if (type == Categoria.Consumable) {
            if (consumables.ContainsKey(name)) {
                consumables[name]--;
                if (consumables[name] == 0) {
                    consumables.Remove(name);
                    numConsumables--;
                }
            } else {
                Debug.Log("Cannot consume" + name);
            }
        }
        somethingChanged = true;
        //DisplayItems();
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

    public Dictionary<string, int> GetAmmoDict() {
        return ammo;
    }

    public int GetAmmoCount(string name) { 
        if (ammo.ContainsKey(name)) {
            return ammo[name];    
        }
        return 0;
    }

    public List<string> GetWeaponsList() {
        return weapons;
    }

    public void ReplaceWeapon() { 
    
    }
}
