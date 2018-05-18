using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCam : MonoBehaviour {

    [SerializeField] private Transform target;
    public float rotSpeed = 1.5f;
    private float _roty;
    private Vector3 _offset;

	// Use this for initialization
	void Start () {
        _roty = transform.eulerAngles.y;
        _offset = target.position - transform.position;
	}

    private void LateUpdate()
    {
        float horInput = Input.GetAxis("Horizontal");
        if (horInput != 0)
        {
            _roty += horInput * rotSpeed;
        }
        else {
            _roty += Input.GetAxis("Mouse X") * rotSpeed *3;
        }
        Quaternion rotation = Quaternion.Euler(0, _roty, 0);
        transform.position = target.position - (rotation * _offset);
        transform.LookAt(target);
    }


    // Update is called once per frame
    void Update () {
		
	}
}
