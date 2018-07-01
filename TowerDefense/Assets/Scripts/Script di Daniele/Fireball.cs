using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    private float speed = 5.0f;
    public int damage = 1;
	

	void Start () {
		Destroy(this.gameObject, 15);
	}
		
    void Update () {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
		Debug.Log(other.gameObject.name);

		
        TPSMovement2 player = other.GetComponent<TPSMovement2>();
        if (player != null) {
			//Debug.Log(12345);
			player.SendMessage("Hurt", damage, SendMessageOptions.DontRequireReceiver);
			Destroy(this.gameObject);
		}
		TPSMovement player1 = other.GetComponent<TPSMovement>();
		if (player1 != null)
		{
			//Debug.Log(12345);
			player1.SendMessage("Hurt", damage, SendMessageOptions.DontRequireReceiver);
			Destroy(this.gameObject);
		}
		Payload payload = other.GetComponent<Payload>();
		if (payload != null)
		{
			//Debug.Log(12345);
			payload.SendMessage("Hurt", damage, SendMessageOptions.DontRequireReceiver);
			Destroy(this.gameObject);
		}

	}

	private void OnCollisionEnter(Collision collision)
	{
		
	}
}
