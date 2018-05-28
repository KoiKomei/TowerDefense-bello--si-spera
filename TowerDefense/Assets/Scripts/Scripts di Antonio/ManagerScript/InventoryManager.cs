using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager {

    public ManagerStatus status { get; private set; }
    private Dictionary<string, int> items;

    public void Startup() {
        status = ManagerStatus.Started;
        items = new Dictionary<string, int>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void DisplayItems() {
        string itemsDisplayed = "List of Items: ";
        foreach (KeyValuePair<string, int> item in items) {
            itemsDisplayed += item.Key + "(" + item.Value + ")";        
        }
        Debug.Log(itemsDisplayed);
    }
    
    public void AddItem (string name) {
        if (items.ContainsKey(name)) {
            items[name]++;
        } else {
            items[name] = 1;    
        }
        DisplayItems();
    }

    public void ConsumeItem(string name) { 
        if (items.ContainsKey(name)) {
            items[name]--;
            if (items[name] == 0) {
                items.Remove(name);    
            }
        } else {
            Debug.Log("Cannnot consume" + name);
        }
        DisplayItems();
    }

    public List<string> GetItemList() {
        List<string> list = new List<string>(items.Keys);
        return list;
    }

    public int GetItemCount(string name) { 
        if (items.ContainsKey(name)) {
            return items[name];    
        }
        return 0;
    }
}
