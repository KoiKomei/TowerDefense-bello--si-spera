using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCamera : MonoBehaviour {

    [SerializeField] private Transform target;

    public float rotSpeed = 1.5f;
    private float rotY;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        rotY = transform.eulerAngles.y;
        offset = target.position - transform.position;
	}
	
	
	void LateUpdate () {
        float horInput = Input.GetAxis("Horizontal");

        rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;

        Quaternion rotation = Quaternion.Euler(0, rotY, 0);
        if(Input.GetAxis("Mouse X") != 0 && horInput==0)
        {
            target.rotation = Quaternion.Lerp(target.rotation,rotation,17*Time.deltaTime);
        }
            
        transform.position = target.position - (rotation * offset);

        

        transform.LookAt(target);

	}
}
