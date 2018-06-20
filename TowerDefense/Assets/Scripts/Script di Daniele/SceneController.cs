using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timeForSpawn;
    public int enemyCount; // numero di nemici (escluso respawn)
    private GameObject[] _enemy;
    private int contMax = 100; //numero massimo di nemici spawnabili (compreso respawn)
    int cont = 0;

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
           if(this.tag=="portal") { 
                if (this.transform.position.y > 4) {
                    yield return new WaitForSeconds(wait);

                    if (_enemy[i] == null)
                    {
                        _enemy[i] = Instantiate(enemyPrefab) as GameObject;
                        _enemy[i].transform.position = new Vector3(this.transform.position.x + 0.5f, 0.5f, this.transform.position.z + 0.5f);
                        float angle = Random.Range(0, 360);
                        _enemy[i].transform.Rotate(0, angle, 0);
                        cont++;
                    }
                }
            }
            else if (this.tag=="pad")
            {
               yield return new WaitForSeconds(wait);

               if (_enemy[i] == null)
               {
                    _enemy[i] = Instantiate(enemyPrefab) as GameObject;
                    _enemy[i].transform.position = new Vector3(this.transform.position.x, 0.5f, this.transform.position.z);
                    float angle = Random.Range(0, 360);
                    _enemy[i].transform.Rotate(0, angle, 0);
                    cont++;
                
               }
            }
        }
    }
}


