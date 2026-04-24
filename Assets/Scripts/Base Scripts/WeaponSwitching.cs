using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder;
using UnityEngine.UI;

public class WeaponSwitching : MonoBehaviour
{
    CycleWeaponHandler weaponEventHandler;
    public WeaponBase weapon;
    public Transform firepoint;
    public GameObject projectilePrefab;
    // [SerializeField] TextMeshProUGUI text;
    // [SerializeField] TextMeshProUGUI healthText;
    // [SerializeField] TextMeshProUGUI ammoText;
    // [SerializeField] TextMeshProUGUI logText;
    int ammo = 10;

    int health = 0;
    [SerializeField] Club clubScript;

    public int weaponCurrent = 0;

    bool findRaycast = false;

    bool findInstantiate = false;

    public List<int> weaponInventory = new List<int>() { 0, 1, 2 };

    enum CurWeapon
    {
        none,
        melee,
        raycast,
        instantiate
    }

    CurWeapon curWeapon;

    void Start()
    {
        weaponEventHandler = GetComponent<CycleWeaponHandler>();
        //logText.gameObject.SetActive(false);
        weapon = new Gun(new RaycastBehavior());
        weapon.firePoint = firepoint;
        weapon.SetWeaponBehavior(new NoWeaponBehavior { });
    }

    void Update()
    {
        // healthText.text = health.ToString();
        // text.text = curWeapon.ToString();
        // ammoText.text = ammo.ToString();

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (ammo == 0 && curWeapon == CurWeapon.instantiate)
                return;

            weapon.Use();

            if (curWeapon == CurWeapon.instantiate)
            {
                ammo--;
            }
        }


        if (Mouse.current.scroll.ReadValue().y == 1)
        {
            RotateWeapon(true);
        }
        else if (Mouse.current.scroll.ReadValue().y == -1)
        {
            RotateWeapon(false);

        }
    }

    void RotateWeapon(bool isGoingUp)
    {
        if (isGoingUp)
            weaponCurrent++;
        else
            weaponCurrent--;

        if (weaponCurrent < 0)
            weaponCurrent = weaponInventory.Count - 1;

        weaponCurrent %= weaponInventory.Count;
        WeaponLogic();
    }

    void WeaponLogic()
    {
        firepoint = transform;
        weapon.firePoint = firepoint;
        if (weaponInventory[weaponCurrent] == 0)
        {
            curWeapon = CurWeapon.none;
            weapon.SetWeaponBehavior(new NoWeaponBehavior { });
            weaponEventHandler.EquipSpear.Invoke();

            // make none behavior
        }

        if (weaponInventory[weaponCurrent] == 1)
        {
            weaponEventHandler.EquipClub.Invoke();
            curWeapon = CurWeapon.melee;
            weapon.SetWeaponBehavior(new MeleeBehavior { club = clubScript });
            //make melee behavior
        }

        //if (weaponInventory[weaponCurrent] == 2)
        //{
        //    curWeapon = CurWeapon.raycast;
        //    weapon.SetWeaponBehavior(new RaycastBehavior { range = 50 });

        //}
        if (weaponInventory[weaponCurrent] == 2)
        {
            weaponEventHandler.EquipBow.Invoke();
            curWeapon = CurWeapon.instantiate;
            weapon.SetWeaponBehavior(new ProjectileBehavior
            {
                projectilePrefab = projectilePrefab,
                projectileSpeed = 50,
                ammo = ammo
            });
            firepoint = clubScript.gameObject.transform;
            weapon.firePoint = firepoint;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Collectable>() != null)
        {
            //if (other.gameObject.GetComponent<Collectable>().pickUp == Collectable.PickUp.raycast
            //    && findRaycast == false)
            //{
            //    weaponInventory.Add(2);
            //Destroy(other.gameObject);
            //findRaycast = true;

            if (other.gameObject.GetComponent<Collectable>().pickUp == Collectable.PickUp.instantiate
                && findInstantiate == false)
            {
                weaponInventory.Add(3);
                Destroy(other.gameObject);
                findInstantiate = true;
            }

            if (other.gameObject.GetComponent<Collectable>().pickUp == Collectable.PickUp.smallHealth)
            {
                health += 10;
                Destroy(other.gameObject);
            }
            if (other.gameObject.GetComponent<Collectable>().pickUp == Collectable.PickUp.largeHealth)
            {
                health += 25;
                Destroy(other.gameObject);
            }

            //if (other.gameObject.GetComponent<Collectable>().pickUp == Collectable.PickUp.arrow)
            //{
            //    ammo += 5;
            //    Destroy(other.gameObject);
            //}
            if (other.gameObject.GetComponent<Collectable>().pickUp == Collectable.PickUp.log)
            {
                //StartCoroutine(LogText());
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.GetComponent<Projectile>() != null)
        {
            if (other.gameObject.GetComponent<Projectile>().collectable == true)
            {
                ammo++;
                Debug.Log("got arrow");
                Destroy(other.gameObject);
            }
        }

    }
}
    // IEnumerator LogText()
    // {
    //     logText.gameObject.SetActive(true);
    //     yield return new WaitForSeconds(2f);
    //     logText.gameObject.SetActive(false);
    // }
