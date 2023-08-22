using SimpleShooty.Enum;
using SimpleShooty.Game;
using SimpleShooty.Weapon;
using UnityEngine;

namespace SimpleShooty.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody rigidBody;
        [SerializeField] private float movementSpeed, speedNormalizer, cameraDistanceAtY, cameraDistanceAtZ, fallDistance;
        [SerializeField] private int zero;
        [SerializeField] private WeaponService weaponService;

        private Transform mainCamera;
        private VirtualJoyStickController virtualJoyStickController;
        private float moveXAxis, moveZAxis, currentTime, nextShootTime;
        private int horizontalVal, verticalVal;
        private WeaponView weaponView;

        private void Start()
        {
            virtualJoyStickController = UIManager.Instance.VirtualJoyStickController;
            mainCamera = PlayerManager.Instance.MainCamera;

            horizontalVal = Animator.StringToHash("Horizontal");
            verticalVal = Animator.StringToHash("Vertical");

            GetWeapon();
        }

        private void Update()
        {
            if(transform.position.y < fallDistance)
            {
                UIManager.Instance.GameOver();
            }

            Movement();

            if (PlayerManager.Instance.IsEnemyThere)
            {
                transform.LookAt(PlayerManager.Instance.EnemyGameObject.transform.position);
                animator.SetBool("Aim", true);
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
                animator.SetBool("Aim", false);
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

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("FinishArea"))
            {
                UIManager.Instance.GameWon();
            }
        }
    }
}