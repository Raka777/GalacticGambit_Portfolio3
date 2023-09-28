using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pilotSeat : MonoBehaviour, IInteractable
{
    [SerializeField] string interactionText;
    [SerializeField] string interactionKeyCode;

    private bool interactable;
    void Update()
    {
        
    }
    //The function used to display information when an object becomes interactable.
    public void onInteractable()
    {
        gamemanager.instance.updateInteractionMenu(interactionText);
        interactable = true;
    }
    //The function used to trigger the interaction when an object is interacted with.
    public void onInteract()
    {

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
