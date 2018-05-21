using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StandardTurretNode : MonoBehaviour {

    public Color hoverColor;
    public Vector3 positionOffset;
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public GameObject turretGhost;
    public Turret Standard;

    private bool builded;
    private Renderer rend;
    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        builded = false;
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
        rend.material.color = hoverColor;
        if (!builded)
        {
            GameObject _turret = (GameObject)Instantiate(Standard.prefab, GetBuildPosition(), Quaternion.identity);
            turretGhost = _turret;
            turretGhost.GetComponent<Turret>().enabled = false;
        }
        
    }

    void OnMouseExit()
    {
        Destroy(turretGhost);
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void BuildTurret()
    {
        GameObject _turret = (GameObject)Instantiate(Standard.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        Debug.Log("Turret build!");
    }

}

