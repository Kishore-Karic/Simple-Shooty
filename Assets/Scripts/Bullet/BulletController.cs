using UnityEngine;

namespace SimpleShooty.Bullet
{
    public class BulletController
    {
        private BulletModel bulletModel;
        private BulletView bulletView;

        public BulletController(BulletModel _bulletModel, BulletView _bulletView, Transform spawnPoint, Quaternion spwanRotation)
        {
            bulletModel = _bulletModel;
            bulletView = _bulletView;

            bulletView.SetBulletController(this);

            bulletView.transform.position = spawnPoint.position;
            bulletView.transform.rotation = spwanRotation;
            bulletView.gameObject.SetActive(true);

            FireBullet();
        }

        private void FireBullet()
        {
            Vector3 bulletDirection = bulletView.transform.forward;
            bulletView.RigidBody.AddForce(bulletDirection * bulletModel.MovementSpeed * Time.deltaTime, ForceMode.Impulse);
        }

        public float GetDestroyTime()
        {
            return bulletModel.DestroyTime;
        }

        public int GetDamageValue()
        {
            return bulletModel.Damage;
        }
    }
}