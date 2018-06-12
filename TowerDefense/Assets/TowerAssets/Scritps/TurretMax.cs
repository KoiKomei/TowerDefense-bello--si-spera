using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMax : MonoBehaviour {


    private int turretMax;

	void Start () {
        turretMax = 2;
    }

    public void resetNumber () {
        turretMax = 2;
    }

    public int getNumber()
    {
        return turretMax;
    }
}
