using SimpleShooty.Enum;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleShooty.Enemy
{
    public class EnemyService : MonoBehaviour
    {
        [SerializeField] private List<EnemyScriptableObject> slowEnemyScriptableObject;
        [SerializeField] private List<EnemyView> enemyPrefab;
        [SerializeField] private List<SpawnPoints> spawnPoints;
        [SerializeField] private int zero;

        private void Start()
        {
            for(int i = zero; i < spawnPoints.Count; i++)
            {
                int index = (int)spawnPoints[i].EnemyType;
                for(int j = zero; j < spawnPoints[i].spawnTransforms.Count; j++)
                {
                    new EnemyController(new EnemyModel(slowEnemyScriptableObject[index]), enemyPrefab[index], spawnPoints[i].spawnTransforms[j]);
                }
            }
        }
    }

    [Serializable]
    public class SpawnPoints
    {
        public EnemyType EnemyType;
        public List<Transform> spawnTransforms;
    }
}