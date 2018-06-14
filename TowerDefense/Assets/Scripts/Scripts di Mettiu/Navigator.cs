﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyBehaviour))]

public class Navigator : MonoBehaviour {

	private NavMeshAgent agent;

	[SerializeField] private Transform[] Waypoints;
	[SerializeField] private bool loop;
	public float PlayerDetectionRadius;
	private float range;
	public float WaypointRadius=10f;

	private int goingTo;

	// Use this for initialization
	void Start () {
		Assert.IsNotNull(Waypoints);
		Assert.AreNotEqual(0, Waypoints.Length);

		range = GetComponent<EnemyBehaviour>().AttackRange;

		agent = GetComponent<NavMeshAgent>();
		agent.autoBraking = false;

		goingTo = -1;

		GoToNext();
	}

	// Update is called once per frame
	void Update () {

		bool found = false;




		if (!agent.pathPending && agent.remainingDistance < WaypointRadius)
		{

			foreach(Transform t in Waypoints)
			{
				if (agent.destination.x==t.position.x && agent.destination.z==t.position.z)
				{
					GoToNext();
					break;
				}
			}
		}

		Collider[] colliders = Physics.OverlapSphere(transform.position, PlayerDetectionRadius);
		//Debug.Log(colliders.Length);
		
		Collider player = null;
		foreach (Collider c in colliders)
		{
			GameObject target = c.gameObject;
			if (c.GetComponentInParent<TPSMovement>() != null)
			{
				found = true;
				player = c;
				break;
			}
		}
		if (found)
		{
			agent.destination = player.transform.position;

			if (agent.remainingDistance <= range)
			{

			}
			
			
		}
		else
		{
			agent.destination = Waypoints[goingTo].position;
		}

		if (found || (!loop && goingTo == Waypoints.Length - 1))
		{
			agent.stoppingDistance = range;
			agent.autoBraking = true;
			//agent.acceleration = -(agent.speed * 5 / 100);
		}
		else
		{
			agent.stoppingDistance = 0;
			agent.autoBraking = true;
		}
		//Debug.Log("go to: " + goingTo + " x: " + agent.destination.x + " z: " + agent.destination.z);
		//Debug.Log(agent.velocity.magnitude);
		
	}

	private void GoToNext()
	{
		if(!loop && goingTo == Waypoints.Length - 1)
		{
			agent.autoBraking = true;
			return;
		}
		goingTo=(goingTo+1)%Waypoints.Length;
		agent.destination = Waypoints[goingTo].position;
	}
}
