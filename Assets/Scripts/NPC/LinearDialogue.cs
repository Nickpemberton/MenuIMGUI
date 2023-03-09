using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC
{
    [AddComponentMenu("Game System RPG/NPC/Dialogue/Linear")]


    public class LinearDialogue : DialogueParent
    {
        

        private void OnGUI()
        {
            if (showDialogue)
            {
                //the dialogue box takes up the whole 3rd of the screen and displays the NPC's name and current dialogue line
                GUI.Box(new Rect(0, screenScale.y * 6, screenScale.x * 16, screenScale.y * 3), npcName + ": " + dlgText[currentLineIndex]);
                //if not at the end of the dialogue
                if (currentLineIndex < dlgText.Length -1)
                {
                    
                    //next button allows us to skip foward to the next line of dialogue
                    if (GUI.Button(new Rect(screenScale.x * 15, screenScale.y * 8, screenScale.x, screenScale.y), "Next"))
                    {
                        //incrementing currentLineIndex by 1 so that we go to next line
                        currentLineIndex++;
                    }
                }
                // else we are at the end
                else
                {
                    // bye button allows us to end dialogue
                    if (GUI.Button(new Rect(0, screenScale.y * 8, screenScale.x, screenScale.y), "Back"))
                    {
                        //closes the dialogue box
                        CloseDialogue();
                    }
                }
            }
        }
    } 
}

