using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField] public Text runMessage;

    public GameObject Collider1;
    public GameObject Collider2;
    public GameObject Collider3;

    public GameObject Portal3A;
    public GameObject Portal3B;
    public GameObject Portal2;
    public GameObject ParticlePortal2;
    public GameObject Portal1A;
    public GameObject ParticlePortal1A;
    public GameObject Portal1B;
    public GameObject Portal1C;
    public GameObject Portal1D;

    public GameObject ParticlePortal1D;
    public GameObject payload;
    public GameObject explosionEffect;

    private bool nextWaveA3 = false;
    private bool nextWaveA2 = false;
    private bool nextWaveA1 = false;

    private int area = 0;
     
    public void Update() {
        Debug.Log(area);

        StartCoroutine(GameManager());
        checkEndWave();
    }

    IEnumerator GameManager()
    {
        if (area == 2)
        {
            if (Portal1A.GetComponent<PortalSpawner>().GetWave() == 4)
            {
                Destroy1();
                Collider1.GetComponent<BoxCollider>().enabled = false;
                payload.GetComponent<Payload>().enabled = true;
                runMessage.text = "PORTA IL CARICO ALLA ZONA DI ESPLOSIONE";
                yield return new WaitForSeconds(3);
                runMessage.text = "";
                area = 0;
            }
        }

        if (area == 3)
        {
            if (Portal2.GetComponent<PortalSpawner>().GetWave() == 4)
            {
                Destroy2();
                Collider2.GetComponent<BoxCollider>().enabled = false;
                payload.GetComponent<Payload>().enabled = true;
                runMessage.text = "PORTA IL CARICO ALLA ZONA DI ESPLOSIONE";
                yield return new WaitForSeconds(3);
                runMessage.text = "";
                area = 0;
            }
        }

        if (area == 4)
        {
            if (Portal3A.GetComponent<PortalSpawner>().GetWave() == 4)
            {
                Destroy3();
                Collider3.GetComponent<BoxCollider>().enabled = false;
                runMessage.text = "VAI AVANTI PER PORTARE IL CARICO A DESTINAZIONE";
                yield return new WaitForSeconds(3);
                runMessage.text = "";
                area = 0;
            }
        }

        if (area == 5)
        {
            runMessage.text = "GRANDE!!! HAI PORTATO IL CARICO A DESTINAZIONE";
            yield return new WaitForSeconds(3);
            runMessage.text = "SCAPPA PRIMA DELL'ESPLOSIONE DEL CARICO";
            yield return new WaitForSeconds(3);

            for (int i = 60; i > 0; i--)
            {
                runMessage.text = " " + i + " ";
                yield return new WaitForSeconds(1);
            }
            Destroy();
            area = 0;
        }
    }

    public void SetArea(int i)
    {
        area = i;
    }

    public int GetArea()
    {
        return area;
    }

    private void Start()
    {
        explosionEffect.transform.position = payload.transform.position;
    }

    private void Destroy()
    {
        Destroy(payload);
        GameObject effect = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(effect, 5f);
    }

    private void Destroy1()
    {
        Destroy(Portal1A);
        Destroy(ParticlePortal1A);
        Destroy(Portal1B);
        Destroy(Portal1C);
        Destroy(Portal1D);
        Destroy(ParticlePortal1D);
    }

    private void Destroy2()
    {
        Destroy(Portal2);
        Destroy(ParticlePortal2);
    }

    private void Destroy3()
    {
        Destroy(Portal3A);
        Destroy(Portal3B);
    }



    private void checkEndWave()
    {
        int enemyToDestroy;
        int enemyDestroyed;

        if (area == 1)
        {

            enemyToDestroy = Portal1A.GetComponent<PortalSpawner>().GetEnemies().Count*4;
            enemyDestroyed = 0;

            foreach (GameObject i in Portal1A.GetComponent<PortalSpawner>().GetEnemies())
            {
                if (i.GetComponent<EnemyBehaviour>() && i == null)
                {
                    enemyDestroyed++;
                }
            }
            foreach (GameObject i in Portal1B.GetComponent<PortalSpawner>().GetEnemies())
            {
                if (i.GetComponent<EnemyBehaviour>() && i == null)
                {
                    enemyDestroyed++;
                }
            }
            foreach (GameObject i in Portal1C.GetComponent<PortalSpawner>().GetEnemies())
            {
                if (i.GetComponent<EnemyBehaviour>() && i == null)
                {
                    enemyDestroyed++;
                }
            }
            foreach (GameObject i in Portal1D.GetComponent<PortalSpawner>().GetEnemies())
            {
                if (i.GetComponent<EnemyBehaviour>() && i == null)
                {
                    enemyDestroyed++;
                }
            }

            if (enemyDestroyed == enemyToDestroy)
            {
                nextWaveA1 = true;
                Debug.Log("nextWAVE");
                enemyDestroyed = 0;

                Portal1A.GetComponent<PortalSpawner>().SetOnGoingFalse();
                int waveA = Portal1A.GetComponent<PortalSpawner>().GetWave();
                waveA++;
                Portal1A.GetComponent<PortalSpawner>().SetWave(waveA);

                Portal1B.GetComponent<PortalSpawner>().SetOnGoingFalse();
                int waveB = Portal1B.GetComponent<PortalSpawner>().GetWave();
                waveB++;
                Portal1B.GetComponent<PortalSpawner>().SetWave(waveB);

                Portal1C.GetComponent<PortalSpawner>().SetOnGoingFalse();
                int waveC = Portal1C.GetComponent<PortalSpawner>().GetWave();
                waveC++;
                Portal1C.GetComponent<PortalSpawner>().SetWave(waveC);

                Portal1D.GetComponent<PortalSpawner>().SetOnGoingFalse();
                int waveD = Portal1D.GetComponent<PortalSpawner>().GetWave();
                waveD++;
                Portal1D.GetComponent<PortalSpawner>().SetWave(waveD);
                
            }

        }

        if (area == 2)
        {

            enemyToDestroy = Portal2.GetComponent<PortalSpawner>().GetEnemies().Count * 4;
            enemyDestroyed = 0;

            foreach (GameObject i in Portal2.GetComponent<PortalSpawner>().GetEnemies())
            {
                if (i.GetComponent<EnemyBehaviour>() && i == null)
                {
                    enemyDestroyed++;
                }
            }

            if (enemyDestroyed == enemyToDestroy)
            {
                nextWaveA2 = true;
                Debug.Log("nextWAVE");
                enemyDestroyed = 0;

                Portal2.GetComponent<PortalSpawner>().SetOnGoingFalse();
                int waveA = Portal2.GetComponent<PortalSpawner>().GetWave();
                waveA++;
                Portal2.GetComponent<PortalSpawner>().SetWave(waveA);
            }

        }

        if (area == 3)
        {

            enemyToDestroy = Portal3A.GetComponent<PortalSpawner>().GetEnemies().Count * 4;
            enemyDestroyed = 0;

            foreach (GameObject i in Portal3A.GetComponent<PortalSpawner>().GetEnemies())
            {
                if (i.GetComponent<EnemyBehaviour>() && i == null)
                {
                    enemyDestroyed++;
                }
            }
            foreach (GameObject i in Portal3B.GetComponent<PortalSpawner>().GetEnemies())
            {
                if (i.GetComponent<EnemyBehaviour>() && i == null)
                {
                    enemyDestroyed++;
                }
            }

            if (enemyDestroyed == enemyToDestroy)
            {
                nextWaveA3 = true;
                Debug.Log("nextWAVE");
                enemyDestroyed = 0;

                Portal3A.GetComponent<PortalSpawner>().SetOnGoingFalse();
                int waveA = Portal3A.GetComponent<PortalSpawner>().GetWave();
                waveA++;
                Portal3A.GetComponent<PortalSpawner>().SetWave(waveA);

                Portal3B.GetComponent<PortalSpawner>().SetOnGoingFalse();
                int waveB = Portal3B.GetComponent<PortalSpawner>().GetWave();
                waveB++;
                Portal3B.GetComponent<PortalSpawner>().SetWave(waveB);
            }

        }

        if (Portal1A.GetComponent<PortalSpawner>().GetStart())
        {
            area = 1;
            Portal3A.GetComponent<PortalSpawner>().SetStart(false);
            Debug.Log("AREA 1 STARTED");
        }
        if (Portal2.GetComponent<PortalSpawner>().GetStart())
        {
            area = 2;
            Portal3A.GetComponent<PortalSpawner>().SetStart(false);
            Debug.Log("AREA 2 STARTED");
        }
        if (Portal3A.GetComponent<PortalSpawner>().GetStart())
        {
            area = 3;
            Portal3A.GetComponent<PortalSpawner>().SetStart(false);
            Debug.Log("AREA 3 STARTED");
        }

    }
}
