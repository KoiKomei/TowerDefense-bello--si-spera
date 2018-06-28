using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
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
    public Collider collider;
	public float range = 5;

    private float movementUp = 0.1f;
    private int cont = 0;
    private bool levelStart = false;

    private IEnumerator OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Human"))
        {
            if (cont == 0)
            {
                collider.GetComponent<BoxCollider>().enabled = true;
                runMessage.text = "PROTEGGI IL CARICO DAI NEMICI";
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

		Collider[] colliders = Physics.OverlapSphere(transform.position, range);

		foreach (Collider c in colliders)
		{
			GameObject target = c.gameObject;
			if (c.GetComponentInParent<Payload>() != null)
			{
				c.GetComponentInParent<Payload>().enabled = false;
				c.GetComponentInParent<NavMeshAgent>().isStopped = true;
				break;
			}
		}

	}

}
