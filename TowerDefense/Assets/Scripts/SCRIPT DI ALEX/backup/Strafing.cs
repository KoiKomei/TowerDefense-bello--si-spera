using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strafing : MonoBehaviour {

    public float walk = 2f;
    public float gravity = 20f;
    public float jump = 8.0f;
    private Vector3 move = Vector3.zero;
    private CharacterController _char;
    private Animator anim;

    private void Start()
    {
        _char = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_char.isGrounded) {
            move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            move = transform.TransformDirection(move);
            move *= walk;
            if (Input.GetButton("Jump")) {
                move.y = jump;
            }
        }
        move.y -= gravity * Time.deltaTime;
        _char.Move(move * Time.deltaTime);
    }

}
