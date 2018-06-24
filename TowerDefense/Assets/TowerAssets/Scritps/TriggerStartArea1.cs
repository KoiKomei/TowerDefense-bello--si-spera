using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerStartArea1 : MonoBehaviour {

    [SerializeField] public Text runMessage;
    public GameObject Portal1;
    public GameObject Portal2;
    public GameObject Portal3;
    public GameObject Portal4;
    public GameObject ParticlePortal1;
    public GameObject ParticlePortal4;
    public GameObject payload;

    private float movementUp = 0.1f;
    private int cont = 0;
    private bool levelStart = false;

    private IEnumerator OnTriggerEnter()
    {
        runMessage.text = "BRING THE TRUCK TO THE CENTER OF THE PARK AND PROTECT IT FROM ENEMIES";
        yield return new WaitForSeconds(3);
        runMessage.text = "";
        if (payload.GetComponent<Payload>().transform.position.x== 395 && payload.GetComponent<Payload>().transform.position.z == -92)
        {
            payload.GetComponent<Payload>().enabled = false;
        }
        if (cont == 0)
        {
            levelStart = true;
            cont++;
        }
    }

    public void Update()
    {
        if (levelStart && Portal1.transform.position.y < 4.5)
        {
            ParticlePortal1.transform.Translate(0, movementUp, 0);
            Portal1.transform.Translate(0, movementUp, 0);
        }
        if (levelStart && Portal2.transform.position.y < 4.5)
        {
            Portal2.transform.Translate(0, movementUp, 0);
        }
        if (levelStart && Portal3.transform.position.y < 4.5)
        {
            Portal3.transform.Translate(0, movementUp, 0);
        }
        if (levelStart && Portal4.transform.position.y < 4.5)
        {
            Portal4.transform.Translate(0, movementUp, 0);
            ParticlePortal4.transform.Translate(0, movementUp, 0);
        }
        if (Portal1.transform.position.y >= 4.5)
        {
            levelStart = false;
        }


    }

}
