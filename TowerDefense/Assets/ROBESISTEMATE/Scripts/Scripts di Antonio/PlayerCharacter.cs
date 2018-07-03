using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCharacter : MonoBehaviour {

    public int hp;
    private Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    private float flashSpeed = 5f;
    private int healthPackValue;
    private int barValueDamage;
    private Image healthBarBackground;
    private bool damaged;
    private Animator anim;

    public static bool dead;

   

    private AudioSource _sound;


	[SerializeField] UIController UI;
	[SerializeField] private Slider healthBar;
	[SerializeField] private AudioClip deathsound;
    [SerializeField] private AudioClip oof;

    // Use this for initialization
    void Start () {
        dead = false;
        _sound = GetComponent<AudioSource>();
        hp = Managers.Player.health;
        healthBar.maxValue = Managers.Player.maxHealth;
        healthPackValue = Managers.Player.healthPackValue;
        //barValueDamage = Managers.Player.barValueDamage;
        anim = GetComponent<Animator>();

        healthBarBackground = healthBar.GetComponentInChildren<Image>();

        _sound.volume = PlayerPrefs.GetFloat("SFXVolume");
	

    }
	
	// Update is called once per frame
	void Update () {

        if (hp <= 0  && !dead)
        {

            dead = true;
            Death();
            
        }
        if (damaged)
        {
           
        } else
        {
            
        }
        damaged = false;

        if (Input.GetKeyDown(KeyCode.H) && Managers.Inventory.GetConsumablesCount("healthpotion") > 0) {
            hp += healthPackValue;
            healthBar.value += (barValueDamage * healthPackValue);
            if (hp > Managers.Player.health) {
                hp = Managers.Player.health;
                healthBar.value = healthBar.maxValue;
            }
            Managers.Inventory.ConsumeItem("healthpotion", Categoria.Consumable);
        }
    }

    public void Hurt(int damage){
        damaged = true;
        if (!dead)
        {
            _sound.PlayOneShot(oof);
        }
        hp -= damage;
        healthBar.value -= damage;
		Debug.Log("ouch");
    }

    public void UsePotion(int life)
    {
        hp += life;
        healthBar.value += life;
        Debug.Log("ahhhh");
    }


    public void Death() {
        anim.SetBool("Death", true);
        IKController.ikActive = false;
		_sound.PlayOneShot(deathsound);
		Managers.Audio.PlayLevelMusic();
		StartCoroutine(Lose());
    }

	IEnumerator Lose()
	{
		yield return new WaitForSeconds(3);
		UI.SendMessage("lose1");
		Time.timeScale = 0;

	}
   
}
