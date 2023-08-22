using SimpleShooty.Player;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleShooty.Enemy
{
    public class EnemyHealthUI : MonoBehaviour
    {
        [SerializeField] private Slider healthUI;

        private void Start()
        {
            transform.LookAt(PlayerManager.Instance.MainCamera);
        }

        public void SetHealthUI(int _value)
        {
            healthUI.value = _value;
        }
    }
}