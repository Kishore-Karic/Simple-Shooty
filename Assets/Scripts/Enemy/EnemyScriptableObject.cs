using UnityEngine;

namespace SimpleShooty.Enemy
{
    [CreateAssetMenu(fileName = "NewEnemy", menuName = "CreateNewEnemy")]
    public class EnemyScriptableObject : ScriptableObject
    {
        public float MovementSpeed, ChaseRange, AttackRange;
        public int TotalHealth, Zero;
    }
}