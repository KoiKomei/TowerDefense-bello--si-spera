using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalExplosion : MonoBehaviour {

	[SerializeField] UIController UI;
	public float movementUp = 20f;

    public GameObject spaceShip;

    private bool collision = false;



    public void Update () {
        
        if (this.GetComponent<Payload>().GetArrived())
        {
			Managers.Audio.PlayWinMusic();
            goUp();
        }
    }

    public void goUp()
    {
        if (this.transform.position.y < 225)
        {

            this.transform.Translate(0, movementUp*Time.deltaTime, 0);
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
		UI.SendMessage("win");

    }

}
