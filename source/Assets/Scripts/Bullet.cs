using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 25;

    private bool hasHit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasHit) return;

        Damageable damageable = other.GetComponentInParent<Damageable>();

        if (damageable != null)
        {
            hasHit = true;
            damageable.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}