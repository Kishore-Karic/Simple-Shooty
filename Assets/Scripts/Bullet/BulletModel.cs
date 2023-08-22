namespace SimpleShooty.Bullet
{
    public class BulletModel
    {
        public int Damage { get; private set; }
        public float MovementSpeed { get; private set; }
        public float DestroyTime { get; private set; }

        public BulletModel(BulletScriptableObject bulletScriptableObject)
        {
            Damage = bulletScriptableObject.Damage;
            MovementSpeed = bulletScriptableObject.MovementSpeed;
            DestroyTime = bulletScriptableObject.DestroyTime;
        }
    }
}