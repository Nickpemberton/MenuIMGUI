using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PauseMenu : MonoBehaviour
    {

        public bool showPause;

        public Vector2 screenScale;

        public void OpenPause()
        {
            //set show DLG to true
            showPause = true;
            //stop movement and mouselook
            GameManager.Instance.gameState = GameState.Pause;
            //set index to 0 

            //set the 16:9 screen shiz just incase we need it
            screenScale.x = Screen.width / 16;
            screenScale.y = Screen.height / 9;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }

        public void ClosePause()
        {
            //set show DLG to false
            showPause = false;
            //allow player to have movement and mouselook
            GameManager.Instance.gameState = GameState.Alive;
            //set index to 0
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (showPause)
                {
                    ClosePause();
                }
                else
                {
                    OpenPause();
                }
            }
        }

        void OnGUI()
        {
            if (showPause)
            {
                GUI.Box(new Rect(0, 0, screenScale.x * 16, screenScale.y * 9), "");
                
                if (GUI.Button(new Rect(screenScale.x * 7, screenScale.y * 2, screenScale.x * 2, screenScale.y), "Resume"))
                {
                    ClosePause();
                }

                if (GUI.Button(new Rect(screenScale.x * 7, screenScale.y * 7, screenScale.x * 2, screenScale.y),"Exit To Menu"))
                {
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }
    }
}
