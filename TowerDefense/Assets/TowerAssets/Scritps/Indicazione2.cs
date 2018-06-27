using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicazione2 : MonoBehaviour
{

    [SerializeField] public Text runMessage;

    private IEnumerator OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Human"))
        {
            runMessage.text = "PORTA IL CARICO AL CENTRO";
            yield return new WaitForSeconds(3);
            runMessage.text = "";
        }
    }
}
