using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class InteractionManager : MonoBehaviour
{
    public CameraManager cameraManager;
    public Camera playerCam;
    public UIManager uIManager;
    public int maxRayDistance;

    [SerializeField]
    private GameObject target;
    private Interactable targetInteractable;
    public bool interactionPossible;
    
    void Awake()
    {
        uIManager = FindObjectOfType<UIManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        playerCam = cameraManager.playerCamera;
       
    }
    
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            interactionPossible = true;
        }
        else
        {
            interactionPossible = false;
        }
    }

    void FixedUpdate()
    {
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit, maxRayDistance))
        {
            if (hit.transform.gameObject.CompareTag("Interaction"))
            {
                Debug.Log("Looking at " + hit.transform.gameObject.name);
                target = hit.transform.gameObject;
                targetInteractable = target.GetComponent<Interactable>();
            }
            else
            {
                target = null;
                targetInteractable = null;
            }
            SetGameplayMessage();
        }
    }
    
    public void Interact()
    {
        if (targetInteractable == null) return;
        
        string itemName = targetInteractable.pickupObject.itemName;
        
        switch (targetInteractable.type)
        {
            case Interactable.InteractionType.Door:
                target.SetActive(false);
                Debug.Log("Door Opened!");
                break;
            case Interactable.InteractionType.Button:
                target.SetActive(false);
                Debug.Log("Button Pressed!");
                break;
            case Interactable.InteractionType.Pickup:
                target.SetActive(false);
                Debug.Log("Picked up: " + itemName);
                break;
        }
    }
    
    void SetGameplayMessage()
    {
        string message = "";
        if (targetInteractable == null)
        {
            uIManager.UpdateGameplayMessage(message);
            return;
        }
        switch (targetInteractable.type)
        {
            case Interactable.InteractionType.Door:
            message = "Press LMB to open door";
            break;
            case Interactable.InteractionType.Button:
            message = "Press LMB to press button";
            break;
            case Interactable.InteractionType.Pickup:
            message = "Press LMB to pickup item";
            break;
        }
        uIManager.UpdateGameplayMessage(message);
    }
}