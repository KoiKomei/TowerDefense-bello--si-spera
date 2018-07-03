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
	public float PlayerDetectionRadius=5;
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
				if (agent.destination.x==t.position.x && agent.destination.z==t.position.z && goingTo!= Waypoints.Length - 1)
				{
					GoToNext();
					
					break;
				}
			}
		}

		Collider[] colliders = Physics.OverlapSphere(transform.position, PlayerDetectionRadius);
		//Debug.Log(colliders.Length);
		
		Collider player = null;
		if (GetComponent<EnemyBehaviour>().isAttacking())
		{
			agent.isStopped = true;
		}
		else
		{
			agent.isStopped = false;
		}
		foreach (Collider c in colliders)
		{
			GameObject target = c.gameObject;
			if (c.GetComponentInParent<TPSMovement2>() != null)
			{
				found = true;
				player = c;
				break;
			}
		}
		if (found)
		{
			agent.destination = player.transform.position;

			
			
			
		}
		else
		{
			agent.destination = Waypoints[goingTo].position;
		}

		if (found || (!loop && goingTo == Waypoints.Length - 1))
		{
			
			agent.stoppingDistance = range;
			agent.autoBraking = true;
			agent.radius = 0.3f;

			
			if ((agent.remainingDistance <= range) && !GetComponent<EnemyBehaviour>().isAttacking())
			{
				
				if (found)
				{
					GetComponent<EnemyBehaviour>().Attack(player.gameObject);
				}
				else
				{
					GetComponent<EnemyBehaviour>().Attack(Waypoints[Waypoints.Length-1].gameObject);
				}
			}
			if (!found && goingTo == Waypoints.Length - 1 && Waypoints[Waypoints.Length - 1].gameObject.GetComponent<Payload>() != null)
			{
				Ray ray = new Ray(transform.position, transform.forward);
				RaycastHit hit;

				if (Physics.Raycast(ray, out hit))
				{
					
					GameObject hitObject = hit.transform.gameObject;

					if (hitObject.GetComponent<Payload>() && hit.distance<=range && !GetComponent<EnemyBehaviour>().isAttacking())
					{
						GetComponent<EnemyBehaviour>().Attack(Waypoints[Waypoints.Length - 1].gameObject);
						agent.destination = new Vector3(hit.point.x,agent.destination.y, hit.point.z);
						
					}
					
				}
			}

		}
		else
		{
			agent.stoppingDistance = 0;
			agent.autoBraking = true;
			agent.radius = 2f;
			//payloadFound = false;
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
	public void setWaypoints(Transform[] w)
	{
		Waypoints = w;
	}
}
