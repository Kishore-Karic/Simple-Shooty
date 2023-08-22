using SimpleShooty.Enum;
using SimpleShooty.Weapon;
using UnityEngine;

namespace SimpleShooty.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody rigidBody;
        [SerializeField] private float movementSpeed, speedNormalizer, cameraDistanceAtY, cameraDistanceAtZ;
        [SerializeField] private int zero;
        [SerializeField] private VirtualJoyStickController virtualJoyStickController;
        [SerializeField] private WeaponService weaponService;
        [SerializeField] private Transform mainCamera;

        private float moveXAxis, moveZAxis, currentTime, nextShootTime;
        private int horizontalVal, verticalVal;
        private WeaponView weaponView;

        private void Start()
        {
            horizontalVal = Animator.StringToHash("Horizontal");
            verticalVal = Animator.StringToHash("Vertical");

            GetWeapon();
        }

        private void Update()
        {
            Movement();

            if (PlayerManager.Instance.IsEnemyThere)
            {
                transform.LookAt(PlayerManager.Instance.EnemyGameObject.transform);

                currentTime += Time.deltaTime;
                if(currentTime > nextShootTime && weaponView)
                {
                    currentTime = zero;
                    weaponView.Shoot(transform.rotation);
                }
            }
            else
            {
                transform.rotation = Quaternion.identity;
            }
        }

        private void LateUpdate()
        {
            mainCamera.position = new Vector3(transform.position.x, cameraDistanceAtY, transform.position.z - cameraDistanceAtZ);
        }

        private void Movement()
        {
            moveXAxis = virtualJoyStickController.GetHorizontalInput();
            moveZAxis = virtualJoyStickController.GetVerticalInput();

            if (moveXAxis != zero)
            {
                Vector3 position = transform.position;
                position.x += moveXAxis * movementSpeed * speedNormalizer * Time.deltaTime;
                transform.position = position;
            }
            animator.SetFloat(horizontalVal, moveXAxis);

            if (moveZAxis != zero)
            {
                Vector3 position = transform.position;
                position.z += moveZAxis * movementSpeed * speedNormalizer * Time.deltaTime;
                transform.position = position;
            }
            animator.SetFloat(verticalVal, moveZAxis);
        }

        private void GetWeapon()
        {
            weaponService.CreateWeapon(this);
        }

        public void SetCurrentWeapon(WeaponView _weaponView, bool newWeapon)
        {
            if (newWeapon)
            {
                weaponView.DestroyWeapon();
                weaponView = null;
            }

            weaponView = _weaponView;
            nextShootTime = weaponView.GetNextShootTime();
        }

        public void NewWeaponPickedUp(WeaponType weaponType)
        {
            weaponService.CreateNewWeapon(weaponType);
        }
    }
}