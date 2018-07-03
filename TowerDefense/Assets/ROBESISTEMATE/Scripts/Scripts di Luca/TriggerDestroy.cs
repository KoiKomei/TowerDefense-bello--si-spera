using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerDestroy : MonoBehaviour {


    public TurretBase node1A;
    public TurretBase node1B;
    public TurretBase node1C;
    public TurretBase node1D;
    public TurretBase node1E;
    public TurretBase node1F;
    public TurretBase node1G;
    public TurretBase node1H;
    public TurretBase node1I;
    public TurretBase node1J;
    public TurretBase node1K;
    public TurretBase node1L;

    public TurretBase node2A;
    public TurretBase node2B;
    public TurretBase node2C;
    public TurretBase node2D;
    public TurretBase node2E;
    public TurretBase node2F;
    public TurretBase node2G;
    public TurretBase node2H;
    public TurretBase node2I;
    public TurretBase node2J;
    public TurretBase node2K;
    public TurretBase node2L;

    public TurretBase node3A;
    public TurretBase node3B;
    public TurretBase node3C;
    public TurretBase node3D;
    public TurretBase node3E;
    public TurretBase node3F;
    public TurretBase node3G;
    public TurretBase node3H;
    public TurretBase node3I;
    public TurretBase node3J;
    public TurretBase node3K;
    public TurretBase node3L;

    [SerializeField] public Text turretNumber;
    private int number;

    private bool passed = false;

    private void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Human")
        {
            Destroy2();
        }
        
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

    public void Destroy1()
    {
        node1A.DestroyTurret();
        node1B.DestroyTurret();
        node1C.DestroyTurret();
        node1D.DestroyTurret();
        node1E.DestroyTurret();
        node1F.DestroyTurret();
        node1G.DestroyTurret();
        node1H.DestroyTurret();
        node1I.DestroyTurret();
        node1J.DestroyTurret();
        node1K.DestroyTurret();
        node1L.DestroyTurret();

        node1A.enabled = false;
        node1B.enabled = false;
        node1C.enabled = false;
        node1D.enabled = false;
        node1E.enabled = false;
        node1F.enabled = false;
        node1G.enabled = false;
        node1H.enabled = false;
        node1I.enabled = false;
        node1J.enabled = false;
        node1K.enabled = false;
        node1L.enabled = false;
    }

    public void Destroy2()
    {
        node2A.DestroyTurret();
        node2B.DestroyTurret();
        node2C.DestroyTurret();
        node2D.DestroyTurret();
        node2E.DestroyTurret();
        node2F.DestroyTurret();
        node2G.DestroyTurret();
        node2H.DestroyTurret();
        node2I.DestroyTurret();
        node2J.DestroyTurret();
        node2K.DestroyTurret();
        node2L.DestroyTurret();
        
        node2A.enabled = false;
        node2B.enabled = false;
        node2C.enabled = false;
        node2D.enabled = false;
        node2E.enabled = false;
        node2F.enabled = false;
        node2G.enabled = false;
        node2H.enabled = false;
        node2I.enabled = false;
        node2J.enabled = false;
        node2K.enabled = false;
        node2L.enabled = false;
    }

    public void Destroy3()
    {
        node3A.DestroyTurret();
        node3B.DestroyTurret();
        node3C.DestroyTurret();
        node3D.DestroyTurret();
        node3E.DestroyTurret();
        node3F.DestroyTurret();
        node3G.DestroyTurret();
        node3H.DestroyTurret();
        node3I.DestroyTurret();
        node3J.DestroyTurret();
        node3K.DestroyTurret();
        node3L.DestroyTurret();

        node3A.enabled = false;
        node3B.enabled = false;
        node3C.enabled = false;
        node3D.enabled = false;
        node3E.enabled = false;
        node3F.enabled = false;
        node3G.enabled = false;
        node3H.enabled = false;
        node3I.enabled = false;
        node3J.enabled = false;
        node3K.enabled = false;
        node3L.enabled = false;
    }

}
