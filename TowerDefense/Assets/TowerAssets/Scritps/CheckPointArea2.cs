﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPointArea2 : MonoBehaviour {

    [SerializeField] public Text runMessage;
    public GameObject fountain;
    public GameObject payload;
    public GameObject payloadLife;
    public GameObject ColliderA;
    public GameObject ColliderB;
    public GameObject TriggerInizioArea2;


    public float range = 5;
    private int cont = 0;
    private bool save = false;

    public void Start()
    {
        if (PlayerPrefs.GetInt("ContinueArea2") == 1)
        {
            payloadLife.SetActive(true);
            ColliderA.GetComponent<BoxCollider>().enabled = false;
            ColliderB.GetComponent<BoxCollider>().enabled = true;
            TriggerInizioArea2.GetComponent<TriggerStartArea2>().enabled = false;
            PlayerPrefs.SetInt("ContinueArea2", 0);
        }
    }

    private IEnumerator OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Human"))
        {
            if (cont == 0 && save)
            {
                runMessage.text = "CHECKPOINT RAGGIUNTO";
                yield return new WaitForSeconds(3);
                runMessage.text = "";

                //salva posizione player (c.transform.position.x, c.transform.position.y, c.transform.position.z) e payload (payload.transform.position.x, payload.transform.position.y, payload.transform.position.z)
                PlayerPrefs.SetFloat("PlayerPosX", 236.75f);
                PlayerPrefs.SetFloat("PlayerPosY", 1.02f);
                PlayerPrefs.SetFloat("PlayerPosZ", 326.19f);
                PlayerPrefs.SetInt("ContinueArea2", 1);
                //Debug.Log(c.transform.position.x+"posCheck");
                fountain.GetComponent<fountain>().Activate();
                cont++;
            }
        }


    }

    public void Update()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, range);

        foreach (Collider c in colliders)
        {
            GameObject target = c.gameObject;
            if (c.GetComponentInParent<Payload>() != null)
            {
                save = true;
            }
        }

    }
}