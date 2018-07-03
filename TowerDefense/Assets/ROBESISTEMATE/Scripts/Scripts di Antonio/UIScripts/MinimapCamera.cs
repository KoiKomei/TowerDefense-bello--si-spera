using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour {

    [SerializeField] private Transform target;
    [SerializeField] private int altezza;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = new Vector3(target.position.x, altezza, target.position.z);
    }
}
