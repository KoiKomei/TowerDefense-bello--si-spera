using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fountain : MonoBehaviour {

	public float x = 10;
	public float z = 10;

	private bool triggered = false;

	[SerializeField] private GameObject[] list;
	[SerializeField] private int[] Amount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Activate()
	{
		
		for(int i = 0; i < list.Length; i++)
		{
			for(int j = 0; j < Amount[i]; j++)
			{
				float posX = Random.Range(-x, x);
				float posZ = Random.Range(-z, z);

				Vector3 t = new Vector3(posX + this.transform.position.x, 1, posZ + this.transform.position.z);
				GameObject c = Instantiate(list[i]);
				c.transform.position = t;
			}
		}
		triggered = true;
	}


	public bool getTriggered()
	{
		return triggered;
	}

}
