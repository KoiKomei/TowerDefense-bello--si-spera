using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour{

    public string nome;
    public int damage;
    public float rateOfFire;
    public float rechargeTime;
    public int capacity;
    public int currentAmmo;
    public float impact;
    public bool isAutomatic;

    private void Start() {

    }

    private void Update() {
        
    }

    public string toString() {
        return nome + " " + damage + " " + capacity;    
    }
}
