using UnityEngine;
using TMPro;

public class ShootingController : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject CasePrefab;

    public Transform CaseEjectPoint;
    public Transform muzzle;

    public AudioSource audioSource;
    public AudioClip gunshotSound;

    public Animator animator;

    public TextMeshProUGUI ammoText;

    public float CaseForce = 2f;
    public float bulletSpeed = 20f;
    public float fireRate = 0.3f;
    public float spreadAngle = 5f;

    public int magazineSize = 30;
    public int maxReserveAmmo = 200;

    public int currentAmmo;
    public int reserveAmmo;

    public float reloadTime = 2f;

    private bool isReloading = false;
    private float nextTimeToFire = 0f;

    void Start()
    {
        currentAmmo = magazineSize;
        reserveAmmo = maxReserveAmmo;

        UpdateAmmoUI();
    }

    void Update()
    {
        if (isReloading)
            return;

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            if (currentAmmo > 0)
            {
                nextTimeToFire = Time.time + fireRate;
                Shoot();
            }
            else
            {
            }
        }

        if (Input.GetButton("Reload"))
        {
            Reload();
        }
    }

    public void Shoot()
    {
        currentAmmo--;

        animator.ResetTrigger("Shoot");
        animator.SetTrigger("Shoot");

        UpdateAmmoUI();

        float randomX = Random.Range(-spreadAngle, spreadAngle);
        float randomY = Random.Range(-spreadAngle, spreadAngle);

        audioSource.PlayOneShot(gunshotSound);

        Quaternion spreadRotation =
            muzzle.rotation *
            Quaternion.Euler(randomX, randomY, 0);

        GameObject bullet = Instantiate(
            Projectile,
            muzzle.position,
            spreadRotation
        );

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        rb.linearVelocity = bullet.transform.forward * bulletSpeed;

        if (CasePrefab != null && CaseEjectPoint != null)
        {
            GameObject Case = Instantiate(
                CasePrefab,
                CaseEjectPoint.position,
                CaseEjectPoint.rotation
            );

            Rigidbody CaseRb = Case.GetComponent<Rigidbody>();

            CaseRb.AddForce(
                CaseEjectPoint.right * CaseForce,
                ForceMode.Impulse
            );

            CaseRb.AddTorque(
                Random.insideUnitSphere * 10f,
                ForceMode.Impulse
            );

            Destroy(Case, 10f);
        }

        Destroy(bullet, 3f);
    }

    public void Reload()
    {
        if (isReloading || currentAmmo == magazineSize || reserveAmmo <= 0)
            return;

        StartCoroutine(ReloadCoroutine());
    }

    public void UpdateAmmoUI()
    {
        ammoText.text = currentAmmo + " / " + reserveAmmo;
    }

    public void AddAmmo(int amount)
    {
        reserveAmmo += amount;

        reserveAmmo = Mathf.Min(reserveAmmo, maxReserveAmmo);

        UpdateAmmoUI();
    }

    System.Collections.IEnumerator ReloadCoroutine()
    {
        isReloading = true;

        animator.SetTrigger("Reload");

        yield return new WaitForSeconds(reloadTime);

        int bulletsNeeded = magazineSize - currentAmmo;

        int bulletsToLoad = Mathf.Min(bulletsNeeded, reserveAmmo);

        currentAmmo += bulletsToLoad;
        reserveAmmo -= bulletsToLoad;

        UpdateAmmoUI();

        isReloading = false;
    }
}