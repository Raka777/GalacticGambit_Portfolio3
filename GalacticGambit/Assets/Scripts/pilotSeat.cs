using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pilotSeat : MonoBehaviour, IInteractable
{
    [SerializeField] string interactionText;
    [SerializeField] string interactionKeyCode;
    [SerializeField] GameObject sitPosition;

    private bool interactable;
    private bool isSitting;
    void Update()
    {
        if (interactable && Input.GetButtonDown(interactionKeyCode))
        {
            onInteract();
        }

        if(isSitting && Input.GetButtonDown("Cancel"))
        {
            toggleSitting(false);
        }
    }
    //The function used to display information when an object becomes interactable.
    public void onInteractable(bool state)
    {
        if (state)
        {
            //Debug.Log("Interactable");
            gamemanager.instance.updateInteractionMenu(interactionText);
            interactable = true;
            gamemanager.instance.toggleInteractionMenu(interactable);
            
        }
        else
        {
            Debug.Log("Interaction Off");
            gamemanager.instance.updateInteractionMenu("");
            interactable = false;
            gamemanager.instance.toggleInteractionMenu(interactable);
        }
        
    }
    void toggleSitting(bool state)
    {
        if (state)
        {
            gamemanager.instance.playerScript.setPosition(sitPosition.transform);
            gamemanager.instance.togglePlayerMovement(false);
            isSitting = true;
        }
        else
        {
            gamemanager.instance.togglePlayerMovement(true);
            isSitting = false;
        }
    }

    //The function used to trigger the interaction when an object is interacted with.
    public void onInteract()
    {
        toggleSitting(true);
    }

    public bool isInteractable()
    {
        return interactable;
    }

    public string interactionKey()
    {
        return interactionKeyCode;
    }
}
