﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]

public class Payload : MonoBehaviour {

    public int hp;
    private NavMeshAgent agent;
	private float maxHealth;
	private float Health;
    private int healthPackValue;
    private int barValueDamage;
    private Image healthBarBackground;

	[SerializeField] UIController UI;
    [SerializeField] private Transform[] Waypoints;
	public float DetectionRadius;
	public int StoppingNumberOfEnemies = 3;
	public float WaypointRadius = 10f;

	private int goingTo;
    private bool arrived = false;
    private int cont=0;

    [SerializeField] private Slider healthBarPayload;

    // Use this for initialization
    void Start () {


        hp = Managers.Payload.maxHealth;
        healthBarPayload.maxValue = Managers.Payload.maxHealth;
        healthPackValue = Managers.Payload.healthPackValue;

        healthBarBackground = healthBarPayload.GetComponentInChildren<Image>();

        Assert.IsNotNull(Waypoints);
		Assert.AreNotEqual(0, Waypoints.Length);

		agent = GetComponent<NavMeshAgent>();

		goingTo = -1;

		GoToNext();

		
	}
	
	// Update is called once per frame
	void Update () {
		bool found = false;

		Collider[] colliders = Physics.OverlapSphere(transform.position, DetectionRadius);
		//Debug.Log(colliders.Length);
		int enemyCount=0;
		foreach (Collider c in colliders)
		{
			GameObject target = c.gameObject;
			if (c.GetComponentInParent<TPSMovement2>() != null)
			{
				found = true;
			}
			else if (c.GetComponent<EnemyBehaviour>()!=null)
			{
				enemyCount++;
			}
		}

		if(!found || enemyCount >= StoppingNumberOfEnemies)
		{
			agent.isStopped = true;
		}
		else
		{
			agent.isStopped = false;
		}

		if (!agent.pathPending && agent.remainingDistance < WaypointRadius)
		{
					GoToNext();

        }
        if (agent.remainingDistance < 1 && goingTo == Waypoints.Length - 1)
        {
            if (cont == 0)
            {
                arrived = true;
                cont++;
            }
        }

    }

	private void GoToNext()
	{
		if (goingTo == Waypoints.Length - 1)
		{
			agent.autoBraking = true;
			return;
		}
		goingTo = (goingTo + 1) % Waypoints.Length;
		agent.destination = Waypoints[goingTo].position;
	}

	public void Hurt(int damage)
	{
		hp -= damage;
        healthBarPayload.value -= damage;
        if (hp <= 0)
		{
			StartCoroutine(Lose());
		}
	}

	IEnumerator Lose()
	{
		yield return new WaitForSeconds(1);
		UI.SendMessage("lose2");
		Time.timeScale = 0;
		
	}

	public bool GetArrived()
    {
        return arrived;
    }

    public void SetArrived(bool b)
    {
        arrived = b;
    }
}
