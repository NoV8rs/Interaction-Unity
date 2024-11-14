using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PickupObjects", menuName = "Interactables/PickupObjects", order = 1)]
public class PickupObjects : ScriptableObject
{
    public string itemName;
    
    public void Pickup()
    {
        Debug.Log("Item Picked Up: " + itemName);
    }
}
