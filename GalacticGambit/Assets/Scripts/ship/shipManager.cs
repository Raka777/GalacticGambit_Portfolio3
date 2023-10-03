using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipManager : MonoBehaviour
{
    public static shipManager instance;

    [SerializeField] List<GameObject> thrusters;
    [SerializeField] pilotSeat pilotSeat;

    //public shipController shipController;

    private void Start()
    {
        pilotSeat.takeDamage(10);
    }


    void Update()
    {
        
    }
}
