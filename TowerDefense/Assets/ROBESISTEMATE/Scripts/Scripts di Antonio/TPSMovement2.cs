using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class TPSMovement2 : MonoBehaviour
{

	/* animazioni*/
	private Animator animator;

	/* mira*/
	private bool focusing = false;

	/*statistiche personaggio*/
	[SerializeField] private Transform target;

	public float pushForce = 3.0f;

	public float moveSpeed = 1.0f;
	public float sprint = 7.0f;
	public float noSprint = 1.0f;

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
	private float _footStepSoundLength = 0.6f;
	private bool _step;
    


    /*munizione e ricarica*/
    private WeaponManager weaponManager;
	private AudioClip shotSound;
	private int maxAmmo;
	private int currentAmmo;
	private float reloadTime;
	public static bool isReloading = false;
	private bool _shooting;
	private float fireRate;
	private float nextTimeToFire;
	private float impactForce;
	private float damage;

	public Camera fpscam;
	PlayerCharacter player;
	public GameObject impact;

	void Start()
	{

		weaponManager = Managers.Weapon;

		_charController = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
		_soundSource = GetComponent<AudioSource>();
		player = GetComponentInParent<PlayerCharacter>();

        

		_vertSpeed = minFall;
		_shooting = false;
		_step = true;
        Managers.Audio.PlayIntroMusic();

        if (PlayerPrefs.GetInt("Continue") == 0)
		{
			PlayerPrefs.SetFloat("PlayerPosX", player.transform.position.x);
			PlayerPrefs.SetFloat("PlayerPosY", player.transform.position.y);
			PlayerPrefs.SetFloat("PlayerPosZ", player.transform.position.z);
		}

		if (PlayerPrefs.GetInt("Continue") == 1)
		{
            player.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerPosX"), PlayerPrefs.GetFloat("PlayerPosY"), PlayerPrefs.GetFloat("PlayerPosZ"));
            PlayerPrefs.SetInt("Continue", 0);
           // Debug.Log("playerX" + player.transform.position.x);
		}
        
        _soundSource.volume = PlayerPrefs.GetFloat("SFXVolume");
    }


	void Update()
	{
        if (PlayerCharacter.dead == true)
        {
            return;
        }

        if (UIController.isPaused)
        {
            _soundSource.volume = PlayerPrefs.GetFloat("SFXVolume");
        }
        
		//Cambio Arma

		if (weaponManager.changeWeapon)
		{

			Weapon weapon = weaponManager.getCurrentWeapon();

			fireRate = weapon.rateOfFire;
			damage = weapon.damage;
			impactForce = weapon.impact;
			maxAmmo = weapon.capacity;
			reloadTime = weapon.rechargeTime;

			currentAmmo = weapon.getCurrentAmmo();
			shotSound = weaponManager.getShotSound();

		}

		/*movement*/

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
			if (Input.GetButtonDown("Dash") && _shooting == false && isReloading == false)
			{
				moveSpeed = sprint;
				_footStepSoundLength = 0.3f;
				running = true;

			}
			else if (Input.GetButtonUp("Dash"))
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
			if (Input.GetButtonDown("Jump") && _shooting == false && isReloading == false && _charController.isGrounded)
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

		//Aiming
		if (Input.GetMouseButtonDown(1) && !focusing)
		{
			fpscam.fieldOfView = 30f;
			focusing = true;
		}
		else if (Input.GetMouseButtonUp(1) && focusing)
		{
			fpscam.fieldOfView = 60f;
			focusing = false;
		}

		/* shooting */
		if (weaponManager.firstWeaponAssigned)
		{
			if (isReloading)
			{
				return;
			}



			if (weaponManager.getCurrentWeapon().getCurrentAmmo() <= 0 || Input.GetButtonDown("Reload") && currentAmmo < maxAmmo)
			{
				if (Managers.Inventory.GetAmmoDict().ContainsKey(weaponManager.getCurrentAmmoType()))
				{
					if (Managers.Inventory.GetAmmoDict()[weaponManager.getCurrentAmmoType()] > 0)
					{
						StartCoroutine(Reload());
					}
				}
				_shooting = false;
				animator.SetBool("Shoot", false);
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
	private void BlendMove(float x, float y)
	{
		animator.SetFloat("VelX", x);
		animator.SetFloat("VelY", y);
	}

	/*Metodi aggiuntivi per sparare, ricaricare ed altro*/

	void Shoot()
	{
		animator.SetBool("Shoot", true);
		RaycastHit[] hits;
		Ray ray = new Ray(fpscam.transform.position, fpscam.transform.forward);
		hits = Physics.RaycastAll(ray);
		RaycastHit hit = new RaycastHit();
		weaponManager.getCurrentWeapon().consumeAmmo();

		if (hits.Length != 0)
		{
			bool first = true;
			for (int i = 0; i < hits.Length; i++)
			{
				if (!hits[i].transform.gameObject.GetComponent<TPSMovement2>() && first)
				{
					hit = hits[0];
					first = false;
				}
				else if (!hits[i].transform.gameObject.GetComponent<TPSMovement2>() && !first)
				{
					if (hits[i].distance < hit.distance)
					{
						hit = hits[i];
					}
				}
			}
			if (!first)
			{
				GameObject hitted = hit.transform.gameObject; //Mattia start
				if (hitted != null)
				{
					hitted.SendMessage("Hurt", damage, SendMessageOptions.DontRequireReceiver);
				}
			}
			if (hit.rigidbody != null)
			{
				hit.rigidbody.AddForce(-hit.normal * impactForce);
			}
			GameObject impactGO = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
			Destroy(impactGO, 0.5f);
			//Mattia end
			//Debug.Log(hit.transform.name);
		}

		_soundSource.PlayOneShot(shotSound);


	}

	IEnumerator Reload()
	{
		isReloading = true;
		moveSpeed = noSprint;
		_footStepSoundLength = 0.6f;
		running = false;
		//Debug.Log("Reloading...");

		IKController.ikActive = false;
		_soundSource.PlayOneShot(reloadSound);
		animator.SetBool("Shoot", false);
		animator.SetBool("Reloading", true);
		_shooting = false;

		yield return new WaitForSeconds(reloadTime);
		//Debug.Log("Reloading done");

		animator.SetBool("Reloading", false);

		//SOTTRAZIONE PROIETTILI DALL INVENTARIO
		Dictionary<string, int> ammo = Managers.Inventory.GetAmmoDict();
		if (ammo.ContainsKey(weaponManager.getCurrentAmmoType()))
		{
			if (ammo[weaponManager.getCurrentAmmoType()] >= maxAmmo - currentAmmo)
			{
				ammo[weaponManager.getCurrentAmmoType()] -= maxAmmo - currentAmmo;
				weaponManager.getCurrentWeapon().reloadAmmo(maxAmmo);
			}
			else if (ammo[weaponManager.getCurrentAmmoType()] > 0)
			{
				weaponManager.getCurrentWeapon().reloadAmmo(ammo[weaponManager.getCurrentAmmoType()] + currentAmmo);
				ammo[weaponManager.getCurrentAmmoType()] = 0;
			}
		}
		Managers.Inventory.somethingChanged = true;
		IKController.ikActive = true;
		isReloading = false;
	}

	IEnumerator WaitForFootSteps(float stepsLength)
	{
		_step = false;
		yield return new WaitForSeconds(stepsLength);
		_step = true;
	}

   

}

	

