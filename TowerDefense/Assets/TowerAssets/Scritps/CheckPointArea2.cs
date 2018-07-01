using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPointArea2 : MonoBehaviour {

    [SerializeField] public Text runMessage;
    public GameObject fountain;
    public GameObject payload;

    public float range = 5;
    private int cont = 0;
    private bool save = false;

    private IEnumerator OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Human"))
        {
            if (cont == 0 && save)
            {
                runMessage.text = "CHECKPOINT RAGGIUNTO";
                yield return new WaitForSeconds(3);
                runMessage.text = "";

                //salva posizione player (c.transform.position.x, c.transform.position.y, c.transform.position.z) e payload (payload.transform.position.x, payload.transform.position.y, payload.transform.position.z)
                PlayerPrefs.SetFloat("PlayerPosX", c.transform.position.x);
                PlayerPrefs.SetFloat("PlayerPosY", c.transform.position.y);
                PlayerPrefs.SetFloat("PlayerPosZ", c.transform.position.z);
                PlayerPrefs.SetFloat("PayloadPosX", payload.transform.position.x);
                PlayerPrefs.SetFloat("PayloadPosY", payload.transform.position.y);
                PlayerPrefs.SetFloat("PayloadPosZ", payload.transform.position.z);

                fountain.GetComponent<fountain>().Activate();
                cont++;
            }
        }


    }

    public void Update()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, range);

        foreach (Collider c in colliders)
        {
            GameObject target = c.gameObject;
            if (c.GetComponentInParent<Payload>() != null)
            {
                save = true;
            }
        }

    }
}