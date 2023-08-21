using SimpleShooty.GenericSingleton;
using UnityEngine;

namespace SimpleShooty.Player
{
    public class PlayerManager : GenericSingleton<PlayerManager>
    {
        [field: SerializeField] public Transform PlayerTransform { get; private set; }

        public void PlayerDead()
        {
            Debug.Log("Player Dead");
        }
    }
}