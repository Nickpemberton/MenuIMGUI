using System.Collections;
using System.Collections.Generic;
using NPC;
using UnityEngine;

namespace NPC
{
    [AddComponentMenu("Game System RPG/NPC/Dialogue/Three Ways")]
    public class ThreeWayDialogue : DialogueParent
    {
        
        public int questionIndex;
        public enum Approval
        {
            Dislike,
            Neutral,
            Like
        }

        public string[] dislikeText = new string[5];
        public string[] likeText = new string[5];
        public string[] neutralText = new string[5];
        
        [SerializeField] private Approval _approval; 

        void OnGUI()
        {
            if (showDialogue)
            {
                switch (_approval)
                {
                    case Approval.Like:
                        dlgText = likeText;
                        break;
                    case Approval.Dislike:
                        dlgText = dislikeText;
                        break;
                    case Approval.Neutral:
                        dlgText = neutralText;
                        break;
                }
                GUI.Box(new Rect(0, screenScale.y * 6, screenScale.x * 16, screenScale.y * 3),
                    npcName + ": " + dlgText[currentLineIndex]);

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
                        currentLineIndex = 4;
                        _approval = Approval.Like;
                    }

                    if (GUI.Button(new Rect(0, screenScale.y * 8, screenScale.x, screenScale.y), "Bye"))
                    {
                        _approval = Approval.Dislike;
                        currentLineIndex = 4;
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
        //npc gives different responses depending on approval sys
        
        /*
         Approval (can be an int or enum) has at least 3 tiers of response:
         - Dislike 1 
         - Neutral 0 
         - Like 1
         
         3 extra arrays of strings one for each approval type
         
         Dialogue changes based on approval rating
         Approval changes based on player interactions
         - have a way to ask yes or no question
         */
        
    }
}