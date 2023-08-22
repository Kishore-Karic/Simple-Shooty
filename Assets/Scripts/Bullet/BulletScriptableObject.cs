using UnityEngine;

namespace SimpleShooty.Bullet
{
    [CreateAssetMenu(fileName = "NewBullet", menuName = "ScriptableObjects/CreateNewBullet")]
    public class BulletScriptableObject : ScriptableObject
    {
        public int Damage;
        public float MovementSpeed, DestroyTime;
    }
}