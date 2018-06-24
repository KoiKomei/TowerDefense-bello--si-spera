using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour,IEnemy {

    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
	private bool rand = false;
	public float ArrivalTime = 5f;


    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    private bool _alive;

	// Use this for initialization
	void Start () {

        _alive = true;
		StartCoroutine(WaitForRand(ArrivalTime));
	}

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }


    // Update is called once per frame
    void Update() {

        if (_alive) {
            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;

                if (hitObject.GetComponent<TPSMovement2>())
                {
                    if (_fireball == null)
                    {
                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }

                else if (hit.distance < obstacleRange && rand)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }

        }
    }

	public void Hurt(int damage)
	{
		if(_alive)
			Die();
	}

	public void Die()
	{
		_alive = false;
		transform.Rotate(-75, 0, 0);
		Destroy(this.gameObject, 1.5f);
	}

	public void Attack(GameObject target)
	{
		
	}

	IEnumerator WaitForRand(float time)
	{
		yield return new WaitForSeconds(time);
		rand = true;
	}
}
