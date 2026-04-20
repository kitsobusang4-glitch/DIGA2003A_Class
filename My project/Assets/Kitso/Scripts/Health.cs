using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    public int health;
    public int maxHealth = 10;
    void Start()
    {
        health = maxHealth;
    }

    

    public void TakeDamage(int amount)
    {
        health -= amount;  

        if(health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("You're dead");
            OnPlayerDeath?.Invoke();
        }
    }
}
