using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NPC
{
    [AddComponentMenu("Game System RPG/NPC/Dialogue/Parent DO NOT ATTACH")]
    public class DialogueParent : MonoBehaviour
    {
        //boolean to toggle if we can see a characters dialogue
        public bool showDialogue;

        //name of the specific NPC
        public string npcName;

        //array for text for our dialogue
        public string[] dlgText;

        //index for our current line of dialogue
        public int currentLineIndex;

        //screen Scale will hold our x and y float values
        public Vector2 screenScale;
        
    

        public void OpenDialogue()
        {
            //set show DLG to true
            showDialogue = true;
            //stop movement and mouselook
            GameManager.Instance.gameState = GameState.MenuOpenMisc;
            //set index to 0 
            currentLineIndex = 0;
            //set the 16:9 screen shiz just incase we need it
            screenScale.x = Screen.width / 16;
            screenScale.y = Screen.height / 9;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
        }
        
        public void CloseDialogue()
        {
            //set show DLG to false
            showDialogue = false;
            //allow player to have movement and mouselook
            GameManager.Instance.gameState = GameState.Alive;
            //set index to 0
            currentLineIndex = 0;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}

