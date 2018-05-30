using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow3rdCam : MonoBehaviour {

    public float mousespeed = 3;
    public Camera cam;
    public Transform player;

    private void Update()
    {
        float X = Input.GetAxis("Mouse X") * mousespeed;
        float Y = Input.GetAxis("Mouse Y") * mousespeed;

        player.Rotate(0, X, 0);

        if (cam.transform.eulerAngles.x + (-Y) > 80 && cam.transform.eulerAngles.x+(-Y) < 280) { }
        else
        {

            cam.transform.RotateAround(player.position, cam.transform.right, -Y);
        }

        transform.LookAt(player);
    }
}
