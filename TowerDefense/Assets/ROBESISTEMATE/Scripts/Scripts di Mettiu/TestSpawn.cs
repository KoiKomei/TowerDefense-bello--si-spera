using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : MonoBehaviour {

	[SerializeField] private Transform Spawner;
	[SerializeField] private Transform goal;
	[SerializeField] private GameObject EnemyPrefab;

	public int N_Enemies;

	private Vector3 spawnPosition;


	private GameObject[] enemies;

	// Use this for initialization
	void Start () {
		enemies = new GameObject[N_Enemies];
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < enemies.Length; i++)
		{
			if (enemies[i] == null)
			{
				float randomOffsetX = Random.Range(-5f, 5f);
				float randomOffsetZ = Random.Range(-5f, 5f);
				spawnPosition = new Vector3(Spawner.position.x + randomOffsetX, Spawner.position.y, Spawner.position.z + randomOffsetZ);

				enemies[i] = Instantiate(EnemyPrefab) as GameObject;
				enemies[i].GetComponent<NavTest>().goal = goal;
				enemies[i].transform.position = spawnPosition;
			}
		}
		
	}
}
