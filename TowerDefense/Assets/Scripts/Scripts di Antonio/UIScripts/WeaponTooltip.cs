using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTooltip : MonoBehaviour, IDisplayableUIObject
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Open()
    {
        this.gameObject.SetActive(true);
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }
}
