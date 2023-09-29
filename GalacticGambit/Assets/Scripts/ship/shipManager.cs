using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipManager : MonoBehaviour
{
    public static shipManager instance;

    [SerializeField] List<GameObject> thrusters;

    public shipController shipController;


    void Update()
    {
        
    }
}
