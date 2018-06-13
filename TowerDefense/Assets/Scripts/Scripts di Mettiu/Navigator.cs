using System;
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
		
		if(!agent.pathPending && agent.remainingDistance < 0.5f)
		{
			GoToNext();
		}

		Collider[] colliders = Physics.OverlapSphere(transform.position, PlayerDetectionRadius);
		//Debug.Log(colliders.Length);
		bool found = false;
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
				agent.isStopped = true;
				agent.autoBraking = true;

			}
			else
			{
				agent.isStopped = false;
				agent.autoBraking = false;
			}
		}
		else
		{
			agent.destination = Waypoints[goingTo].position;
		}

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
