using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CycleWeaponHandler : MonoBehaviour
{
    public UnityEvent CycleWeapon;
    public UnityEvent EquipClub;
    public UnityEvent EquipBow;
    public UnityEvent EquipSpear;

    public InputActionReference cycleWeaponAction;

    private void OnEnable()
    {
        cycleWeaponAction.action.Enable();
        //cycleWeaponAction.action.performed += OnCycleWeapon;
    }

    private void OnDisable()
    {
        //cycleWeaponAction.action.performed -= OnCycleWeapon;
        cycleWeaponAction.action.Disable();
    }

    //private void OnCycleWeapon(InputAction.CallbackContext context)
    //{
    //    CycleWeapon.Invoke();
    //}

    //void EquipingClub(InputAction.CallbackContext context) 
    //{
    //    EquipClub.Invoke();
    //}
    //void EquipingBow(InputAction.CallbackContext context)
    //{
    //    EquipBow.Invoke();
    //}
    //void EquipingSpear(InputAction.CallbackContext context)
    //{
    //    EquipSpear.Invoke();
    //}
}
