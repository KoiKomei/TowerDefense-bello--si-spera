using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem {

	string name { get; }
    Sprite image { get; }

    //1 = weapon, 2 = ammo, 3 = consumable
    int category {  get; }
    
}
