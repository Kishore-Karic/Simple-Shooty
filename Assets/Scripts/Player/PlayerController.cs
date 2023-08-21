using UnityEngine;

namespace SimpleShooty.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody rigidBody;
        [SerializeField] private float movementSpeed, speedNormalizer;
        [SerializeField] private int zero;
        [SerializeField] private VirtualJoyStickController virtualJoyStickController;

        private float moveXAxis, moveZAxis;
        private int horizontalVal, verticalVal;

        private void Start()
        {
            horizontalVal = Animator.StringToHash("Horizontal");
            verticalVal = Animator.StringToHash("Vertical");
        }

        private void Update()
        {
            Movement(); 
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
    }
}