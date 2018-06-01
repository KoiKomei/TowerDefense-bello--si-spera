using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class TPSMovement : MonoBehaviour {

	/*[SerializeField] private Transform target;

    public float rotSpeed = 15.0f;
    public float moveSpeed = 6.0f;
    public float jumpSpeed = 15.0f;
    public float gravity = -9.8f;
    public float terminalSpeed = -10.0f;
    public float minFall = -1.5f;
	public float pushForce = 3.0f;

	private float verticalSpeed;
    private CharacterController characterController;
	private ControllerColliderHit _contact;


	// Use this for initialization
	void Start () {
        characterController = GetComponent<CharacterController>();
        verticalSpeed = minFall;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = Vector3.zero;
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");

		bool hitGround = false;
		RaycastHit hit;
		if (verticalSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out hit))
		{
			float check = (characterController.height + characterController.radius) / 1.9f;
			hitGround = hit.distance <= check;
		}

		if (horInput!=0 || verInput != 0)
        {
            movement.x = horInput*moveSpeed;
            movement.z = verInput*moveSpeed;
            movement = Vector3.ClampMagnitude(movement, moveSpeed);

            Quaternion tmp = target.rotation;
            target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
            movement = target.TransformDirection(movement);
            target.rotation = tmp;

            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);
        }

		if (hitGround)
		{
			if (Input.GetButtonDown("Jump"))
			{
				verticalSpeed = jumpSpeed;
			}
			else
			{
				verticalSpeed = minFall;
			}
		}
		else
		{
			verticalSpeed += gravity * 5 * Time.deltaTime;
			if (verticalSpeed < terminalSpeed)
			{
				verticalSpeed = terminalSpeed;
			}
			
			if (characterController.isGrounded)
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
		movement.y = verticalSpeed;
        movement *= Time.deltaTime;
        characterController.Move(movement);
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body != null && !body.isKinematic)
		{
			body.velocity = hit.moveDirection * pushForce;
		}
		_contact = hit;
	}*/

	private Animator animator;
	[SerializeField] private Transform target;
	public float rotSpeed = 15f;
	public float pushForce = 3.0f;

	public float moveSpeed = 6.0f;
	public float sprint = 15.0f;
	public float noSprint = 6.0f;

	public float jumpSpeed = 15.0f;
	public float gravity = -9.8f;
	public float terminalVelocity = -10.0f;
	public float minFall = -1.5f;
	private float _vertSpeed;
	private CharacterController _charController;

	private ControllerColliderHit _contact;
	// Use this for initialization
	void Start()
	{
		_charController = GetComponent<CharacterController>();
		_vertSpeed = minFall;
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		bool running = false;
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
		if (horInput != 0 || vertInput != 0)
		{
			if (Input.GetKeyDown("left shift"))
			{
				moveSpeed = sprint;
				running = true;

			}
			if (Input.GetKeyUp("left shift"))
			{
				moveSpeed = noSprint;
				running = false;
			}

			movement.x = horInput * moveSpeed;
			movement.z = vertInput * moveSpeed;
			movement = Vector3.ClampMagnitude(movement, moveSpeed);
			Quaternion tmp = target.rotation;
			target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
			movement = target.TransformDirection(movement);
			target.rotation = tmp;
			
			Quaternion direction = Quaternion.LookRotation(movement);
			
			//transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);
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
		if (body != null && !body.isKinematic)
		{
			body.velocity = hit.moveDirection * pushForce;
		}
		_contact = hit;
	}

}
