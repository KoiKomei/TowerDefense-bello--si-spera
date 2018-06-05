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

    public void Startup() {
        status = ManagerStatus.Started;
        notChanged = sw.getSelectedWeapon();
        firstWeaponAssigned = false;
        weaponChanged = false;
        inventory = Managers.Inventory;
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
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
        }
        else if (notChanged != sw.getSelectedWeapon()) {
            string nextWeaponName = inventory.GetWeaponsList()[sw.getSelectedWeapon()];
            for (int i = 0; i < armory.Count; i++){
                if (armory[i].nome == nextWeaponName) {
                    currentWeapon = armory[i];
                    Debug.Log("Current Weapon: " + currentWeapon.toString());
                }
            }
            notChanged = sw.getSelectedWeapon();
        }
        if (weaponChanged){
            string weaponName = inventory.GetWeaponsList()[0];
            for (int i = 0; i < armory.Count; i++){
                if (armory[i].nome == weaponName) {
                    currentWeapon = armory[i];
                    Debug.Log("Current Weapon: " + currentWeapon.toString());
                    weaponChanged = false;
                }
            }
	    }
    }

    public Weapon getCurrentWeapon() {
        return currentWeapon;
    }
}
