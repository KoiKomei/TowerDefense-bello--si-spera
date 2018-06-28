using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

	[SerializeField] private PortalSpawner[] portals;

	private List<GameObject> list;


	public GameObject Fontain;

	// Use this for initialization
	void Start () {
		list = new List<GameObject>();
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
			if (p.GetWave() > 3)
			{
				if (!Fontain.GetComponent<fountain>().getTriggered())
				{
					Fontain.GetComponent<fountain>().Activate();
				}
			}
		}
	}

	public List<GameObject> getList()
	{
		return list;
	}
}
