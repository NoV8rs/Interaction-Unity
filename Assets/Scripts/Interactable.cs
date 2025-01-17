using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public enum InteractionType
    {
        Door,
        Button,
        Pickup
    }

    public InteractionType type;
    
    public PickupObjects pickupObject;
    
    public void Activate()
    {
        Debug.Log("Interactable Activated" + this.name);
    }
}
