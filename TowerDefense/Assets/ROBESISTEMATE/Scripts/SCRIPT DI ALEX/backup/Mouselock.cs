using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouselock : MonoBehaviour {

	void Update () {
        Cursor.lockState = CursorLockMode.Locked;
	}
}
