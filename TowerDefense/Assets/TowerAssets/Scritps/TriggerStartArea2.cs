using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerStartArea2 : MonoBehaviour {

    [SerializeField] public Text runMessage;
    public GameObject Portal1;
    public GameObject ParticlePortal1;
    public Collider collider;
	public GameObject payloadLife;


	private float movementUp = 5f;
    private bool levelStart = false;
    private int cont = 0;
    public GameObject payload;

    private IEnumerator OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Human"))
        {
            if (cont == 0)
            {
                collider.GetComponent<BoxCollider>().enabled = true;
                payload.GetComponent<Payload>().enabled = false;
                runMessage.text = "RESISTI ALLE ONDATE PER MUOVERE IL CARICO";
				payloadLife.SetActive(true);
				yield return new WaitForSeconds(3);
                runMessage.text = "";
                levelStart = true;
                cont++;
            }
        }
    }

    public void Update()
    {
        goUp();
    }


    public void goUp()
    {

        if (Portal1 != null)
        {
            if (levelStart && Portal1.transform.position.y < 4.5)
            {
                ParticlePortal1.transform.Translate(0, movementUp * Time.deltaTime, 0);
                Portal1.transform.Translate(0, movementUp * Time.deltaTime, 0);
            }
            if (Portal1.transform.position.y >= 4.5)
            {
                levelStart = false;
            }
        }

    }


}
