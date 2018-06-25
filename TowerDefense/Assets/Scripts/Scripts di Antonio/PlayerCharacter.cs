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

    [SerializeField] private Slider healthBar;

    // Use this for initialization
    void Start () {

        hp = Managers.Player.health;
        healthBar.maxValue = Managers.Player.maxHealth;
        healthPackValue = Managers.Player.healthPackValue;
        //barValueDamage = Managers.Player.barValueDamage;

        healthBarBackground = healthBar.GetComponentInChildren<Image>();   

    }
	
	// Update is called once per frame
	void Update () {

        if (hp <= 0)
        {
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
        hp -= damage;
        healthBar.value -= damage;
		Debug.Log("ouch");
    }

    public void Death() {
        Time.timeScale = 0;
        healthBarBackground.color = Color.red;
    }

}
