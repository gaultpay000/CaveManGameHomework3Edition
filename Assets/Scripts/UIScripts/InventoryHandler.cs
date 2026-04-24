using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    [SerializeField] private GameObject[] _inventory;
    [SerializeField] public GameObject[] _weapons;
    [SerializeField] private TMP_Text CurrentWeaponDisplay;
    [SerializeField] private UIHandler _uiHandler;
}

