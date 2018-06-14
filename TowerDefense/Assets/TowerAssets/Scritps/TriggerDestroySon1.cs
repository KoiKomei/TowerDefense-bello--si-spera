using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerDestroySon1 : MonoBehaviour
{
    public TriggerDestroy trigger;
    
    private void OnTriggerEnter()
    {
        trigger.Destroy1();
    }
}
