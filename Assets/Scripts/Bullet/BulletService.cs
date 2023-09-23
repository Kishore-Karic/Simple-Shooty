using SimpleShooty.Enum;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleShooty.Bullet
{
    public class BulletService : MonoBehaviour
    {
        [SerializeField] private List<BulletScriptableObject> bulletScriptableObjectList;
        [SerializeField] private BulletPoolService bulletPoolService;

        public void SpawnBullet(BulletType bulletType, Transform spawnPoint, Quaternion spawnRotation)
        {
            new BulletController(new BulletModel(bulletScriptableObjectList[(int)bulletType]), bulletPoolService.GetItem(), spawnPoint, spawnRotation);
        }
    }
}