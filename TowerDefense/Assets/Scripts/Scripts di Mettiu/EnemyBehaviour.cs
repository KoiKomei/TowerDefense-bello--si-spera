using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour,IEnemy {

	public int MaxHealth = 10;
	private int Health;
	public int AttackDamage = 1;
	private float Speed;

	private float maXHealthBar;
	[SerializeField] private RectTransform HealthBar;

	public void Attack()
	{
	}

	public void Die()
	{

	}

	public void Hurt(int damage)
	{
		Health -= damage;
		Health = Mathf.Clamp(Health, 0, MaxHealth);
		HealthBar.sizeDelta = new Vector2((maXHealthBar * Health) / MaxHealth, HealthBar.sizeDelta.y);
		if (Health <= 0)
		{
			Die();
		}
	}

	// Use this for initialization
	void Start()
	{
		Health = MaxHealth;
		Speed = 7f;

		maXHealthBar = HealthBar.sizeDelta.x;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
