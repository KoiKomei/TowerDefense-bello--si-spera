using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes;
    public float sensivityhor = 9.0f;
    public float sensivityver = 9.0f;

    public float miny = -45.0f;
    public float maxy = 45.0f;

    private float _rotationX = 0;

    // Use this for initialization
    private void Start()
    {
        CharacterController ech = GetComponent<CharacterController>();
 
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensivityhor, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensivityver;
            _rotationX = Mathf.Clamp(_rotationX, miny, maxy);
            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensivityver;
            _rotationX = Mathf.Clamp(_rotationX, miny, maxy);

            float delta = Input.GetAxis("Mouse X") * sensivityhor;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }

    }
}

