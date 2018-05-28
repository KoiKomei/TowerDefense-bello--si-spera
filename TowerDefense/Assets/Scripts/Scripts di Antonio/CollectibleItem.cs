using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour {

    [SerializeField] private string itemName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
       if (other.GetComponent<CharacterController>()) {
            Managers.Inventory.AddItem(itemName);
            Destroy(this.gameObject);     
       }
    }
}
