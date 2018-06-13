using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(InventoryManager))]
[RequireComponent(typeof(WeaponManager))]
[RequireComponent(typeof(AudioManager))]

public class Managers : MonoBehaviour {

    public static AudioManager Audio { get; private set; } 
    public static PlayerManager Player { get; private set; }
    public static InventoryManager Inventory { get; private set; }
    public static WeaponManager Weapon { get; private set; }
    private List<IGameManager> startSequence;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake() {

        Player = GetComponent<PlayerManager>();
        Inventory = GetComponent<InventoryManager>();
        Weapon = GetComponent <WeaponManager>();
        Audio = GetComponent<AudioManager>();

        startSequence = new List<IGameManager>();

        startSequence.Add(Player);
        startSequence.Add(Inventory);
        startSequence.Add(Weapon);
        startSequence.Add(Audio);

        StartCoroutine(StartupManagers());

    }

    private IEnumerator StartupManagers() { 
        foreach (IGameManager manager in startSequence) {
            manager.Startup();
        }

        yield return null;

        int numModules = startSequence.Count;
        int numReady = 0;

        while (numReady < numModules) {
            int lastReady = numReady;
            numReady = 0;
            foreach (IGameManager manager in startSequence) {
                if (manager.status == ManagerStatus.Started) {
                    numReady++;
                }
            }
            if (numReady > lastReady) {
                Debug.Log("Progress: " + numReady + "/" + numModules);
            }
            yield return null;
        }
        Debug.Log("All managers started up!");
    }
}
