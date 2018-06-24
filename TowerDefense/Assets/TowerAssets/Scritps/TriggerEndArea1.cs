using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerEndArea1 : MonoBehaviour {

    // Use this for initialization
    [SerializeField] public Text runMessage;
    public GameObject Collider;
    public GameObject Portal1;
    public GameObject Portal2;
    public GameObject Portal3;
    public GameObject Portal4;
    public GameObject ParticlePortal1;
    public GameObject ParticlePortal4;
    public GameObject payload;

    private float movementDown = -0.1f;
    private bool levelComplete = false;

    private IEnumerator OnTriggerEnter()
    {

        if (Portal1.GetComponent<PortalSpawner>().GetWave() < 3)
        {
            runMessage.text = "          YOU HAVE TO RESIST THE WAVES";
            yield return new WaitForSeconds(3);
            runMessage.text = "";

        }
        if (Portal1.GetComponent<PortalSpawner>().GetWave() == 3)
        {
            yield return new WaitForSeconds(25);
            levelComplete = true;
            Collider.GetComponent<BoxCollider>().enabled = false;
            payload.GetComponent<Payload>().enabled = true;
            runMessage.text = "         BRING THE TRUCK TO THE EXPLOSION ZONE";
            yield return new WaitForSeconds(3);
            runMessage.text = "";
            GoDown();
        }

    }

    private void GoDown()
    {
        while (Portal1.transform.position.y > -10)
        {
            Portal1.transform.Translate(0, movementDown, 0);
            ParticlePortal1.transform.Translate(0, movementDown, 0);
            Portal2.transform.Translate(0, movementDown, 0);
            Portal3.transform.Translate(0, movementDown, 0);
            Portal4.transform.Translate(0, movementDown, 0);
            ParticlePortal4.transform.Translate(0, movementDown, 0);
        }
    }


}
