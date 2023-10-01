using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class topDownPlayerController : MonoBehaviour
{
    [Header("--- Components ---")]
    [SerializeField] Camera camera;
    

    [SerializeField] float cameraSensitivity;
    [SerializeField] int heightMaxLimitation;
    [SerializeField] int heightMinLimitation;
    [SerializeField] int widthMaxLimitation;
    [SerializeField] int widthMinLimitation;

    [SerializeField] float zoomSpeed;
    [SerializeField] float minFieldOfView;
    [SerializeField] float maxFieldOfView;

    crewMember selectedCrewMember;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        zoom();
        crewMemberControl();
    }

    void movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveTo = transform.position + new Vector3(verticalInput, 0, -horizontalInput) * cameraSensitivity * Time.deltaTime;

        transform.position = moveTo;
    }

    void zoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        camera.fieldOfView += zoomSpeed * -scroll;

        camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, minFieldOfView, maxFieldOfView);
    }

    void crewMemberControl()
    {
        if (selectedCrewMember == null && Input.GetButton("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                crewMember crew;
                if(hit.collider.TryGetComponent(out crew))
                {
                    selectedCrewMember = crew;
                    selectedCrewMember.toggleSelected(true);
                }
            }
        }
        else if(Input.GetButtonDown("Cancel"))
        {
            selectedCrewMember.toggleSelected(false);
            selectedCrewMember = null;
        }
        else
        {
            if(selectedCrewMember != null && Input.GetButton("Fire2"))
            {
                RaycastHit hit;
                if(Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    NavMeshHit navMeshHit;
                    IInteractable interactable;
                    if(NavMesh.SamplePosition(hit.point, out navMeshHit, 100, NavMesh.AllAreas))
                    {
                        selectedCrewMember.moveTo(hit.point);
                    }
                    else if (hit.collider.TryGetComponent(out interactable))
                    {
                        interactable.onInteractable(true);
                        selectedCrewMember.moveTo(hit.point);
                    }
                }
            }
        }
    }
}
