using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class crewMember : MonoBehaviour
{
    [Header("--- Components ---")]
    public NavMeshAgent agent;
    [SerializeField] GameObject selectedIndicator;
    [SerializeField] GameObject waypointMarker;

    [Header("--- Stats ---")]
    public int repairExperience;
    public int repairModifier;

    bool isSelected;
    GameObject inGameWaypointMarker;
    public IInteractable selectedInteraction;
    // Update is called once per frame
    void Update()
    {
        if (inGameWaypointMarker != null)
        {
            if((agent.destination - transform.position).magnitude < .2f)
            {
                Destroy(inGameWaypointMarker);
                inGameWaypointMarker = null;
            }
        }
    }

    public void moveTo(Vector3 position)
    {
        if(inGameWaypointMarker != null)
        {
            agent.SetDestination(position);
            Destroy(inGameWaypointMarker);
            inGameWaypointMarker = null;
            inGameWaypointMarker = Instantiate(waypointMarker, position, Quaternion.identity);
            inGameWaypointMarker.transform.parent = null;
        }
        else
        {
            agent.SetDestination(position);
            inGameWaypointMarker = Instantiate(waypointMarker, position, Quaternion.identity);
            inGameWaypointMarker.transform.parent = null;
        }
    }

    public void toggleSelected(bool state)
    {
        if (state)
        {
            selectedIndicator.SetActive(true);
            isSelected = true;
        }
        else
        {
            selectedIndicator.SetActive(false);
            isSelected = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteractable interactable;
        if(other.TryGetComponent(out interactable))
        {
            interactable.onInteractable(true);
            selectedInteraction = interactable;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(selectedInteraction != null)
        {
            selectedInteraction.onInteractable(false);
            selectedInteraction = null;
        }
    }

}
