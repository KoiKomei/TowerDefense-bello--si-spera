﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerEndArea1 : MonoBehaviour {

    // Use this for initialization
    [SerializeField] public Text runMessage;
    public GameObject Collider;
    public GameObject Portal1;
    public GameObject Portal2;
    public GameObject Portal3;
    public GameObject Portal4;

    public int enemyKill = 0;

    private float movementDown = -0.1f;
    private bool levelComplete = false;

    private IEnumerator OnTriggerEnter()
    {
        
        if (enemyKill<50) {
            runMessage.text = "          YOU HAVE TO CLEAN THE AREA";
            yield return new WaitForSeconds(3);
            runMessage.text = "";

        }
        if(enemyKill >= 50)
        {
            levelComplete = true;
            Collider.GetComponent<BoxCollider>().enabled = false;
        }

       

    }

    public void EnemyKilled()
    {
        enemyKill++;
    }


    public void Update()
    {
        if (levelComplete && Portal1.transform.position.y>-10) {
            Portal1.transform.Translate(0, movementDown, 0);
        }
        if (levelComplete && Portal2.transform.position.y > -10)
        {
            Portal2.transform.Translate(0, movementDown, 0);
        }
        if (levelComplete && Portal3.transform.position.y > -10)
        {
            Portal3.transform.Translate(0, movementDown, 0);
        }
        if (levelComplete && Portal4.transform.position.y > -10)
        {
            Portal4.transform.Translate(0, movementDown, 0);
        }


    }

}
