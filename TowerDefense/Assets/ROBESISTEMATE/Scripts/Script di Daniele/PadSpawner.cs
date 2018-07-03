using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadSpawner : MonoBehaviour {

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timeForSpawn;
    public int enemyCount; // numero di nemici (escluso respawn)
    private GameObject[] _enemy;
    private int contMax = 100; //numero massimo di nemici spawnabili (compreso respawn)
    int cont = 0;
    public float startRotation;

    // Use this for initialization
    void Start () {

        _enemy = new GameObject[enemyCount];
	}
	
	// Update is called once per frame
	void Update () {
        
        StartCoroutine(Spawner(timeForSpawn));
	}

    IEnumerator Spawner(float wait)
    {
        for (int i = 0; i < _enemy.Length && cont < contMax; i++)
        {
           if (this.tag=="pad")
            {
               yield return new WaitForSeconds(wait);

               if (_enemy[i] == null)
               {
                    GameObject e = Instantiate(enemyPrefab) as GameObject;
                    e.transform.Rotate(0, startRotation, 0);
                    _enemy[i] = e;
                    _enemy[i].transform.position = new Vector3(this.transform.position.x, 1f, this.transform.position.z);
                    cont++;
                
               }
            }
        }
    }
}


