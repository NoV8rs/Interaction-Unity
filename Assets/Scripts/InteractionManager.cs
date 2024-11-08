using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class InteractionManager : MonoBehaviour
{
    public CameraManager cameraManager;
    public Camera playerCam;
    public int maxRayDistance;
    public UIManager uiManager;
    [SerializeField]
    private GameObject target;
    private Interactable targetInteractable;
    public bool isInteracting;
    void Awake()
    {
        playerCam = cameraManager.playerCamera;
        cameraManager = FindObjectOfType<CameraManager>();
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        if (target != null)
        {
            isInteracting = true;
        }
        else
        {
            isInteracting = false;
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
        }
        else
        {
            target = null;
            targetInteractable = null;
        }
        SetGameplayMessage();
    }
    
    public void Interact()
    {
        if (targetInteractable == null) return;
        switch(targetInteractable.type)
        {
            case Interactable.InteractionType.Door:
                target.SetActive(false);
                break;
            case Interactable.InteractionType.Button:
                targetInteractable.Activate();
                break;
            case Interactable.InteractionType.Pickup:
                targetInteractable.Activate();
                target.SetActive(false);
                break;
        }
    }

    void SetGameplayMessage()
    {
        string message = "";
        if (targetInteractable != null)
        {
            switch (targetInteractable.type)
            {
                case Interactable.InteractionType.Door:
                    message = "Press LMB to open door";
                    break;
                case Interactable.InteractionType.Button:
                    message = "Press LMB to activate button";
                    break;
                case Interactable.InteractionType.Pickup:
                    message = "Press LMB to pick up item";
                    break;
            }
        }
        uiManager.UpdateGameplayMessage(message);
    }
}


