using SimpleShooty.Bullet;
using SimpleShooty.Enum;
using SimpleShooty.Player;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleShooty.Weapon
{
    public class WeaponService : MonoBehaviour
    {
        [field: SerializeField] public BulletService BulletService { get; private set; }
        [SerializeField] private List<WeaponView> weaponPrefabs;
        [SerializeField] private List<WeaponScriptableObject> weaponScriptableObjectList;

        private PlayerController playerController;
        private bool isNewWeapon;

        public void CreateWeapon(PlayerController _playerController)
        {
            isNewWeapon = false;
            playerController = _playerController;
            int index = (int)PlayerManager.Instance.WeaponType;
            new WeaponController(new WeaponModel(weaponScriptableObjectList[index]), this, weaponPrefabs[index]);
        }

        public void CreateNewWeapon(WeaponType weaponType)
        {
            isNewWeapon = true;
            int index = (int)weaponType;
            new WeaponController(new WeaponModel(weaponScriptableObjectList[index]), this, weaponPrefabs[index]);
        }

        public void SetWeaponView(WeaponView _weaponView)
        {
            playerController.SetCurrentWeapon(_weaponView, isNewWeapon);
        }
    }
}