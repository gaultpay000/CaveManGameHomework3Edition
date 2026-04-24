using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private InventoryHandler _inventory;
    private int _curIndex;
    [SerializeField] private TMP_Text _weaponDisplay;
    [SerializeField] private float _curHP;
    [SerializeField] private float _maxHP = 100;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private GameObject _arrowTrackers;
    [SerializeField] private bool _isUsingBow = false;
    [SerializeField] private bool _isUsingClub = true;
    [SerializeField] private bool _isUsingSpear = false;
    [SerializeField] private bool _audioLogCollected = false;
    [SerializeField] private GameObject _clubEquip;
    [SerializeField] private GameObject _bowEquip;
    [SerializeField] private GameObject _spearEquip;
    [SerializeField] private GameObject _audioLogText;
    public float getHP { get { return _curHP; } set { _curHP = value; } }

    public void Awake()
    {
        getHP = _curHP;
        OnChangeHealth(0);
        _curIndex = 0;
        OnChangeWeapon(_inventory._weapons[1]);
    }

    public void OnChangeHealth(float Change)
    {
        _curHP -= Change;
        if (_curHP > _maxHP)
        {
            _curHP = _maxHP;
        }
        else if (_curHP < 0)
        {
            _curHP = 0;
        }
        _healthSlider.value = _curHP / _maxHP;
    }
    public void OnChangeWeapon(GameObject curWeapon)
    {
        if (curWeapon.name == "Bow EQUIP")
        {
            _isUsingBow = true;
            _isUsingClub = false;
            _isUsingSpear = false;
        }
        else if(curWeapon.name == "Club EQUIP")
        {
            _isUsingBow = false;
            _isUsingClub = true;
            _isUsingSpear = false;
        }
        else if(curWeapon.name == "Spear EQUIP")
        {
            _isUsingBow = false;
            _isUsingClub = false;
            _isUsingSpear = true;
        }

        _arrowTrackers.SetActive(_isUsingBow);
        _bowEquip.SetActive(_isUsingBow);
        _clubEquip.SetActive(_isUsingClub);
        _spearEquip.SetActive(_isUsingSpear);
        _weaponDisplay.text = $"Current Weapon: {curWeapon.name}";
    }

    public void WeaponCycle(int currentWeapon)
    {
        
        //_curIndex++;
        if (_curIndex < _inventory._weapons.Length)
        {
            OnChangeWeapon(_inventory._weapons[currentWeapon]);
        }
        //else if (_curIndex >= _inventory._weapons.Length)
        //{
        //    _curIndex = 0;
        //    OnChangeWeapon(_inventory._weapons[_curIndex]);
        //}
    }

    public void OnAudioLogGained(bool audioLogStatus)
    {
        _audioLogCollected = audioLogStatus;
        _audioLogText.SetActive(_audioLogCollected);
    }
}
