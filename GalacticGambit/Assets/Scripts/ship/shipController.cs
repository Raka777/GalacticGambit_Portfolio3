using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipController : MonoBehaviour
{
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] float pitchStrength;
    [SerializeField] float rollStrength;
    [SerializeField] float yawStrength;
    [SerializeField] float thrustStrength;
    public Vector3 currentVelocity;

    public bool isBeingControlled;
    //Pitch, Roll, Yaw, Thrust
    private bool adjustPitch;
    private bool adjustYaw;
    private bool adjustRoll;
    private bool adjustThrust;

    public float pitch;
    public float yaw;
    public float roll;
    public float thrust;

    private float pitchDifference;
    private float yawDifference;

    public bool inertiaDampener;

    private void Start()
    {
        inertiaDampener = true;
    }

    // Update is called once per frame
    void Update()
    {

        //Ship controller is disabled until a solution can be worked through.
        if (isBeingControlled)
        {
            pitch = getPitch();
            yaw = getYaw();
            roll = getRoll();
            thrust = getThrust();

            adjustPitch = Mathf.Abs(pitch) > 0.1f;
            adjustYaw = Mathf.Abs(yaw) > 0.1f;
            adjustRoll = roll != 0;
            adjustThrust = Mathf.Abs(thrust) > 0.1f;


            if(adjustPitch )
            {
                //rotation.x = -pitch * pitchStrength;
                rigidBody.AddTorque(transform.right * (-pitch * pitchStrength), ForceMode.Force);
            }
            if(adjustYaw )
            {
                //rotation.y = yaw * pitchStrength;
                rigidBody.AddTorque(transform.up * (yaw * yawStrength), ForceMode.Force);
            }
            if(adjustRoll )
            {
                //rotation.z = roll * pitchStrength;
                rigidBody.AddTorque(transform.forward * (roll * rollStrength), ForceMode.Force);
            }
            if(adjustThrust)
            {
                rigidBody.AddForce(transform.forward * (thrust * thrustStrength), ForceMode.Force);
            }

            if (Input.GetButton("inertiaDamper"))
            {
                inertiaDampener = !inertiaDampener;
            }

            if(inertiaDampener)
            {
                dampen();
            }
        }
        //currentVelocity = rigidBody.velocity;
    }
    private float getPitch()
    {
        if (Input.GetButton("Pitch+"))
        {
            return 1.0f;
        }

        if (Input.GetButton("Pitch-"))
        {
            return -1.0f;
        }
        return 0;
    }
    private float getYaw()
    {
        if (Input.GetButton("Yaw+"))
        {
            return 1.0f;
        }

        if (Input.GetButton("Yaw-"))
        {
            return -1.0f;
        }
        return 0;
    }

    private float getRoll()
    {
        if (Input.GetButton("Roll+"))
        {
            return 1.0f;
        }

        if (Input.GetButton("Roll-"))
        {
            return -1.0f;
        }
        return 0;
    }

    private float getThrust()
    {
        if (Input.GetButton("Thrust+"))
        {
            return 1.0f;
        }

        if (Input.GetButton("Thrust-"))
        {
            return -1.0f;
        }
        return 0;
    }

    private void dampen()
    {
        Vector3 velocityNormal = new Vector3(Mathf.Lerp(rigidBody.velocity.x, 0, Time.deltaTime * 0.75f), Mathf.Lerp(rigidBody.velocity.y, 0, Time.deltaTime * 0.75f), Mathf.Lerp(rigidBody.velocity.z, 0, Time.deltaTime * 0.75f));
        Vector3 angularVelocityNormal = new Vector3(Mathf.Lerp(rigidBody.angularVelocity.x, 0, Time.deltaTime), Mathf.Lerp(rigidBody.angularVelocity.y, 0, Time.deltaTime), Mathf.Lerp(rigidBody.angularVelocity.z, 0, Time.deltaTime));

        rigidBody.velocity = velocityNormal;
        rigidBody.angularVelocity = angularVelocityNormal;
    }

    public void toggleControlling(bool state)
    {
        if(state)
        {
            isBeingControlled = true;
        }
        else
        {
            isBeingControlled = false;
        }
    }
}
