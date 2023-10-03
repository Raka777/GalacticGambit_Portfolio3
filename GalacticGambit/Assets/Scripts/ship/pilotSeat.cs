using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pilotSeat : MonoBehaviour, IInteractable,IDamage
{
    [SerializeField] string interactionText;
    [SerializeField] string interactionKeyCode;
    [SerializeField] GameObject sitPosition;
    [SerializeField] Image healthBar;

    [SerializeField] int baseRepairTime;

    [SerializeField] List<Interaction> interactionsPossible;

    private bool interactable;
    private bool isSitting;

    private float health = 100;

    private bool isDisabled;

    void Update()
    {
        if (interactable && Input.GetButtonDown(interactionKeyCode))
        {
            onInteract();
        }

        if(isSitting && Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Stop Interaction");
        }
    }
    //The function used to display information when an object becomes interactable.
    public void onInteractable(bool state)
    {
        if (state)
        {
            //Debug.Log("Interactable");
            gamemanager.instance.interactionMenu.updateInteractionOptions(interactionsPossible);
            gamemanager.instance.interactionMenu.gameObject.SetActive(true);
            interactable = true;
            
        }
        else
        {
            Debug.Log("Interaction Off");
            gamemanager.instance.interactionMenu.gameObject.SetActive(false);
            interactable = false;
            gamemanager.instance.interactionMenu.clearList();
        }
        
    }  

    public void takeDamage(int amount)
    {
        health -= amount;
        healthBar.fillAmount = health / 100;
    }

    //The function used to trigger the interaction when an object is interacted with.
    public void onInteract()
    {
    Debug.Log("Interact");
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
        Debug.Log("Man");
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
