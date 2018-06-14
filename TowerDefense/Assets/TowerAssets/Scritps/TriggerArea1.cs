using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerArea1 : MonoBehaviour {

    // Use this for initialization
    [SerializeField] public Text runMessage;
    public GameObject Collider;
    public GameObject Wall;

    public int enemyKill = 0;

    private float movement = -0.1f;
    private bool levelComplete = false;


    private IEnumerator OnTriggerEnter()
    {
        
        if (enemyKill<50) {
            runMessage.text = "          YOU HAVE TO CLEAN THE AREA";
            yield return new WaitForSeconds(3);
            runMessage.text = "";

        }
        if(enemyKill >= 50)
        {
            levelComplete = true;
            Collider.GetComponent<BoxCollider>().enabled = false;
        }

       

    }

    public void EnemyKilled()
    {
        enemyKill++;
    }


    public void Update()
    {
        if (levelComplete && Wall.transform.position.y>-10) {
            Wall.transform.Translate(0, movement, 0);
        }
    }

}
