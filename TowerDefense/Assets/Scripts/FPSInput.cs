using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script /fps Input")]
public class FPSInput : MonoBehaviour {

    public float speed = 6.0f;
    public float gravity = -9.8f;
    private bool isGrounded;
    public float jumpForce = 2.0f;
    private CharacterController charController;

	// Use this for initialization
	void Start () {
        charController = GetComponent<CharacterController>();
        isGrounded = true;
	}
	
	// Update is called once per frame
	void Update () {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        charController.Move(movement);
    }
}
