using SimpleShooty.Enum;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleShooty.Bullet
{
    public class BulletService : MonoBehaviour
    {
        [SerializeField] private BulletView bulletPrefab;
        [SerializeField] private List<BulletScriptableObject> bulletScriptableObjectList;

        public void SpawnBullet(BulletType bulletType, Transform spawnPoint, Quaternion spawnRotation)
        {
            new BulletController(new BulletModel(bulletScriptableObjectList[(int)bulletType]), bulletPrefab, spawnPoint, spawnRotation);
        }
    }
}