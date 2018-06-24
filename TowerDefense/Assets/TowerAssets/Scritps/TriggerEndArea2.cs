using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerEndArea2 : MonoBehaviour {

    [SerializeField] public Text runMessage;
    public GameObject Collider;
    public GameObject Portal1;
    public GameObject ParticlePortal1;
    private float movementDown = -0.1f;
    public GameObject payload;

    private IEnumerator OnTriggerEnter(Collider c)
    {
        if (c.tag == "Human")
        {
            if (Portal1.GetComponent<PortalSpawner>().GetWave() < 3)
            {
                runMessage.text = "YOU HAVE TO RESIST THE WAVES";
                yield return new WaitForSeconds(3);
                runMessage.text = "";

            }
            if (Portal1.GetComponent<PortalSpawner>().GetWave() == 3)
            {
                yield return new WaitForSeconds(15);
                Collider.GetComponent<BoxCollider>().enabled = false;
                payload.GetComponent<Payload>().enabled = true;
                runMessage.text = "BRING THE TRUCK TO THE PARK";
                yield return new WaitForSeconds(3);
                runMessage.text = "";
                GoDown();
            }
        }
    }

    private void GoDown()
    {
        while (Portal1.transform.position.y > -10)
        {
            Portal1.transform.Translate(0, movementDown, 0);
            ParticlePortal1.transform.Translate(0, movementDown, 0);
        }
    }

}
