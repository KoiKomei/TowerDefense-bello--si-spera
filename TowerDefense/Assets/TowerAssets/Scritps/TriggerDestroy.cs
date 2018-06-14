using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerDestroy : MonoBehaviour {


    public TurretBase node1;
    public TurretBase node2;
    public TurretBase node3;
    public TurretBase node4;
    public TurretBase node5;
    public TurretBase node6;
    public TurretBase node7;
    public TurretBase node8;
    public TurretBase node9;
    public TurretBase node10;
    public TurretBase node11;
    public TurretBase node12;
    public TurretBase node13;
    public TurretBase node14;
    public TurretBase node15;
    public TurretBase node16;
    public TurretBase node17;
    public TurretBase node18;
    public TurretBase node19;
    public TurretBase node20;


    [SerializeField] public Text turretNumber;
    private int number;

    private void OnTriggerEnter()
    {
        node1.DestroyTurret();
        node2.DestroyTurret();
        node3.DestroyTurret();
        node4.DestroyTurret();
        node5.DestroyTurret();
        node6.DestroyTurret();
        node7.DestroyTurret();
        node8.DestroyTurret();
        node9.DestroyTurret();
        node10.DestroyTurret();
        node11.DestroyTurret();
        node12.DestroyTurret();
        node13.DestroyTurret();
        node14.DestroyTurret();
        node15.DestroyTurret();
        node16.DestroyTurret();
        node17.DestroyTurret();
        node18.DestroyTurret();
        node19.DestroyTurret();
        node20.DestroyTurret();

        node1.enabled = false;
        node2.enabled = false;
        node3.enabled = false;
        node4.enabled = false;
        node5.enabled = false;
        node6.enabled = false;
        node7.enabled = false;
        node8.enabled = false;
        node9.enabled = false;
        node10.enabled = false;
        node11.enabled = false;
        node12.enabled = false;
        node13.enabled = false;
        node14.enabled = false;
        node15.enabled = false;
        node16.enabled = false;
        node17.enabled = false;
        node18.enabled = false;
        node19.enabled = false;
        node20.enabled = false;
    }

   
    public void SetNumber(int number)
    {
        this.number = number;
        turretNumber.text = number.ToString();
    }

    public int GetNumber()
    {
        return number;
    }
}
