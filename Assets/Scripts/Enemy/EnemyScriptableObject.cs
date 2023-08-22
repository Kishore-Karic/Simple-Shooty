using SimpleShooty.Enum;
using UnityEngine;

namespace SimpleShooty.Enemy
{
    [CreateAssetMenu(fileName = "NewEnemy", menuName = "ScriptableObjects/CreateNewEnemy")]
    public class EnemyScriptableObject : ScriptableObject
    {
        public EnemyType EnemyType;
        public float MovementSpeed, ChaseRange, AttackRange, PlayerRange;
        public int TotalHealth, Zero;
    }
}