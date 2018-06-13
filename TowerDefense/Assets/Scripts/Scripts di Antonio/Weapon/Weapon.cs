using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour{

    public string nome;
    public int damage;
    public float rateOfFire;
    public float rechargeTime;
    public int capacity;
    private int currentAmmo;
    public float impact;
    public bool isAutomatic;

    void Start() {

    }

    void Update() {
        
    }

    public void bugFix(){
        currentAmmo = capacity;
    }

    public string toString() {
        return nome + " " + damage + " " + capacity;    
    }

    public int getCurrentAmmo() {
        return currentAmmo;
    }

    public void consumeAmmo() {
        currentAmmo--;
    }

    public void reloadAmmo(int value) {
        currentAmmo = value;
    }
}
