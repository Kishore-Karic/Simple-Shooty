using SimpleShooty.Enum;
using SimpleShooty.Player;
using UnityEngine;

namespace SimpleShooty.Weapon
{
    public class WeaponPickUp : MonoBehaviour
    {
        [SerializeField] private WeaponType weaponType;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerController>())
            {
                other.GetComponent<PlayerController>().NewWeaponPickedUp(weaponType);
                Destroy(gameObject);
            }
        }
    }
}