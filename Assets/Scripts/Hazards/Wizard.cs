using UnityEngine;

public class Wizard : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform firePoint;
    [SerializeField] Transform player;
    [SerializeField] GameObject projectilePrefab;

    [Header("Settings P1")]
    [SerializeField] float firePointRotateSpeed = 5f;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 10f;
    [SerializeField] public float fireInterval = 4f;

    [Header("Settings P2")]
    [SerializeField] int projectileCount = 30;

    public bool fire = false;

    float fireTimer;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        bool flowControl = AimAtPlayer();
        if (!flowControl) return;

        if (fire) FireProjectile();
    }

    private void FireProjectile()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireInterval)
        {
            SpawnProjectile(firePoint.position, firePoint.rotation);
            fireTimer = 0f;
        }
    }

    private bool AimAtPlayer()
    {
        if (player == null || firePoint == null) return false;

        Vector3 direction = (player.position - firePoint.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(direction);

        firePoint.rotation = Quaternion.Slerp(firePoint.rotation, lookRotation, firePointRotateSpeed * Time.deltaTime);
        return true;
    }

    void SpawnProjectile(Vector3 ProPosition, Quaternion ProRotation)
    {
        GameObject projectileObj = Instantiate(projectilePrefab, ProPosition, ProRotation);
        Projectile projectile = projectileObj.GetComponent<Projectile>();

        audioSource.Play();

        if (projectile != null)
        {
            projectile.Init(firePoint.forward, projectileSpeed, projectileLifetime);
        }
    }

}
