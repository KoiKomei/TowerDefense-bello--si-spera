﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayloadManager : MonoBehaviour, IGameManager{

    public ManagerStatus status { get; private set; }
    public int health { get; private set; }
    public int maxHealth { get; private set; }
    public int healthPackValue { get; private set; }
    public int barValueDamage { get; private set; }

    public void Startup()
    {
        Debug.Log("Payload Manager Starting...");
        health = 1000;
        maxHealth = 1000;
        healthPackValue = 1;
        status = ManagerStatus.Started;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
