using UnityEngine;

public class MeleeBehavior : IWeaponBehavior
{
    public GameObject projectilePrefab;
    public float projectileSpeed;
    public Club club;

    public void Fire(Transform firePoint)
    {
        club.Launch();
    }
}
