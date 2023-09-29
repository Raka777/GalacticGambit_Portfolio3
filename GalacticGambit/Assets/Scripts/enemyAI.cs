using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    [SerializeField] shipManager ship;
    [SerializeField] float movementSpeed;
    [SerializeField] float orbitSpeed;
    [SerializeField] float orbitRange;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletShootPosition;
    [SerializeField] float bulletShootRate;
    [SerializeField] float bulletShootRange;
    [SerializeField] int bulletCount;
    [SerializeField] GameObject missle;
    [SerializeField] GameObject missleShootPosition;
    [SerializeField] float missleShootRate;
    [SerializeField] float missleShootRange;
    [SerializeField] int missleCount;

    private bool isOrbitting;
    private bool isShootingBullet;
    private bool isShootingMissle;

    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, ship.transform.position);

        if(!isOrbitting && distanceToTarget > orbitRange)
        {
            Vector3 moveDirection = (ship.transform.position - transform.position).normalized;
            transform.position += moveDirection * movementSpeed * Time.deltaTime;
            transform.LookAt(ship.transform.position);
        }

        //Only orbits in 2d, additional functionilty required.
        else
        {
            isOrbitting = true;
            transform.RotateAround(ship.transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
            transform.LookAt(ship.transform.position);
        }

        if (distanceToTarget < bulletShootRange && !isShootingBullet && bulletCount > 0)
        {
            StartCoroutine(shootBullet());
        }

        if(distanceToTarget < missleShootRange && !isShootingMissle && missleCount > 0)
        {
            StartCoroutine(shootMissle());
        }
    }

    IEnumerator shootBullet()
    {
        isShootingBullet = true;
        Debug.Log("Spawn bullet");
        Instantiate(bullet, bulletShootPosition.transform.position, transform.rotation);
        bulletCount--;
        yield return new WaitForSeconds(bulletShootRate);
        isShootingBullet = false;
    }
    IEnumerator shootMissle()
    {
        isShootingMissle = true;
        Instantiate(missle, missleShootPosition.transform.position, transform.rotation);
        missleCount--;
        yield return new WaitForSeconds(missleShootRate);
        isShootingMissle = false;
    }
}
