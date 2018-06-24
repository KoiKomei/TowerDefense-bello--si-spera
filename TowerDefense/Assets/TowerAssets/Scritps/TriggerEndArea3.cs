﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerEndArea3 : MonoBehaviour {

    [SerializeField] public Text runMessage;
    public GameObject Collider;
    public GameObject Portal1;
    public GameObject Portal2;

    private float movementDown = -0.1f;
    private bool levelComplete = false;

    private IEnumerator OnTriggerEnter()
    {

        if (Portal1.GetComponent<PortalSpawner>().GetWave()<3)
        {
            runMessage.text = "          YOU HAVE TO RESIST THE WAVES";
            yield return new WaitForSeconds(3);
            runMessage.text = "";

        }
        if (Portal1.GetComponent<PortalSpawner>().GetWave() == 3)
        {
            levelComplete = true;
            Collider.GetComponent<BoxCollider>().enabled = false;
            runMessage.text = "          GO HAEAD TO TAKE THE EXPLOSIVE TRUCK";
            yield return new WaitForSeconds(3);
            runMessage.text = "";
        }

    }

    public void Update()
    {
        if (levelComplete && Portal1.transform.position.y > -10)
        {
            Portal1.transform.Translate(0, movementDown, 0);
        }
        if (levelComplete && Portal2.transform.position.y > -10)
        {
            Portal2.transform.Translate(0, movementDown, 0);
        }


    }

}
