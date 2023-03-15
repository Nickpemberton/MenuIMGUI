using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [AddComponentMenu("Game System RPG/Player/Mouse Look")]
    public class MouseLook : MonoBehaviour
    {
        private enum RotationalAxis
        {
            MouseX,
            MouseY
        }
        [SerializeField] private RotationalAxis _axis = RotationalAxis.MouseX; 
        public float sensitivity = 15f; //Make static after testing for putting on options menu
        public bool invertMouseY = false;
        private Vector2 _clamp = new Vector2(-60f, 60f);
        private float _rotationY;

        void Start()
        {
            if (this.gameObject.tag == "Player")
            {
                _axis = RotationalAxis.MouseX;
            }
            else
            {
                _axis = RotationalAxis.MouseY;
            }
            if (GetComponent<Rigidbody>())
            {
                GetComponent<Rigidbody>().freezeRotation = true;
            }
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        void Update()
        {
            if (GameManager.Instance.gameState == GameState.Alive)
            {
                if (_axis == RotationalAxis.MouseX)
                {
                    transform.Rotate(0,Input.GetAxis("Mouse X") * sensitivity,0);

                }
                else
                {
                    _rotationY += Input.GetAxis("Mouse Y") * sensitivity;
                    _rotationY = Mathf.Clamp(_rotationY, _clamp.x, _clamp.y);
                    if (invertMouseY)
                    {
                        transform.localEulerAngles = new Vector3(_rotationY, 0, 0);
                    }
                    else
                    {
                        transform.localEulerAngles = new Vector3(-_rotationY, 0, 0);
                    }
                }
            }
        }
    }


}

