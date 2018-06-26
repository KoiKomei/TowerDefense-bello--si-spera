using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBase : MonoBehaviour {

    public Color hoverColor;
    public Vector3 positionOffset;
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public GameObject turretGhost;
    public Turret bullet;
    public Turret rocket;
    public Turret laser;

    public TriggerDestroy triggerController;

    public GameObject destroyEffect;

    private bool builded;
    private bool selected;

    private Renderer rend;
    private Color startColor;

    private int type;
    private int turretNumber;


    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        builded = false;
        type = 1;
        selected = false;
        triggerController.GetComponent<TriggerDestroy>().SetNumber(5);
        turretNumber = triggerController.GetComponent<TriggerDestroy>().GetNumber();
    }



    void Update()
    {
        
        turretNumber = triggerController.GetComponent<TriggerDestroy>().GetNumber();
        if (!builded && turretNumber>0 && selected)
        {
            if (Input.GetKeyDown("q"))
            {
                Destroy(turretGhost);
                if (type == 1)
                    type = 2;
                else if (type == 2)
                    type = 3;
                else if (type == 3)
                    type = 1;

                if (type == 1)
                {
                    GameObject _turret = (GameObject)Instantiate(bullet.prefab, GetBuildPosition(), Quaternion.identity);
                    turretGhost = _turret;
                }
                if (type == 2)
                {
                    GameObject _turret = (GameObject)Instantiate(rocket.prefab, GetBuildPosition(), Quaternion.identity);
                    turretGhost = _turret;
                }
                if (type == 3)
                {
                    GameObject _turret = (GameObject)Instantiate(laser.prefab, GetBuildPosition(), Quaternion.identity);
                    turretGhost = _turret;
                    turretGhost.GetComponent<LineRenderer>().enabled = false;
                }
                turretGhost.GetComponent<Turret>().enabled = false;
                

            }
            if (Input.GetKeyDown("f"))
            {
                if (turretNumber > 0)
                {
                    Destroy(turretGhost);
                    builded = true;
                    BuildTurret();
                }
            }

        }

    }
    

    private void OnMouseEnter()
    {


        if (!builded && turretNumber > 0)
        {
            selected = true;
            rend.material.color = hoverColor;
            Destroy(turretGhost);

            if (type == 1)
            {
                GameObject _turret = (GameObject)Instantiate(bullet.prefab, GetBuildPosition(), Quaternion.identity);
                turretGhost = _turret;
            }
            if (type == 2)
            {
                GameObject _turret = (GameObject)Instantiate(rocket.prefab, GetBuildPosition(), Quaternion.identity);
                turretGhost = _turret;
            }
            if (type == 3)
            {
                GameObject _turret = (GameObject)Instantiate(laser.prefab, GetBuildPosition(), Quaternion.identity);
                turretGhost = _turret;
                turretGhost.GetComponent<LineRenderer>().enabled = false;
            }
            turretGhost.GetComponent<Turret>().enabled = false;
        }

    }

    void OnMouseExit()
    {
        selected = false;
        Destroy(turretGhost);
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void BuildTurret()
    {
        if (type == 1)
        {
            GameObject _turret = (GameObject)Instantiate(bullet.prefab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;
        }
        if (type == 2)
        {
            GameObject _turret = (GameObject)Instantiate(rocket.prefab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;
        }
        if (type == 3)
        {
            GameObject _turret = (GameObject)Instantiate(laser.prefab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;
        }
        Debug.Log("Turret build!");
        turretNumber --;
        triggerController.GetComponent<TriggerDestroy>().SetNumber(turretNumber);
    }


    public void DestroyTurret()
    {
        if (builded)
        {
            Destroy(turret);
            GameObject effect = (GameObject)Instantiate(destroyEffect, transform.position, transform.rotation);
            Destroy(effect, 5f);
            builded = false;
            triggerController.GetComponent<TriggerDestroy>().SetNumber(5);
        }
    }
    
}


