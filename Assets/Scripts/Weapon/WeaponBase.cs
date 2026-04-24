using UnityEngine;

public abstract class WeaponBase
{
    public IWeaponBehavior weaponBehavior;

    public Transform firePoint;

    public void SetWeaponBehavior(IWeaponBehavior newBehavior)
    {
        weaponBehavior = newBehavior;
    }

    public void Use()
    {
        if (weaponBehavior != null)
        {
            weaponBehavior.Fire(firePoint);
        }
    }
}
