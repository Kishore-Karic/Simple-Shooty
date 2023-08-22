using UnityEngine;

namespace SimpleShooty.Weapon
{
    public class WeaponController
    {
        private WeaponModel weaponModel;
        private WeaponView weaponView;
        private WeaponService weaponService;

        public WeaponController(WeaponModel _weaponModel, WeaponService _weaponService, WeaponView _weaponView)
        {
            weaponModel = _weaponModel;
            weaponService = _weaponService;
            weaponView = GameObject.Instantiate(_weaponView, _weaponService.transform);
            weaponView.SetWeaponController(this);
            weaponService.SetWeaponView(weaponView);
        }

        public WeaponView ReturnWeaponView()
        {
            return weaponView;
        }

        public float GetNextShootTime()
        {
            return weaponModel.NextShootTime;
        }

        public void FireBullet(Quaternion rotation)
        {
            weaponService.BulletService.SpawnBullet(weaponModel.BulletType, weaponView.BulletSpawnPoint, rotation);
        }
    }
}