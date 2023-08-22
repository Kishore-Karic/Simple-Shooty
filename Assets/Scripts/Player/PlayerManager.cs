using SimpleShooty.Enum;
using SimpleShooty.Game;
using SimpleShooty.GenericSingleton;
using UnityEngine;

namespace SimpleShooty.Player
{
    public class PlayerManager : GenericSingleton<PlayerManager>
    {
        [field: SerializeField] public Transform PlayerTransform { get; private set; }
        [field: SerializeField] public WeaponType WeaponType { get; private set; }
        [field: SerializeField] public Transform MainCamera { get; private set; }
        [field: SerializeField] private PlayerController playerController;

        [SerializeField] private int zero;

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
            }
        }

        public void SetEnemyOutOfRange(GameObject gameObject)
        {
            if(EnemyGameObject == gameObject)
            {
                EnemyGameObject = null;
                IsEnemyThere = false;
                EnemyPriority = zero;
            }
        }

        public void PlayerDead()
        {
            UIManager.Instance.GameOver();
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