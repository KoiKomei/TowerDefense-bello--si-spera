﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class EnemyBehaviour : MonoBehaviour,IEnemy {

	private NavMeshAgent agent;
	private Animator animator;
	private AnimationClip atkClip;

    public int MaxHealth = 25;
	private int Health;
	public int AttackDamage = 1;
	public float AttackFrequency = 1f;
	private float Speed;
	public float AttackRange = 5;
    public bool isDead = false;
	private float maXHealthBar;
	private bool attacking = false;
	[SerializeField] private GameObject AttaccoAldo;
	[SerializeField] private RectTransform HealthBar;

	public void Attack(GameObject target)
	{
		StartCoroutine(WaitAndAttack(target));
	}

	public void Die()
	{
		agent.isStopped = true;
		animator.SetBool("Dead", true);
		GetComponentInChildren<Navigator>().enabled = false;
		GetComponentInChildren<EnemyCursor>().gameObject.SetActive(false);
        Destroy(this.gameObject,5);
    }

	public void Hurt(int damage)
	{
		Health -= damage;
		Health = Mathf.Clamp(Health, 0, MaxHealth);
		HealthBar.sizeDelta = new Vector2((maXHealthBar * Health) / MaxHealth, HealthBar.sizeDelta.y);
		if (Health <= 0 && !isDead)
		{
            isDead = true;
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

		foreach(AnimationClip c in animator.runtimeAnimatorController.animationClips)
		{
			if (c.name == "Attack")
			{
				atkClip = c;
				break;
			}
			
		}

	}

	// Update is called once per frame
	void Update () {
		if (Health > 0) {
			if(agent.velocity.magnitude>=0 && agent.velocity.magnitude <= 0.2f)
			{
				animator.SetFloat("Speed", 0);
			}
			else
			{
				animator.SetFloat("Speed", Speed);
			}

		}

    }

	private IEnumerator WaitAndAttack(GameObject target)
	{
		//animator.SetFloat("Speed", 0);
		animator.SetBool("Attack", true);
		attacking = true;

		yield return new WaitForSeconds(atkClip.length-1.5f);
		if (!(AttackRange >= 3))
		{
			target.SendMessage("Hurt", AttackDamage, SendMessageOptions.DontRequireReceiver);
		}
		if (AttackRange >= 3)
		{
			GameObject att=Instantiate(AttaccoAldo) as GameObject;
			att.transform.position = transform.TransformPoint(new Vector3(0,0.5f,1));
			att.transform.rotation = transform.rotation;
		}
		//Debug.Log(this.name+" Attacked " +target.name);
		yield return new WaitForSeconds(1f);

		attacking = false;
		animator.SetBool("Attack", false);

		yield return new WaitForSeconds(AttackFrequency);
		
		//animator.SetFloat("Speed", Speed);
	}

	public bool isAttacking()
	{
		return attacking;
	}
}
