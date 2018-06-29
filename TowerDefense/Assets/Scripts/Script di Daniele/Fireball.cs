using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    private float speed = 5.0f;
    private int damage = 10;
	

	void Start () {
        
	}
		
    void Update () {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
		
        TPSMovement player = other.GetComponent<TPSMovement>();
        if (player != null) {
			Debug.Log(12345);
			player.SendMessage("Hurt", damage, SendMessageOptions.DontRequireReceiver);
			Destroy(this.gameObject);
		}
        
    }
}
