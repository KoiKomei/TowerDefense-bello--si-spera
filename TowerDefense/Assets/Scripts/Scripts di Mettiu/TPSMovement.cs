﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class TPSMovement : MonoBehaviour {

    /* animazioni*/
	private Animator animator;

    /* mira*/

    private bool focusing=false;
    [SerializeField] private Camera _cam;

    /*statistiche personaggio*/
	[SerializeField] private Transform target;
	private float rotSpeed = 15f;
	public float pushForce = 3.0f;

	private float moveSpeed = 1.0f;
	private float sprint = 7.0f;
	private float noSprint = 1.0f;

	public float jumpSpeed = 15.0f;
	public float gravity = -9.8f;
	public float terminalVelocity = -10.0f;
	public float minFall = -1.5f;
	private float _vertSpeed;
    private CharacterController _charController;

    private ControllerColliderHit _contact;
    bool running = false;
    /*file audio*/

    private AudioSource _soundSource;
    [SerializeField] private AudioClip reloadSound;
    [SerializeField] private AudioClip footStepSound;
    [SerializeField] private AudioClip fireinthehole;
    private float _footStepSoundLength = 0.6f;
    private bool _step;


    /*munizione e ricarica*/
    public int maxAmmo = 20;
    private int currentAmmo;
    private float reloadTime = 3.0f;
    private float secondreloadtime = 0.5f;
    public static bool isReloading = false;
    private bool _shooting;
    public Camera fpscam;
    public GameObject impact;
    public float fireRate = 15f;
    public float nextTimeToFire = 0f;
    public float impactForce = 30f;

    public float damage = 10f;

    
	void Start()
	{
		_charController = GetComponent<CharacterController>();
		_vertSpeed = minFall;
		animator = GetComponent<Animator>();
        _shooting = false;
        currentAmmo = maxAmmo;

        _soundSource = GetComponent<AudioSource>();
        _step = true;
        _soundSource.volume = PlayerPrefs.GetFloat("SFXVolume");
        

    }

	
	void Update()
	{

        
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
            if (Input.GetKeyDown("left shift") && _shooting == false && isReloading == false)
			{
				moveSpeed = sprint;
                _footStepSoundLength = 0.3f;
				running = true;

			}
			if (Input.GetKeyUp("left shift"))
			{
				moveSpeed = noSprint;
                _footStepSoundLength = 0.6f;
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

        if (_charController.velocity.magnitude > 1f && _step && _charController.isGrounded)
        {
            _soundSource.PlayOneShot(footStepSound);
            StartCoroutine(WaitForFootSteps(_footStepSoundLength));
        }

        animator.SetFloat("Speed", movement.magnitude);
       



        /* Jump */
		if (hitGround)
		{
			if (Input.GetButtonDown("Jump") && _shooting==false && isReloading==false && _charController.isGrounded)
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

       /*END OF JUMP*/
        movement.y = _vertSpeed;
		movement *= Time.deltaTime;
		_charController.Move(movement);
        /*END OF MOVEMENT*/

        
        if (Input.GetMouseButtonDown(1) && !focusing)
        {
            _cam.fieldOfView = 30f;


            PlayerCharacter player = GetComponentInParent<PlayerCharacter>();


            focusing = true;
        }

        if (Input.GetMouseButtonUp(1) && focusing)
        {
            _cam.fieldOfView = 60f;


            PlayerCharacter player = GetComponentInParent<PlayerCharacter>();

            focusing = false;


        }


        /* shooting */
        if (isReloading)
        {           
            return;
        }
        if (currentAmmo <= 0  || Input.GetButton("Reload") && currentAmmo<maxAmmo)
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

    /*end of shooting*/
    

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body != null && !body.isKinematic)
		{
			body.velocity = hit.moveDirection * pushForce;
		}
		_contact = hit;
	}

    /* NON TOCCARE PER NESSUNA QUESTIONE AL MONDO, SERVONO PER LE ANIMAZIONI*/
    private void BlendMove(float x, float y) {
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);
    }


    /*Metodi aggiuntivi per sparare, ricaricare ed altro*/

    void Shoot()
    {
        animator.SetBool("Shoot", true);
        
        _soundSource.PlayOneShot(fireinthehole);
        RaycastHit hit;

        currentAmmo--;
        
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit))
            {
				GameObject hitted = hit.transform.gameObject; //Mattia start
				if (hitted != null)
				{
					hitted.SendMessage("Hurt", 1,SendMessageOptions.DontRequireReceiver);
				}
				//Mattia end
				//Debug.Log(hit.transform.name);
		}
		

        if (hit.rigidbody != null) {
            hit.rigidbody.AddForce(-hit.normal * impactForce);
        }
        GameObject impactGO= Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO, 0.5f);
    }

    IEnumerator Reload() {
        isReloading = true;
        moveSpeed = noSprint;
        _footStepSoundLength = 0.6f;
        running = false;
        Debug.Log("Reloading...");

        IKController.ikActive = false;
        _soundSource.PlayOneShot(reloadSound);
        animator.SetBool("Shoot", false);
        animator.SetBool("Reloading", true);
        _shooting = false;
        
        yield return new WaitForSeconds(reloadTime);
        Debug.Log("Reloading done");
        
        animator.SetBool("Reloading", false);
        currentAmmo = maxAmmo;
        IKController.ikActive = true;
        yield return new WaitForSeconds(secondreloadtime);
        isReloading = false;

        
    }

    IEnumerator WaitForFootSteps(float stepsLength)
    {
        _step = false;
        yield return new WaitForSeconds(stepsLength);
        _step = true;
    }


}
