﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]

public class RelativeMovement : MonoBehaviour {

    private Animator animator;
    [SerializeField] private Transform target;
    public float rotSpeed = 15f;
    public float pushForce = 3.0f;
    private bool isshooting;
   
    public float moveSpeed = 6.0f;
    public float sprint = 15.0f;

    public float jumpSpeed = 15.0f;
    public float gravity = -9.8f;
    public float terminalVelocity = -10.0f;
    public float minFall = -1.5f;
    private float _vertSpeed;
    private CharacterController _charController;

    private ControllerColliderHit _contact;
    // Use this for initialization
    void Start () {
        _charController = GetComponent<CharacterController>();
        _vertSpeed = minFall;
        animator = GetComponent<Animator>();
        isshooting = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButton("Fire1"))
        {
            isshooting = true;
            animator.SetBool("Shoot", true);
        }
        else
        {
            isshooting = false;
            animator.SetBool("Shoot", false);

        }

        bool hitGround = false;
        RaycastHit hit;
        if (_vertSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            float check = (_charController.height + _charController.radius) / 1.9f;
            hitGround = hit.distance <= check;
        }
        Vector3 movement = Vector3.zero;
        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        if (horInput != 0 || vertInput != 0) {
            if (Input.GetKey("left shift"))
            {
                movement.x = horInput * sprint;
                movement.z = vertInput * sprint;
                movement = Vector3.ClampMagnitude(movement, sprint);
                Quaternion tmp = target.rotation;
                target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
                movement = target.TransformDirection(movement);
                target.rotation = tmp;
                Quaternion direction = Quaternion.LookRotation(movement);
                transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);
                if (Input.GetButton("Fire1"))
                {
                    isshooting = true;
                    animator.SetBool("Run Shoot", true);
                }
                else {
                    isshooting = false;
                    animator.SetBool("Run Shoot", false);

                }
            }
            else
            {
                movement.x = horInput * moveSpeed;
                movement.z = vertInput * moveSpeed;
                movement = Vector3.ClampMagnitude(movement, moveSpeed);
                Quaternion tmp = target.rotation;
                target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
                movement = target.TransformDirection(movement);
                target.rotation = tmp;
                Quaternion direction = Quaternion.LookRotation(movement);
                transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);
                if (Input.GetButton("Fire1"))
                {
                    isshooting = true;
                    animator.SetBool("Shoot", true);
                }
                else
                {
                    isshooting = false;
                    animator.SetBool("Shoot", false);

                }
            }
        }
        animator.SetFloat("Speed", movement.magnitude);
        if (hitGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _vertSpeed = jumpSpeed;
            }
            else
            {
                _vertSpeed = minFall;
                animator.SetBool("Jumping", false);
            }
        }
        else
        {
            _vertSpeed += gravity * 5 * Time.deltaTime;
            if (_vertSpeed < terminalVelocity)
            {
                _vertSpeed = terminalVelocity;
            }
            animator.SetBool("Jumping", true);
            if (_charController.isGrounded)
            {
                if (Vector3.Dot(movement, _contact.normal) < 0)
                {
                    movement = _contact.normal * moveSpeed;
                }
                else
                {
                    movement += _contact.normal * moveSpeed;
                }
            }
        }
        movement.y = _vertSpeed;
        movement *= Time.deltaTime;
        _charController.Move(movement);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body != null && !body.isKinematic) {
            body.velocity = hit.moveDirection * pushForce;
        }
        _contact = hit;
    }

}
