using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] int damage;
    [SerializeField] int speed;
    [SerializeField] float destoryTime;

    void Start()
    {
        rigidBody.velocity = transform.forward * speed;
        Destroy(gameObject, destoryTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamage damageable = other.GetComponent<IDamage>();
        if(damageable != null)
        {
            damageable.takeDamage(damage);
        }
        Destroy(gameObject);
    }
}
