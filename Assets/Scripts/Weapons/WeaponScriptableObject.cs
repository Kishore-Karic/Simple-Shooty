using SimpleShooty.Enum;
using UnityEngine;

namespace SimpleShooty.Weapon
{
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "ScriptableObjects/CreateNewWeapon")]
    public class WeaponScriptableObject : ScriptableObject
    {
        public WeaponType WeaponType;
        public BulletType BulletType;
        public float NextShootTime;
    }
}