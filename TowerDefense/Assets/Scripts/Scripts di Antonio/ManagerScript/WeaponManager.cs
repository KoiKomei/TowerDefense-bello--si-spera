using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour, IGameManager {

    public ManagerStatus status { get; private set; }

    [SerializeField] public SelectedWeapon sw;
    [SerializeField] private List<Weapon> armory;
    InventoryManager inventory;
    private Weapon currentWeapon;
    private int notChanged;
    private bool firstWeaponAssigned;
    public bool weaponChanged;
    public bool changeWeapon;

    public void Startup() {
        status = ManagerStatus.Started;
        notChanged = sw.getSelectedWeapon();
        firstWeaponAssigned = false;
        weaponChanged = false;
        changeWeapon = false;
        inventory = Managers.Inventory;
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //ASSEGNAMENTO PRIMA ARMA RACCOLTA
        if (sw.hasFirstGun && !firstWeaponAssigned) {
            string weaponName = inventory.GetWeaponsList()[0];
            for (int i = 0; i < armory.Count; i++){
                if (armory[i].nome == weaponName) {
                    currentWeapon = armory[i];
                    Debug.Log("Current Weapon: " + currentWeapon.toString());
                }
            }
            notChanged = sw.getSelectedWeapon();
            firstWeaponAssigned = true;
            changeWeapon = true;
        }
        //ASSEGNAMENTO CAMBIO ARMA
        else if (notChanged != sw.getSelectedWeapon()) {
            string nextWeaponName = inventory.GetWeaponsList()[sw.getSelectedWeapon()];
            for (int i = 0; i < armory.Count; i++){
                if (armory[i].nome == nextWeaponName) {
                    currentWeapon = armory[i];
                    Debug.Log("Current Weapon: " + currentWeapon.toString());
                }
            }
            notChanged = sw.getSelectedWeapon();
            changeWeapon = true;
        }
        //ASSEGNAMENTO ARMA SOSTITUITA
        if (weaponChanged){
            string weaponName = inventory.GetWeaponsList()[0];
            for (int i = 0; i < armory.Count; i++){
                if (armory[i].nome == weaponName) {
                    currentWeapon = armory[i];
                    Debug.Log("Current Weapon: " + currentWeapon.toString());
                    weaponChanged = false;
                }
            }
            changeWeapon = true;
	    }
    }

    public Weapon getCurrentWeapon() {
        return currentWeapon;
    }
}
