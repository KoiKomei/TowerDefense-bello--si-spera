using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SimpleEnemyBehaviour : MonoBehaviour,IEnemy {


	public void Attack(GameObject target)
	{

	}

	public void Die()
	{
		transform.Rotate(0, -75, 0);
		Destroy(this.gameObject, 1);
	}

	public void Hurt(int damage)
	{
		Die();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
