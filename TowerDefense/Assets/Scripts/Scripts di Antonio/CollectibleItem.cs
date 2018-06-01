using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour {

    [SerializeField] private string itemName;
    [SerializeField] private Categoria type;

    private float speed;

    // Use this for initialization
    void Start () {
        speed = 50f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up, speed * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other) {
       if (other.GetComponent<CharacterController>()) {
            Managers.Inventory.AddItem(itemName, type);
            Destroy(this.gameObject);     
       }
    }
}
