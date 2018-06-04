using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class TPSMovement : MonoBehaviour {


	private Animator animator;
	[SerializeField] private Transform target;
	public float rotSpeed = 15f;
	public float pushForce = 3.0f;

	public float moveSpeed = 1.0f;
	public float sprint = 15.0f;
	public float noSprint = 1.0f;

	public float jumpSpeed = 15.0f;
	public float gravity = -9.8f;
	public float terminalVelocity = -10.0f;
	public float minFall = -1.5f;
	private float _vertSpeed;

    bool running = false;
    


    public int maxAmmo = 20;
    private int currentAmmo;
    private float reloadTime = 3.0f;
    private bool isReloading = false;


    private bool _shooting;
    public Camera fpscam;

    public GameObject impact;


    public float fireRate = 15f;
    public float nextTimeToFire = 0f;
    public float impactForce = 30f;

    public float damage = 10f;


    
	private CharacterController _charController;

	private ControllerColliderHit _contact;
	// Use this for initialization
	void Start()
	{
		_charController = GetComponent<CharacterController>();
		_vertSpeed = minFall;
		animator = GetComponent<Animator>();
        _shooting = false;
        currentAmmo = maxAmmo;
	}

	// Update is called once per frame
	void Update()
	{


        //movement

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
        BlendMove(horInput, vertInput);
        
		if (horInput != 0 || vertInput != 0)
		{
            if (Input.GetKeyDown("left shift") && _shooting == false && isReloading==false)
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
			
			//Quaternion direction = Quaternion.LookRotation(movement);
			
			//transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);
		}
		
		animator.SetFloat("Speed", movement.magnitude);
       



        //jump
		if (hitGround)
		{
			if (Input.GetButtonDown("Jump") && _shooting==false)
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

        //END OF JUMP



        //SHOOTING
        
		movement.y = _vertSpeed;
		movement *= Time.deltaTime;
		_charController.Move(movement);

        if (isReloading)
        {           
            return;
        }
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());

            return;
        }
        if (Input.GetButton("Fire1") && _charController.isGrounded == true && running == false && Time.time >= nextTimeToFire)
        {

            nextTimeToFire = Time.time + 1f / fireRate;

            _shooting = true;
            Shoot();
        }
        if (Input.GetButtonUp("Fire1"))
        {

            _shooting = false;
            animator.SetBool("Shoot", false);
        }

    }

    //END OF SHOOTING
    //END OF MOVEMENT

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body != null && !body.isKinematic)
		{
			body.velocity = hit.moveDirection * pushForce;
		}
		_contact = hit;
	}

    private void BlendMove(float x, float y) {
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);
    }


    void Shoot()
    {
        

        RaycastHit hit;

        currentAmmo--;
        
            if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit))
            {
                Debug.Log(hit.transform.name);
            }
        animator.SetBool("Shoot", true);

        if (hit.rigidbody != null) {
            hit.rigidbody.AddForce(-hit.normal * impactForce);
        }
        GameObject impactGO= Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO, 0.5f);
    }

    IEnumerator Reload() {
        isReloading = true;
        Debug.Log("Reloading...");

        IKController.ikActive = false;
        animator.SetBool("Shoot", false);
        animator.SetBool("Reloading", true);
        _shooting = false;
        
        yield return new WaitForSeconds(reloadTime);
        Debug.Log("Reloading done");
        
        animator.SetBool("Reloading", false);
        currentAmmo = maxAmmo;
        IKController.ikActive = true;
        isReloading = false;
    }

}
