using UnityEngine;

namespace SimpleShooty.Weapon
{
    public class WeaponView : MonoBehaviour
    {
        [field: SerializeField] public Transform BulletSpawnPoint { get; private set; }

        private WeaponController weaponController;

        public void SetWeaponController(WeaponController _weaponController)
        {
            weaponController = _weaponController;
        }

        public void Shoot(Quaternion rotation)
        {
            weaponController.FireBullet(rotation);
        }

        public float GetNextShootTime()
        {
            return weaponController.GetNextShootTime();
        }

        public void DestroyWeapon()
        {
            Destroy(gameObject);
        }
    }
}