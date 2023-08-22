using SimpleShooty.Enum;
using SimpleShooty.GenericSingleton;
using UnityEngine;

namespace SimpleShooty.Player
{
    public class PlayerManager : GenericSingleton<PlayerManager>
    {
        [field: SerializeField] public Transform PlayerTransform { get; private set; }
        [field: SerializeField] public WeaponType WeaponType { get; private set; }
        [SerializeField] private int zero;
        [SerializeField] private PlayerController playerController;

        public GameObject EnemyGameObject { get; private set; }
        public bool IsEnemyThere { get; private set; }
        public int EnemyPriority { get; private set; }

        public void SetEnemyInRange(GameObject gameObject, int priority)
        {
            if (!IsEnemyThere || EnemyPriority < priority)
            {
                EnemyGameObject = gameObject;
                IsEnemyThere = true;
                EnemyPriority = priority;
                Debug.Log("Enumy is there " + gameObject.name + " prio " + EnemyPriority);
            }
        }

        public void SetEnemyOutOfRange(GameObject gameObject)
        {
            if(EnemyGameObject == gameObject)
            {
                EnemyGameObject = null;
                IsEnemyThere = false;
                EnemyPriority = zero;
                Debug.Log("Enemy is not there " + gameObject.name + " prio " + EnemyPriority);
            }
        }

        public void PlayerDead()
        {
            Debug.Log("Player Dead");
        }

        public void EnemyDestroyed(GameObject gameObject)
        {
            if(gameObject == EnemyGameObject)
            {
                IsEnemyThere = false;
                EnemyGameObject = null;
                EnemyPriority = zero;
            }
        }
    }
}