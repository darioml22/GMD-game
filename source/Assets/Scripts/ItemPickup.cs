using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum ItemType
    {
        Ammo,
        Medkit
    }

    public ItemType itemType;

    public int value = 30;

    public float rotateSpeed = 90f;
    public float floatSpeed = 2f;
    public float floatHeight = 0.25f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);

        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        transform.position = new Vector3(
            transform.position.x,
            newY,
            transform.position.z
        );
    }

    void OnTriggerEnter(Collider other)
    {
        switch (itemType)
        {
            case ItemType.Ammo:
                var weapon = other.GetComponentInChildren<ShootingController>();
                if (weapon != null)
                {
                    weapon.AddAmmo(value);
                    Destroy(gameObject);
                }
                break;

            case ItemType.Medkit:

                Damageable damageable = other.GetComponent<Damageable>();

                if (damageable != null && damageable.isPlayer)
                {
                    damageable.Heal(value);
                    Destroy(gameObject);
                }

                break;
        }
    }
}