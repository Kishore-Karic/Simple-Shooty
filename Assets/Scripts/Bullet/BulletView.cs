using SimpleShooty.Interface;
using UnityEngine;

namespace SimpleShooty.Bullet
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private int zero;
        [field: SerializeField] public Rigidbody RigidBody { get; private set; }

        public BulletPoolService BulletPoolService;

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
            currentTime = zero;
        }

        private void OnTriggerEnter(Collider other)
        {
            IDamageable damageableObject = other.GetComponent<IDamageable>();
            if(damageableObject != null)
            {
                damageableObject.Damage(bulletController.GetDamageValue());
            }

            DestroyObject();
        }

        private void DestroyObject()
        {
            RigidBody.velocity = Vector3.zero;
            BulletPoolService.ReturnItem(this);
        }
    }
}