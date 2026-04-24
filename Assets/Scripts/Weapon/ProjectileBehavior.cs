using UnityEngine;

public class ProjectileBehavior : IWeaponBehavior
{
    public  GameObject projectilePrefab;
    public float projectileSpeed;
    public int ammo;

    public void Fire(Transform firePoint)
    {
        if (projectilePrefab == null) {
            Debug.LogError("No projectile prefab");
            return;
        }

        if (ammo > 0)
        {
        GameObject newProjectile = GameObject.Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = newProjectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * projectileSpeed;
        }
        }
    }
}
