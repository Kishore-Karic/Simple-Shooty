using SimpleShooty.Enum;

namespace SimpleShooty.Enemy
{
    public class EnemyModel
    {
        public EnemyType EnemyType { get; private set; }
        public float MovementSpeed { get; private set; }
        public float ChaseRange { get; private set; }
        public float AttackRange { get; private set; }
        public float PlayerRange { get; private set; }
        public int TotalHealth { get; private set; }
        public int CurrentHealth { get; private set; }
        public int Zero { get; private set; }

        public EnemyModel(EnemyScriptableObject enemyScriptableObject)
        {
            EnemyType = enemyScriptableObject.EnemyType;
            MovementSpeed = enemyScriptableObject.MovementSpeed;
            ChaseRange = enemyScriptableObject.ChaseRange;
            AttackRange = enemyScriptableObject.AttackRange;
            PlayerRange = enemyScriptableObject.PlayerRange;
            TotalHealth = enemyScriptableObject.TotalHealth;
            CurrentHealth = TotalHealth;
            Zero = enemyScriptableObject.Zero;
        }

        public void SetCurrentHealth(int value)
        {
            CurrentHealth = value;
        }
    }
}