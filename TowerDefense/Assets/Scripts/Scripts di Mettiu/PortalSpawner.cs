using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class PortalSpawner : MonoBehaviour {

	[SerializeField] private Transform[] Waypoints;
	[SerializeField] private GameObject[] enemyPrefab;
	[SerializeField] private int[] nEnemyPerType;
    [SerializeField] public Text runMessage;
    [SerializeField] private GameObject camera;
	[SerializeField] private GameObject AttaccoAldo;

    public int Waves=3;
	public float SpawnInterval = 1;

	
	private int[] enemies;
    public GameController gc;

    private bool onGoing=false;
    private bool areaStarted = false;
	private ArrayList list;
	private int wave;

	// Use this for initialization
	void Start () {
		wave = 1;
		list=GetComponentInParent<WaveController>().getList();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (!onGoing && wave<=Waves && this.transform.position.y > 4)
		{
            runMessage.text = "WAVE: " + wave;
            int nEnemies = 0;
			for (int i = 0; i < nEnemyPerType.Length; i++)
			{
				nEnemies += nEnemyPerType[i];
			}
			enemies = new int[nEnemies];
            int index = 0;
			for (int i = 0; i < nEnemyPerType.Length; i++)
			{
				for (int j = 0; j < nEnemyPerType[i]; j++)
				{
					enemies[index] = i;
					index++;
				}
			}
			shuffle(enemies, 10);
			
			for(int i=0;i<nEnemyPerType.Length;i++)
			{
				nEnemyPerType[i] += 1;
			}

			
			StartCoroutine(SpawnEnemies(SpawnInterval));
		}

    }

	private void shuffle(int[] a, int times)
	{
		for(int t = 0; t < times; t++)
		{
			for(int i = 0; i < a.Length; i++)
			{
				int temp = a[i];
				int r = (int)Random.Range(0, a.Length);
				a[i] = a[r];
				a[r] = temp;
			}
		}
	}

	IEnumerator SpawnEnemies(float interval)
	{
		int j = 0;
        foreach (int i in enemies) {
			if (this.transform.position.y > 4)
			{
				if (enemies[i]==0) { 
					GameObject enemy = Instantiate(enemyPrefab[i]);
					j++;
					areaStarted = true;
                    enemy.GetComponent<EnemyBehaviour>().MaxHealth = 25;
                    enemy.GetComponent<EnemyBehaviour>().AttackDamage = 2;
                    enemy.GetComponent<EnemyBehaviour>().AttackRange = 2;
                    enemy.GetComponent<Navigator>().enabled = false;
					enemy.GetComponent<Navigator>().PlayerDetectionRadius = 5;
					enemy.GetComponent<NavMeshAgent>().enabled = false;
					enemy.GetComponent<NavMeshAgent>().radius = 2;
					enemy.GetComponent<NavMeshAgent>().baseOffset=0.1f;
					enemy.GetComponentInChildren<LookAt>().Player = camera.transform;
					if (j % 2 == 0)
					{
						enemy.transform.position = new Vector3(this.transform.position.x + 1f, 1f, this.transform.position.z + 1f);
					}
					else
					{
						enemy.transform.position = new Vector3(this.transform.position.x - 1f, 1f, this.transform.position.z - 1f);
					}
					enemy.GetComponent<Navigator>().enabled = true;
					enemy.GetComponent<NavMeshAgent>().enabled = true;
					enemy.GetComponent<Navigator>().setWaypoints(Waypoints);

					list.Add(enemy);
					onGoing = true;
				}
				if (enemies[i] == 1)
				{
					GameObject enemy = Instantiate(enemyPrefab[i]);
					j++;
					areaStarted = true;
					enemy.GetComponent<EnemyBehaviour>().MaxHealth = 10;
                    enemy.GetComponent<EnemyBehaviour>().AttackDamage = 1;
                    enemy.GetComponent<EnemyBehaviour>().AttackRange = 5;
					enemy.GetComponent<EnemyBehaviour>().setAttaccoAldo(AttaccoAldo);
					enemy.GetComponent<Navigator>().enabled = false;
					enemy.GetComponent<Navigator>().PlayerDetectionRadius = 5;
					enemy.GetComponent<NavMeshAgent>().enabled = false;
					enemy.GetComponent<NavMeshAgent>().radius = 2;
					enemy.GetComponent<NavMeshAgent>().baseOffset = 0.1f;
					enemy.GetComponentInChildren<LookAt>().Player = camera.transform;
					if (j % 2 == 0)
					{
						enemy.transform.position = new Vector3(this.transform.position.x + 1f, 1f, this.transform.position.z + 1f);
					}
					else
					{
						enemy.transform.position = new Vector3(this.transform.position.x - 1f, 1f, this.transform.position.z - 1f);
					}
					enemy.GetComponent<Navigator>().enabled = true;
					enemy.GetComponent<NavMeshAgent>().enabled = true;
					enemy.GetComponent<Navigator>().setWaypoints(Waypoints);

					list.Add(enemy);
					onGoing = true;
				}
				if (enemies[i] == 2)
				{
					GameObject enemy = Instantiate(enemyPrefab[i]);
					j++;
					areaStarted = true;
					enemy.GetComponent<EnemyBehaviour>().MaxHealth = 40;
					enemy.GetComponent<EnemyBehaviour>().AttackDamage = 5;
					enemy.GetComponent<EnemyBehaviour>().AttackRange = 2;
					enemy.GetComponent<Navigator>().enabled = false;
					enemy.GetComponent<Navigator>().PlayerDetectionRadius = 0;
					enemy.GetComponent<NavMeshAgent>().enabled = false;
					enemy.GetComponent<NavMeshAgent>().radius = 2;
					enemy.GetComponent<NavMeshAgent>().baseOffset = 0.1f;
					enemy.GetComponentInChildren<LookAt>().Player = camera.transform;
					if (j % 2 == 0)
					{
						enemy.transform.position = new Vector3(this.transform.position.x + 1f, 1f, this.transform.position.z + 1f);
					}
					else
					{
						enemy.transform.position = new Vector3(this.transform.position.x - 1f, 1f, this.transform.position.z - 1f);
					}
					enemy.GetComponent<Navigator>().enabled = true;
					enemy.GetComponent<NavMeshAgent>().enabled = true;
					enemy.GetComponent<Navigator>().setWaypoints(Waypoints);

					list.Add(enemy);
					onGoing = true;
				}
			}
			yield return new WaitForSeconds(interval);
		}
        if (wave >= Waves)
        {
            runMessage.text = "";
        }

    }


    public int GetWave()
    {
        return wave;
    }

    public void SetWave(int w)
    {
        wave = w;
    }

    public void SetOnGoingFalse()
    {
        onGoing=false;
    }

	public bool getOnGoing()
	{
		return onGoing;
	}
    
    public void SetStart(bool val)
    {
        areaStarted = val;
    }

    public bool GetStart()
    {
        return areaStarted;
    }

}
