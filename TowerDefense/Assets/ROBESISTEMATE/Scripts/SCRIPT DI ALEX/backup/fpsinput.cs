using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] //dice che c'è
[AddComponentMenu("Control Script/fpsinput")]

public class fpsinput : MonoBehaviour {
    private CharacterController _char;
	// Use this for initialization
	void Start () {
        _char = GetComponent<CharacterController>();
		
	}
	private float speed = 6.0f;
    
    private float gravity = -9.8f;
    bool flip = true;
	// Update is called once per frame
	void Update () {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        if (Input.GetButton("Fire3")) {
            _char.transform.SetPositionAndRotation(new Vector3(0, 0, 0), new Quaternion(0,0,0,w:0));
        }

        deltaX = Input.GetAxis("Vertical") * (flip ? -1 : 1);
        deltaX = deltaX * speed;
        if (_char.isGrounded)
        {
            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, speed);
            movement.y = gravity;
            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            _char.Move(movement);
        }
	}

}
