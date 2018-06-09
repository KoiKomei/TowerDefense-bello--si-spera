using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavTest : MonoBehaviour {

	// Use this for initialization
	public Transform goal;
	public float PlayerDetectionRadius;
	public Vector3 dest;

	NavMeshAgent agent;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();

		float randomOffsetX = Random.Range(-5f, 5f);
		float randomOffsetZ = Random.Range(-5f, 5f);
		dest = new Vector3(goal.position.x+randomOffsetX,goal.position.y,goal.position.z+randomOffsetZ);
		agent.destination = dest;
	}
	 
	void Update()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, PlayerDetectionRadius);
		//Debug.Log(colliders.Length);
		bool found=false;
		Collider player = null;
		foreach (Collider c in colliders)
		{
			if (c.GetComponentInParent<CharacterController>() != null)
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
			agent.destination = dest;
		}
	}
}
