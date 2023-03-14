using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
    {
    [AddComponentMenu("Game System RPG/Player/Movement")]
    [RequireComponent(typeof(CharacterController))] // assigns the character controller to the object this script is on
    public class Movement : MonoBehaviour
    {
        private CharacterController _charC;
        [SerializeField] private Vector3 _moveDir = Vector3.zero;


        [Space(25), Header("Speeds")]
        public float speed = 5f;
        public float gravity = 20f, jumpSpeed = 8f;

        void Start()
        {
            _charC = this.GetComponent<CharacterController>(); 
        }
        void Update()
        {
            if (GameManager.Instance.gameState == GameState.Alive)
            {
                
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    speed = 5f;
                }
                if (_charC.isGrounded)
                {
                    /*
                    _moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    _moveDir = transform.TransformDirection(_moveDir);
                    _moveDir *= speed;
                    */

                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        speed = 7f;
                    }
                    
                    


                    _moveDir = speed * transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0,Input.GetAxis("Vertical")));

                    if (Input.GetButton("Jump"))
                    {
                        _moveDir.y = jumpSpeed;
                    }
                }
                _moveDir.y -= gravity * Time.deltaTime;
                _charC.Move(_moveDir * Time.deltaTime);
            }
        }
    }
}

