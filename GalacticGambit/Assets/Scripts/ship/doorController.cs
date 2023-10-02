using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour, IInteractable
{
    [SerializeField] string interactionText;
    [SerializeField] string interactionKeyCode;
    [SerializeField] Animator animator;
    [SerializeField] int closeTime;
    [SerializeField] int baseRepairTime;

    private bool interactable;
    private bool isOpen;
    private bool isDisabled;
    private int health;
    void Update()
    {
        if (interactable && Input.GetButtonDown(interactionKeyCode) && !isOpen)
        {
            onInteract();
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
    IEnumerator toggleDoor()
    {
        animator.SetBool("character_nearby", true);
        isOpen = true;
        yield return new WaitForSeconds(closeTime);
        animator.SetBool("character_nearby", false);
        isOpen = false;
    }

    //The function used to trigger the interaction when an object is interacted with.
    public void onInteract()
    {
        StartCoroutine(toggleDoor());
    }

    public bool isInteractable()
    {
        return interactable;
    }

    public string interactionKey()
    {
        return interactionKeyCode;
    }
    private IEnumerator repairComponent(int timeToRepair)
    {
        yield return new WaitForSeconds(timeToRepair);
        health = 100;
    }

    public void repair(int experience, int modifier)
    {
        float timeReduction = 0;
        for (int i = 0; i <= experience; i++)
        {
            timeReduction += .1f;
        }

        StartCoroutine(repairComponent((int)(baseRepairTime - (baseRepairTime * timeReduction) + modifier)));
    }

    public void man()
    {
        if (!isDisabled)
        {
            //Toggle Navigation Menu
        }
    }

    public void toggleEnabled()
    {
        isDisabled = !isDisabled;
    }

    public void back()
    {
        gamemanager.instance.toggleInteractionMenu(false);
    }
}
