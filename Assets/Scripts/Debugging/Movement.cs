using UnityEngine;
namespace Debugging
{
    [AddComponentMenu("RPG/Player/Movement")]
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        [Header("Speed Vars")]
        public float moveSpeed;
        public float walkSpeed, runSpeed, crouchSpeed, jumpSpeed;
        private float _gravity = 20f;
        private Vector3 _moveDir;
        private CharacterController _charC;
        
        private void Start()
        {
            _charC = this.GetComponent<CharacterController>();
        }
        private void Update()
        {
            Move();
        }
        private void Move()
        {
            if (_charC.isGrounded)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    moveSpeed = runSpeed;
                }
                else if (Input.GetKey(KeyCode.LeftControl))
                {
                    moveSpeed = crouchSpeed;
                }
                else
                {
                    moveSpeed = walkSpeed;
                }
                _moveDir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed); 
                if (Input.GetButton("Jump"))
                {
                    _moveDir.y = jumpSpeed;
                }
            }
            _moveDir.y -= _gravity * Time.deltaTime;
            _charC.Move(_moveDir * Time.deltaTime);
        }
        }
    }

