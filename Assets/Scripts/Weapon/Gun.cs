using UnityEngine;

public class Gun : WeaponBase
{
    public Gun(IWeaponBehavior weaponBehavior)
    {
        this.weaponBehavior = weaponBehavior;
    }
}
