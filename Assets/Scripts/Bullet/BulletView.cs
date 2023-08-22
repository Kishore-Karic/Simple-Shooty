using SimpleShooty.Interface;
using UnityEngine;

namespace SimpleShooty.Bullet
{
    public class BulletView : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody RigidBody { get; private set; }

        private BulletController bulletController;
        private float currentTime;

        private void Update()
        {
            currentTime += Time.deltaTime;
            if(currentTime > bulletController.GetDestroyTime())
            {
                DestroyObject();
            }
        }

        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<IDamageable>() != null)
            {
                other.GetComponent<IDamageable>().Damage(bulletController.GetDamageValue());
            }

            DestroyObject();
        }

        private void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}