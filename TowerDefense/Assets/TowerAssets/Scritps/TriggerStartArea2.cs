using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerStartArea2 : MonoBehaviour {

    [SerializeField] public Text runMessage;
    public GameObject Portal1;
    public GameObject ParticlePortal1;

    private float movementUp = 0.1f;
    private bool levelStart = false;
    private int cont = 0;
    public GameObject payload;

    private IEnumerator OnTriggerEnter()
    {
        runMessage.text = "YOU HAVE TO RESIST THE WAVES TO MOVE THE TRUCK";
        yield return new WaitForSeconds(3);
        runMessage.text = "";
        payload.GetComponent<Payload>().enabled = false;
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
            Portal1.transform.Translate(0, movementUp, 0);
            ParticlePortal1.transform.Translate(0, movementUp, 0);
        }
        if (Portal1.transform.position.y >= 4.5)
        {
            levelStart = false;
        }
    }

}
