using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPointArea3 : MonoBehaviour
{

    [SerializeField] public Text runMessage;
    public GameObject fountain;

    private int cont = 0;

    private IEnumerator OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Human"))
        {
            if (cont == 0)
            {
                runMessage.text = "CHECKPOINT RAGGIUNTO";
                yield return new WaitForSeconds(3);
                runMessage.text = "";

                //salva posizione player (c.transform.position.x,c.transform.position.y,c.transform.position.z)
                PlayerPrefs.SetFloat("PlayerPosX", c.transform.position.x);
                PlayerPrefs.SetFloat("PlayerPosY", c.transform.position.y);
                PlayerPrefs.SetFloat("PlayerPosZ", c.transform.position.z);
               

                fountain.GetComponent<fountain>().Activate();
                cont++;
            }
        }


    }
}