using UnityEngine;

namespace SimpleShooty.Enemy
{
    public class EnemyService : MonoBehaviour
    {
        [SerializeField] private EnemyScriptableObject slowEnemyScriptableObject;
        [SerializeField] private EnemyView enemyPrefab;

        private void Start()
        {
            new EnemyController(new EnemyModel(slowEnemyScriptableObject), enemyPrefab, transform);
        }
    }
}