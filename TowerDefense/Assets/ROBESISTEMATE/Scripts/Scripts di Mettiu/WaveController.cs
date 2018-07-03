using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

	[SerializeField] private PortalSpawner[] portals;

	private ArrayList list;
    
	// Use this for initialization
	private void Awake()
	{
		list = new ArrayList();
	}
	void Start () {
		
	}

	// Update is called once per frame
	void Update() {
		bool empty = true;
		foreach(PortalSpawner p in portals)
		{
			foreach(GameObject g in list)
			{
				if (g != null)
				{
					empty = false;
					break;
				}

			}
			if (p.getOnGoing() && empty)
			{
				p.SetWave(p.GetWave() + 1);
				p.SetOnGoingFalse();
				//Debug.Log(p.GetWave());
			}
		}
	}

	public ArrayList getList()
	{
		return list;
	}
}
