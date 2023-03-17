using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Shoot : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Ray bullet;
                bullet = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

                RaycastHit hitInfo;

                if (Physics.Raycast(bullet, out hitInfo, 500))
                {
                    if (hitInfo.collider.tag == "NPC")
                    {
                        hitInfo.collider.gameObject.SetActive(false);
                        Debug.Log("Active");
                    }
                }

            }
        }
            
    }
}