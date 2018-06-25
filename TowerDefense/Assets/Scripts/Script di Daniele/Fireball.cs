using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    private float speed = 10.0f;
    private int damage = 10;
	

	void Start () {
        
	}
		
    void Update () {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null) {
            player.Hurt(damage);
        }
        Destroy(this.gameObject);
    }
}
