using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDestroy : MonoBehaviour {


    public TurretBase node1;
    public TurretBase node2;
    public TurretBase node3;
    public TurretBase node4;
    private int number;

    private void OnTriggerEnter()
    {
        node1.DestroyTurret();
        node2.DestroyTurret();
        node3.DestroyTurret();
        node4.DestroyTurret();
    }

   
    public void SetNumber(int number)
    {
        this.number = number;
    }

    public int GetNumber()
    {
        return number;
    }
}
