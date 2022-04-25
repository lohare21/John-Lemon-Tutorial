using UnityEngine;

public class characterStats : MonoBehaviour{
    
    public int maxHealth = 3;
    public int currentHealth { get; private set; }
    
    public Stat damage;
     
    void Awake ()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage (int damage)
    {
        currentHealth -= damage;
        Debug.Log(transform.name + "takes" + damage + "damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public virtual void Die ()
    {
        Debug.Log(transform.name + "died");
    }
}