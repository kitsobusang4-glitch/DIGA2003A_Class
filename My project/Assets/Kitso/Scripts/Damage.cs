using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 50;
    public Health playerHealth;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth = (Health)collision.gameObject.GetComponent<Health>();
            playerHealth.TakeDamage(damage);
        }
    }
}
