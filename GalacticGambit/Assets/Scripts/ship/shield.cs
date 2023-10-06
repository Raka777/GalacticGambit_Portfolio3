using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour, IDamage
{
    [SerializeField] int regenTime;
    [SerializeField] int health;

    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            StartCoroutine(regenShield());
        }
        
    }

    public IEnumerator regenShield()
    {
        gameObject.SetActive(false);
        Mathf.Lerp(currentHealth, health, regenTime);
        yield return new WaitForSeconds(regenTime);
        gameObject.SetActive(true);
    }
}
