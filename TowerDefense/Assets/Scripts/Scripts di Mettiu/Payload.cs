using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

[RequireComponent(typeof(NavMeshAgent))]

public class Payload : MonoBehaviour {

	private NavMeshAgent agent;

	[SerializeField] private Transform[] Waypoints;
	public float DetectionRadius;
	public int StoppingNumberOfEnemies = 3;
	public float WaypointRadius = 10f;

	private int goingTo;

	// Use this for initialization
	void Start () {
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
}
