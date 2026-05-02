using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    public int currentHealth;
    public int maxHealth = 100;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("You're dead");
            OnPlayerDeath?.Invoke();
        }
    }
}
