using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using UnityEngine;

namespace Player
{
    public class Shoot : MonoBehaviour
    {
        public bool gunActive;
        public float bulletDrop;
        public GameObject bulletHole;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && gunActive == false)
            {
                Debug.Log("Active");
                gunActive = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Deactivated");
                gunActive = false;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && gunActive)
            {
                Ray bullet;
                bullet = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

                RaycastHit hitInfo;
                
                
                

                if (Physics.Raycast(bullet, out hitInfo, 500))
                {
                    if (hitInfo.collider.tag == "NPC")
                    {
                        hitInfo.collider.gameObject.GetComponent<NPC.NpcHealth>().RemoveHealth(50);
                        Debug.Log("Shot a bullet");
                    }
                }

            }
        }
    }
}