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

    private bool builded;
    private bool selected;

    private Renderer rend;
    private Color startColor;

    private int type;


    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        builded = false;
        type = 1;
        selected = false;

    }



    void Update()
    {
        if (!builded)
        {
            if (Input.GetKeyDown("q") && selected)
            {
                Destroy(turretGhost);
                if (type == 1)
                    type = 2;
                else if (type == 2)
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
                turretGhost.GetComponent<Turret>().enabled = false;
                

            }

        }
    }


    void OnMouseDown()
    {
        if (!builded)
        {
            Destroy(turretGhost);
            builded = true;
            BuildTurret();
        }
    }

    private void OnMouseEnter()
    {
        selected = true;
        rend.material.color = hoverColor;
        if (!builded)
        {
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
        Debug.Log("Turret build!");
    }

}


