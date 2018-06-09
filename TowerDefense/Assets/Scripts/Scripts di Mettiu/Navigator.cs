using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

[RequireComponent(typeof(NavMeshAgent))]

public class Navigator : MonoBehaviour {

	private NavMeshAgent agent;

	[SerializeField] private Transform[] Waypoints;
	[SerializeField] private bool loop;

	private int goingTo;

	// Use this for initialization
	void Start () {
		Assert.IsNotNull(Waypoints);
		Assert.AreNotEqual(0, Waypoints.Length);

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
