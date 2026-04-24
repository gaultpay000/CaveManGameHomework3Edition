using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    public WeaponBase weapon;
    public Transform firepoint;
    public GameObject projectilePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weapon = new Gun(new RaycastBehavior());
        weapon.firePoint = firepoint;
        weapon.SetWeaponBehavior(new RaycastBehavior{range = 10});
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current[Key.Digit1].wasPressedThisFrame)
        {
            weapon.SetWeaponBehavior(new RaycastBehavior { range = 10 });
        }

        if (Keyboard.current[Key.Digit2].wasPressedThisFrame)
        {
            weapon.SetWeaponBehavior(new ProjectileBehavior { projectilePrefab = projectilePrefab, projectileSpeed = 20, ammo = 10});
        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            weapon.Use();
        }
    }
}
