using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunnerSeat : MonoBehaviour, IInteractable
{
    [SerializeField] string interactionText;
    [SerializeField] string interactionKeyCode;
    [SerializeField] GameObject sitPosition;
    [SerializeField] GameObject turretCamera;

    private bool interactable;
    private bool isSitting;

    private void Update()
    {
       if(interactable && Input.GetButtonDown(interactionKeyCode))
        {
            onInteract();
        }

       if (isSitting && Input.GetButtonDown("Cancel"))
        {
            toggleSitting(false);
        }
    }

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
            turretCamera.SetActive(false);
            gamemanager.instance.playerScript.camera.gameObject.SetActive(true);
            isSitting = false;
        }
    }
    public void onInteract()
    {
        toggleSitting(true);
        gamemanager.instance.playerScript.camera.gameObject.SetActive(false);
        turretCamera.SetActive(true);
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
