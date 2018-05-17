using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCharacter : MonoBehaviour {

    Rigidbody rb;
    private bool isGrounded;
    public Vector3 jump;
    public float jumpForce = 2.0f;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
	
	// Update is called once per frame
	void Update () {
        if (rb.velocity.y == 0 && transform.position.y < 2) isGrounded = true;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
                Jump();
        }
    }

    public void Jump(){
        rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

}
