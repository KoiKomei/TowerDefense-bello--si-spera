﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerFine : MonoBehaviour
{

    public GameObject GameController;

    private void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Human"))
        {
            GameController.GetComponent<GameController>().SetArea(5);
        }
    }
}