using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalExplosion : MonoBehaviour {

	[SerializeField] UIController UI;
    [SerializeField] private AudioClip boooom;
    private AudioSource _sound;
	public float movementUp = 20f;
    private bool adios=false;
    private bool aurevoir = false;

    public GameObject spaceShip;

    private bool collision = false;
    private bool musicon = false;
    public GameObject explosion;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
    }


    public void Update () {
        
        if (this.GetComponent<Payload>().GetArrived())
        {
            if (!musicon)
            {
                musicon = true;
                Managers.Audio.PlayWinMusic();
            }
            goUp();
        }
    }

    public void goUp()
    {
        if (this.transform.position.y < 225)
        {

            this.transform.Translate(0, movementUp * Time.deltaTime, 0);
        }
        else
        {
            
                StartCoroutine(Explosion());
            
        }

    }

    public IEnumerator Explosion()
    {
        GameObject boom = Instantiate(explosion, this.transform);
        _sound.PlayOneShot(boooom);
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
        Destroy(spaceShip);
		UI.SendMessage("win");

    }

}
