using System;
using System.Collections;
using System.Collections.Generic;
using NPC;
using UnityEngine;


namespace Player 
{
    [AddComponentMenu("Game System RPG/Player/Interact")]
    public class Interact : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                //Create a ray
                Ray interact;
                //this ray is shooting out from the main cameras screen point center of screen
                interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));
                //create hit info
                RaycastHit hitInfo;
                if (Physics.Raycast(interact, out hitInfo, 10))
                {
                    #region NPC tag
                    //if that hits a tagged NPC
                    if (hitInfo.collider.tag == "NPC")
                    {
                        if (hitInfo.collider.gameObject.GetComponent<NPC.DialogueParent>())
                        {
                            hitInfo.collider.gameObject.GetComponent<NPC.DialogueParent>().OpenDialogue();
                        }
                    }
                    
                    
                    #endregion
                    #region Item tag
                    //if that hits a tagged NPC
                    if (hitInfo.collider.CompareTag("Item"))
                    {
                        Debug.Log("Hit a Item");
                    }

                    #endregion
                    #region Chest tag
                    //if that hits a tagged NPC
                    if (hitInfo.collider.tag == "Chest")
                    {
                        Debug.Log("Hit a Chest");
                    }

                    #endregion


                }
            }
        }
    }
}
