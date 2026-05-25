using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public int CurrentHealth => currentHealth;

    public bool isPlayer = false;

    private void Start()
    {
        currentHealth = maxHealth;

        if (!isPlayer)
        {
            GameManager.instance.RegisterEnemy();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    void Die()
    {
        if (isPlayer)
        {
            GameManager.instance.PlayerDied();
        }
        else
        {
            GameManager.instance.UnregisterEnemy();
        }

        Destroy(gameObject);
    }
}