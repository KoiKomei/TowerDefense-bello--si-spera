using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager {

    public ManagerStatus status { get; private set; }
    public int health { get; private set; }
    public int maxHealth { get; private set; }
    public int healthPackValue { get; private set; }
    public int barValueDamage { get; private set; }

    public void Startup() {
        Debug.Log("Player Manager Starting...");
        health = 5;
        maxHealth = 100;
        healthPackValue = 2;
        barValueDamage = maxHealth / health;
        status = ManagerStatus.Started;
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
