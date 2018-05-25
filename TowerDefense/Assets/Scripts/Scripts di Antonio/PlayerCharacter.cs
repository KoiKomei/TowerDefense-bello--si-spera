using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCharacter : MonoBehaviour {

    public int hp;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image fillImg;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Image damageImage;
    private Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    private float flashSpeed = 5f;
    private float barValueDamage;
    private Image healthBarBackground;
    private bool damaged;

    // Use this for initialization
    void Start () {
        barValueDamage = healthBar.maxValue / hp;
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
            damageImage.color = flashColor;
        } else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    public void Hurt(int damage){
        damaged = true;
        hp -= damage;
        healthBar.value -= barValueDamage;
    }

    public void Death() {
        fillImg.enabled = false;
        gameOverText.enabled = true;
        Time.timeScale = 0;
        healthBarBackground.color = Color.red;
    }

}
