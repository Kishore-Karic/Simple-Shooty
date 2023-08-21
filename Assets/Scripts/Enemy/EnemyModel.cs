namespace SimpleShooty.Enemy
{
    public class EnemyModel
    {
        public float MovementSpeed { get; private set; }
        public float ChaseRange { get; private set; }
        public float AttackRange { get; private set; }
        public int TotalHealth { get; private set; }
        public int Zero { get; private set; }

        public EnemyModel(EnemyScriptableObject enemyScriptableObject)
        {
            MovementSpeed = enemyScriptableObject.MovementSpeed;
            ChaseRange = enemyScriptableObject.ChaseRange;
            AttackRange = enemyScriptableObject.AttackRange;
            TotalHealth = enemyScriptableObject.TotalHealth;
            Zero = enemyScriptableObject.Zero;
        }
    }
}