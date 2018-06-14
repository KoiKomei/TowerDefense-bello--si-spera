using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerRun : MonoBehaviour
{

    [SerializeField] public Text runMessage;

    private IEnumerator OnTriggerEnter()
    {
        runMessage.text = "           WHERE ARE YOU GOING?   -----------YOU CAN NOT RUN AWAY !!!-----------     --------FROM YOUR RESPONSIBILITIES--------";
        yield return new WaitForSeconds(3);
        runMessage.text = "";
    }


}
