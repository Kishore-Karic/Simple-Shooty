using SimpleShooty.Enum;

namespace SimpleShooty.Weapon
{
    public class WeaponModel
    {
        public WeaponType WeaponType { get; private set; }
        public BulletType BulletType { get; private set; }
        public float NextShootTime { get; private set; }

        public WeaponModel(WeaponScriptableObject weaponScriptableObject)
        {
            WeaponType = weaponScriptableObject.WeaponType;
            BulletType = weaponScriptableObject.BulletType;
            NextShootTime = weaponScriptableObject.NextShootTime;
        }
    }
}