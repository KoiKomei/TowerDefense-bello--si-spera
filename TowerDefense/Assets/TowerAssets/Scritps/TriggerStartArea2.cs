﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerStartArea2 : MonoBehaviour {

    [SerializeField] public Text runMessage;
    public GameObject Collider;
    public GameObject Portal1;
    public GameObject ParticlePortal1;

    private float movementUp = 0.1f;
    private bool levelStart = false;

    private IEnumerator OnTriggerEnter()
    {
        runMessage.text = "          YOU HAVE TO CLEAN THE AREA";
        yield return new WaitForSeconds(3);
        runMessage.text = "";
        levelStart = true;
        Collider.GetComponent<BoxCollider>().enabled = true;

    }

    public void Update()
    {
        if (levelStart && Portal1.transform.position.y < 4.5)
        {
            Portal1.transform.Translate(0, movementUp, 0);
            ParticlePortal1.transform.Translate(0, movementUp, 0);
        }
    }

}
