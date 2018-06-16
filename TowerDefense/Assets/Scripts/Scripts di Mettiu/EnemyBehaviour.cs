using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class EnemyBehaviour : MonoBehaviour,IEnemy {

	private NavMeshAgent agent;
	private Animator animator;

	public int MaxHealth = 10;
	private int Health;
	public int AttackDamage = 1;
	public float AttackFrequency = 1f;
	private float Speed;
	public float AttackRange = 1;

	private float maXHealthBar;
	private bool attacking = false;
	[SerializeField] private RectTransform HealthBar;

	public void Attack()
	{
	}

	public void Die()
	{
		agent.isStopped = true;
		animator.SetBool("Dead", true);
		Destroy(this.gameObject,5);
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

		maXHealthBar = HealthBar.sizeDelta.x;
		animator = GetComponent<Animator>();

		agent = GetComponent<NavMeshAgent>();
		Speed = agent.speed;

	}

	// Update is called once per frame
	void Update () {
		if (Health > 0) {
			if(agent.velocity.magnitude>=0 && agent.velocity.magnitude <= 0.2f && !attacking)
			{
				animator.SetFloat("Speed", 0);
			}
			else
			{
				animator.SetFloat("Speed", Speed);
			}

		}
	}
}
