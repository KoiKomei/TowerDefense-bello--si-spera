using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDropper : MonoBehaviour {

    [SerializeField] Transform target;
    [SerializeField] List<GameObject> weaponsPrefabs;
    [SerializeField] List<string> keys;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void drop(string name) {
        Debug.Log("dropping " + name);
        for (int i = 0; i < keys.Count; i++) {
            if (keys[i] == name) {
                GameObject item = Instantiate(weaponsPrefabs[i]) as GameObject;
                item.transform.position = target.position + target.forward;
                item.transform.position = new Vector3(item.transform.position.x, 0.5f, item.transform.position.z);
                break;
            }
        }
    }

}
