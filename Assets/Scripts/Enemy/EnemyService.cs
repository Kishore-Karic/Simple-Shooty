using UnityEngine;

namespace SimpleShooty.Enemy
{
    public class EnemyService : MonoBehaviour
    {
        [SerializeField] private EnemyScriptableObject[] slowEnemyScriptableObject;
        [SerializeField] private EnemyView[] enemyPrefab;
        public Transform[] transforms;

        private void Start()
        {
            new EnemyController(new EnemyModel(slowEnemyScriptableObject[0]), enemyPrefab[0], transforms[0]);
            new EnemyController(new EnemyModel(slowEnemyScriptableObject[1]), enemyPrefab[1], transforms[1]);
        }
    }
}