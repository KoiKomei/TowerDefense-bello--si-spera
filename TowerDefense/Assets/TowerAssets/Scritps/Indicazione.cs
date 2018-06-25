using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicazione : MonoBehaviour {

    [SerializeField] public Text runMessage;

    private IEnumerator OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Human"))
        {
            runMessage.text = "VAI A SINISTRA PER PRENDERE IL CARICO";
            yield return new WaitForSeconds(3);
            runMessage.text = "";
        }
    }
}