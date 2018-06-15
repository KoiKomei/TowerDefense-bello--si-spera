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
    
    private float movementUp = 0.1f;
    private bool levelStart = false;

    private IEnumerator OnTriggerEnter()
    {
        runMessage.text = "          YOU HAVE TO CLEAN THE AREA";
        yield return new WaitForSeconds(3);
        runMessage.text = "";
        levelStart = true;
    }

    public void Update()
    {
        if (levelStart && Portal1.transform.position.y < 4.5)
        {
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
        }


    }

}
