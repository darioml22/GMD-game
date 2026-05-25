using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{
    public int damage = 10;
    public float cooldown = 1f;

    private float lastDamageTime;

    void OnCollisionStay(Collision collision)
    {
        TryDamage(collision.gameObject);
    }

    void OnTriggerStay(Collider other)
    {
        TryDamage(other.gameObject);
    }

    void TryDamage(GameObject obj)
    {
        if (Time.time < lastDamageTime + cooldown)
            return;

        Damageable damageable = obj.GetComponent<Damageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(damage);
            lastDamageTime = Time.time;
        }
    }
}