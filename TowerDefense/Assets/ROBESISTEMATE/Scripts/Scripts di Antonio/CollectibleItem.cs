using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class CollectibleItem : MonoBehaviour {

    [SerializeField] private string itemName;
    [SerializeField] private Categoria type;

    private SphereCollider colliderr;
    private float speed;

    // Use this for initialization
    void Start () {
        speed = 50f;
        colliderr = this.gameObject.GetComponent<SphereCollider>();
        colliderr.enabled = false;
        StartCoroutine(IssTrigger());
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up, speed * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other) {
       if (other.GetComponent<CharacterController>()) {
            if (Managers.Inventory.AddItem(itemName, type)) Destroy(this.gameObject);     
       }
    }

    private IEnumerator IssTrigger() {
        yield return new WaitForSeconds(2);
        colliderr.enabled = true;
    }
}
