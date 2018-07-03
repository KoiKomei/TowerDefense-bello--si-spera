using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerDestroySon3 : MonoBehaviour
{
    public TriggerDestroy trigger;

    private void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Human")
        {
            trigger.Destroy3();
        }
    }
}
