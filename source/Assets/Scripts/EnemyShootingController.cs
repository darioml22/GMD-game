using UnityEngine;

public class EnemyShootingController : MonoBehaviour
{
    public GameObject projectile;
    public Transform muzzle;

    public AudioSource audioSource;
    public AudioClip shootSound;

    public float fireRate = 0.3f;
    public float bulletSpeed = 20f;

    private float nextFireTime;

    private enum State
    {
        Shooting,
        Reloading,
        IdlePause
    }

    private State state;
    private float stateTimer;

    void Start()
    {
        state = State.Shooting;
        stateTimer = 0f;
    }

    public void TryShoot()
    {
        if (state != State.Shooting) return;

        if (Time.time < nextFireTime) return;

        nextFireTime = Time.time + fireRate;
        Shoot();

        float roll = Random.value;

        if (roll < 0.05f)
            StartReload();
        else if (roll < 0.15f)
            StartPause();
    }

    void StartPause()
    {
        state = State.IdlePause;
        stateTimer = Random.Range(0.5f, 2f);
    }

    void StartReload()
    {
        state = State.Reloading;
        stateTimer = 2f; 
    }

    void Shoot()
    {
        if (audioSource && shootSound)
            audioSource.PlayOneShot(shootSound);

        GameObject bullet = Instantiate(
            projectile,
            muzzle.position,
            muzzle.rotation
        );

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
            rb.linearVelocity = muzzle.forward * bulletSpeed;

        Destroy(bullet, 3f);
    }

    void Update()
    {
        if (state == State.IdlePause || state == State.Reloading)
        {
            stateTimer -= Time.deltaTime;

            if (stateTimer <= 0f)
            {
                state = State.Shooting;
            }
        }
    }
}