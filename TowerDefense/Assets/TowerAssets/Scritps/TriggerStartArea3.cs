using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerStartArea3 : MonoBehaviour {

    [SerializeField] public Text runMessage;
    public GameObject Portal1;
    public GameObject Portal2;
    public Collider collider;

    private float movementUp = 0.1f;
    private bool levelStart = false;
    private int cont = 0;

    private IEnumerator OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Human"))
        {
            collider.GetComponent<BoxCollider>().enabled = true;
            if (cont == 0)
            {
                runMessage.text = "RESISTI ALLE ONDATE";
                yield return new WaitForSeconds(3);
                runMessage.text = "";
                levelStart = true;
                cont++;
            }
        }
    }

    public void Update()
    {
        if (Portal1 != null)
        {
            if (levelStart && Portal1.transform.position.y < 4.5)
            {
                Portal1.transform.Translate(0, movementUp, 0);
            }
            if (levelStart && Portal2.transform.position.y < 4.5)
            {
                Portal2.transform.Translate(0, movementUp, 0);
            }
            if (Portal1.transform.position.y >= 4.5)
            {
                levelStart = false;
            }
        }
    }

}
