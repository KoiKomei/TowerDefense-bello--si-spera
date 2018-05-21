using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControllerN : MonoBehaviour {

    [SerializeField] private GameObject enemyPrefab;
    private GameObject[] enemies;
    public int enemiesCount;

	// Use this for initialization
	void Start () {
        //enemiesCount = 5;
        //spawner = GetComponent<Spawner>();
        enemies = new GameObject[enemiesCount];
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null)
            {
                enemies[i] = Instantiate(enemyPrefab) as GameObject;
                enemies[i].transform.position = new Vector3(0f, 1f, 0f);
                float angle = Random.Range(0, 360);
                enemies[i].transform.Rotate(0, angle, 0);
                Debug.Log("Enemy " + i);
            }
        }
    }
}
