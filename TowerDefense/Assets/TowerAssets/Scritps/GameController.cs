﻿using System.Collections;
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

    public GameObject postoDiBlocco;

    private int area = 0;
     
    public void Update() {
        //Debug.Log(area);

        StartCoroutine(GameManager());
    }

    IEnumerator GameManager()
    {
        if (area == 4)
        {
            if (Portal1A.GetComponent<PortalSpawner>().GetWave() == 4)
            {
                area = 0;
                Destroy1();
                Collider1.GetComponent<BoxCollider>().enabled = false;
                payload.GetComponent<Payload>().enabled = true;
                runMessage.text = "PORTA IL CARICO ALLA ZONA DI ESPLOSIONE";
                yield return new WaitForSeconds(3);
                runMessage.text = "";
            }
        }

        if (area == 1)
        {
            if (Portal2.GetComponent<PortalSpawner>().GetWave() == 4)
            {
                area = 0;
                Destroy(postoDiBlocco);
                Destroy2();
                Collider2.GetComponent<BoxCollider>().enabled = false;
                payload.GetComponent<Payload>().enabled = true;
                runMessage.text = "PORTA IL CARICO ALLA ZONA DI ESPLOSIONE";
                yield return new WaitForSeconds(3);
                runMessage.text = "";
            }
        }

        if (area == 2)
        {
            if (Portal3A.GetComponent<PortalSpawner>().GetWave() == 4)
            {
                area = 0;
                Destroy3();
                Collider3.GetComponent<BoxCollider>().enabled = false;
                runMessage.text = "VAI AVANTI PER PORTARE IL CARICO A DESTINAZIONE";
                yield return new WaitForSeconds(3);
                runMessage.text = "";
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
            runMessage.text = "HAI SALVATO LA TERRA";
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

}
