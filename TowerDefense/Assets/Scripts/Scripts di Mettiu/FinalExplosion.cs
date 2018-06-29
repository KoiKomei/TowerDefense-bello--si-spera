using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalExplosion : MonoBehaviour {


    private float movementUp = 0.2f;

    public GameObject spaceShip;

    private bool collision = false;



    public void Update () {
        
        if (this.GetComponent<Payload>().GetArrived())
        {
            goUp();
        }
    }

    public void goUp()
    {
        if (this.transform.position.y < 225)
        {
            this.transform.Translate(0, movementUp, 0);
        }
        else
        {
            StartCoroutine(Explosion());
        }

    }

    public IEnumerator Explosion()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
        Destroy(spaceShip);
    }

}
