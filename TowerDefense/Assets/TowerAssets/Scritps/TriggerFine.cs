using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerFine : MonoBehaviour
{
    [SerializeField] public Text runMessage;

    public GameObject payload;
    public GameObject explosionEffect;

    private void Start()
    {
        explosionEffect.transform.position = payload.transform.position;
    }

    private IEnumerator OnTriggerEnter(Collider c)
    {
        if (c.tag=="Human") { 
            runMessage.text = "          CONGRATULATIONS YOU HAVE SAVED THE EARTH";
            yield return new WaitForSeconds(3);
            runMessage.text = "          NOW RUN BEFORE THE TRUCK EXPLOSION";
            yield return new WaitForSeconds(3);
        
            for(int i=60; i>0; i--){
                runMessage.text = "          YOU HAVE "+i+" SECONDS TO GO BACK";
                yield return new WaitForSeconds(1);
            }
            Destroy();
        }
    }

    private void Destroy()
    {
        Destroy(payload);
        GameObject effect = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(effect, 5f);
    }

}