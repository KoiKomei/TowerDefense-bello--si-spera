using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour{

    public string nome;
    public float rateOfFire;
    public int damage;
    public int capacity;
    public bool isAutomatic;

    private void Start() {
        
    }

    private void Update() {
        
    }

    public string toString() {
        return nome + " " + damage + " " + capacity;    
    }
}
