using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace NPC
{
    [AddComponentMenu("Game System RPG/NPC/Dialogue/Options")]
    public class OptionDialogue : DialogueParent //Cannot inherent from more than one class, 
{
    //index for the question to be asked
    public int questionIndex;

    private void OnGUI()
    {
        if (showDialogue)
        {
            GUI.Box(new Rect(0, screenScale.y * 6, screenScale.x * 16, screenScale.y * 3), npcName + ": " + dlgText[currentLineIndex]);
            if (currentLineIndex < dlgText.Length - 1 && currentLineIndex != questionIndex)
            {
                if (GUI.Button(new Rect(screenScale.x * 15, screenScale.y * 8, screenScale.x, screenScale.y), "Next"))
                {
                    currentLineIndex++;
                }
                
            }
            else if (currentLineIndex == questionIndex)
            {
                if (GUI.Button(new Rect(screenScale.x * 15, screenScale.y * 8, screenScale.x, screenScale.y),
                        "Accept"))
                {
                    currentLineIndex++;
                }

                if (GUI.Button(new Rect(0, screenScale.y * 8, screenScale.x, screenScale.y), "Back"))
                {

                    CloseDialogue();
                }
                    
            }
            else
            {
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
