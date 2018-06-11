using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRenderer : MonoBehaviour {

    GameObject currentArma;
    [SerializeField] GameObject m4;
    [SerializeField] GameObject pump;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (Managers.Weapon.changeWeapon) {
            if (currentArma != null) currentArma.gameObject.SetActive(false);
            Weapon weapon = Managers.Weapon.getCurrentWeapon();
            if (weapon.nome.StartsWith("m4")) {
                m4.gameObject.SetActive(true);
                currentArma = m4;
            }
            if (weapon.nome.StartsWith("pump")) {
                pump.gameObject.SetActive(true);
                currentArma = pump;
            }
        }
	}
}
