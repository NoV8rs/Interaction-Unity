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
    
    public void Activate()
    {
        if (type == InteractionType.Door)
        {
            Debug.Log("Door Opened");
        }
        else if (type == InteractionType.Button)
        {
            Debug.Log("Button Activated");
        }
        else if (type == InteractionType.Pickup)
        {
            Debug.Log("Item Picked Up");
        }
    }
}
