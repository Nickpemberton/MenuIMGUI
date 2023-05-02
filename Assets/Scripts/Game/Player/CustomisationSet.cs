using System.Collections.Generic;
using UnityEngine;
//you will need to change Scenes
using UnityEngine.SceneManagement;
public class CustomisationSet : Stats
{
    #region Variables   
    [Header("Character Name")]
    //name of our character that the user is making
    public string characterName;
    [Header("Texture List")]
    //Texture2D List for skin,hair, mouth, eyes
    public List<Texture2D> skin = new List<Texture2D>(); //1
    public List<Texture2D> mouth = new List<Texture2D>(); //2
    public List<Texture2D> eyes = new List<Texture2D>(); //3
    public List<Texture2D> hair = new List<Texture2D>(); //4
    public List<Texture2D> clothes = new List<Texture2D>();//5
    public List<Texture2D> armour = new List<Texture2D>(); //6
    [Header("Index")]
    //index numbers for our current skin, hair, mouth, eyes, clothes and armour textures
    public int skinIndex;
    public int mouthIndex, eyesIndex, hairIndex, clothesIndex, armourIndex, helmIndex;
    [Header("Renderer")]
    //renderer for our character mesh so we can reference a material list
    public Renderer character;
    public Renderer helm;
    [Header("Max Index")]
    //max amount of skin, hair, mouth, eyes, clothes and armour textures that our lists are filling with
    public int skinMax;
    public int mouthMax, eyesMax, hairMax, clothesMax, armourMax;

    public string[] materialNames = new string[7] { "Skin", "Mouth", "Eyes", "Hair", "Clothes", "Armour", "Helm" };
    public Vector2 screen;
    #endregion

    #region Start
    //in start we need to set up the following
    private void Start()
    {
        #region for loop to pull textures from file
        //for loop looping from 0 to less than the max amount of skin textures we need
        for (int i = 0; i < skinMax; i++)
        {
            //creating a temp Texture2D that it grabs, using Resources.Load from the Character File looking for Skin_#    
            Texture2D temp = Resources.Load("Character/Skin_" + i) as Texture2D;
            //add our temp texture that we just found to the skin List
            skin.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of textures we need
        for (int i = 0; i < mouthMax; i++)
        {
            //creating a temp Texture2D that it grabs, using Resources.Load from the Character File looking for Type_#
            Texture2D temp = Resources.Load("Character/Mouth_" + i) as Texture2D;
            //add our temp texture that we just found to the  List
            mouth.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of textures we need
        for (int i = 0; i < eyesMax; i++)
        {
            //creating a temp Texture2D that it grabs, using Resources.Load from the Character File looking for Type_#
            Texture2D temp = Resources.Load("Character/Eyes_" + i) as Texture2D;
            //add our temp texture that we just found to the  List
            eyes.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of textures we need
        for (int i = 0; i < hairMax; i++)
        {
            //creating a temp Texture2D that it grabs, using Resources.Load from the Character File looking for Type_#
            Texture2D temp = Resources.Load("Character/Hair_" + i) as Texture2D;
            //add our temp texture that we just found to the  List
            hair.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of textures we need
        for (int i = 0; i < clothesMax; i++)
        {
            //creating a temp Texture2D that it grabs, using Resources.Load from the Character File looking for Type_#
            Texture2D temp = Resources.Load("Character/Clothes_" + i) as Texture2D;
            //add our temp texture that we just found to the  List
            clothes.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of textures we need
        for (int i = 0; i < armourMax; i++)
        {
            //creating a temp Texture2D that it grabs, using Resources.Load from the Character File looking for Type_#
            Texture2D temp = Resources.Load("Character/Armour_" + i) as Texture2D;
            //add our temp texture that we just found to the  List
            armour.Add(temp);
        }
        #endregion
        //connect and find the Renderer thats in the scene to the variable we made for Renderer 
        character = GameObject.Find("Mesh").GetComponent<Renderer>();
        helm = GameObject.Find("cap").GetComponent<Renderer>();
        #region do this after making the function SetTexture
        //SetTexture for all materials to the first texture 0    
        #endregion
    }
    #endregion

    #region SetTexture
    //Create a function that is called SetTexture it should contain a string and int
    //the string is the name of the material we are editing, the int is the direction we are changing 
    void SetTexture(string type, int dir)
    {
        //we need variables that exist only within this function
        //these are ints index numbers, max numbers, material index and Texture2D array of textures and our renderer
        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];
        Renderer curRend = new Renderer();
        #region Switch Material
        //inside a switch statement that is swapped by the string name of our material  
        switch (type)
        {
            #region Skin
            //case skin
            case "Skin":
                //index is the same as our skin index
                index = skinIndex;
                //max is the same as our skin max
                max = skinMax;
                //textures is our skin list .ToArray()
                textures = skin.ToArray();
                //material index element number
                matIndex = 1;
                //current renderer is the mesh renderer that we are getting the materials from
                curRend = character;
                //end case
                break;
            #endregion
            #region Mouth
            //case Mouth
            case "Mouth":
                //index is the same as our Mouth index
                index = mouthIndex;
                //max is the same as our Mouth max
                max = mouthMax;
                //textures is our Mouth list .ToArray()
                textures = mouth.ToArray();
                //material index element number
                matIndex = 2;
                curRend = character;

                //end case
                break;
            #endregion
            #region Eyes
            //case Eyes
            case "Eyes":
                //index is the same as our Eyes index
                index = eyesIndex;
                //max is the same as our Eyes max
                max = eyesMax;
                //textures is our Eyes list .ToArray()
                textures = eyes.ToArray();
                //material index element number
                matIndex = 3;
                curRend = character;
                //end case
                break;
            #endregion
            #region Hair
            case "Hair":
                index = hairIndex;
                //index is the same as our  index
                max = hairMax;
                //max is the same as our  max
                textures = hair.ToArray();
                //textures is our  list .ToArray()
                matIndex = 4;
                curRend = character;
                //material index element number
                break;
            #endregion
            #region Clothes
            case "Clothes":
                index = clothesIndex;
                //index is the same as our  index
                max = clothesMax;
                //max is the same as our max
                textures = clothes.ToArray();
                //textures is our  list .ToArray()
                matIndex = 5;
                curRend = character;
                //material index element number
                break;
            #endregion
            #region Armour
            case "Armour":
                index = armourIndex;
                //index is the same as our  index
                max = armourMax;
                //max is the same as our max
                textures = armour.ToArray();
                //textures is our  list .ToArray()
                matIndex = 6;
                curRend = character;
                //material index element number
                break;
            //break
            case "Helm":
                index = helmIndex;
                //index is the same as our  index
                max = armourMax;
                //max is the same as our max
                textures = armour.ToArray();
                //textures is our  list .ToArray()
                matIndex = 1;
                curRend = helm;
                //material index element number
                break;
                //break
                #endregion
        }
        #endregion
        //outside our switch statement
        #region Assign Direction
        //index plus equals our direction
        index += dir;
        //cap our index to loop back around if is is below 0 or above max take one
        if (index < 0)
        {
            index = max - 1;
        }
        if (index > max - 1)
        {
            index = 0;
        }
        //Material array is equal to our characters material list
        Material[] mat = curRend.materials;
        //our material arrays current material index's main texture is equal to our texture arrays current index
        mat[matIndex].mainTexture = textures[index];
        //our characters materials are equal to the material array
        curRend.materials = mat;
        #endregion
        //create another switch that is goverened by the same string name of our material
        #region Set Material Switch
        switch (type)
        {
            //case skin
            case "Skin":
                //skin index equals our index
                skinIndex = index;
                //break
                break;
            case "Mouth":
                mouthIndex = index;
                break;
            case "Eyes":
                eyesIndex = index;
                break;
            case "Hair":
                hairIndex = index;
                break;
            case "Clothes":
                clothesIndex = index;
                break;
            case "Armour":
                armourIndex = index;
                break;
            case "Helm":
                helmIndex = index;
                break;
        }
        #endregion
    }
    #endregion
    public override void Update()
    {

    }
    private void OnGUI()
    {
        //create the floats scrW and scrH that govern our 16:9 ratio
        screen.x = Screen.width / 16;
        screen.y = Screen.height / 9;
        for (int i = 0; i < materialNames.Length; i++)
        {
            if (GUI.Button(new Rect(0.25f * screen.x, 2.5f * screen.y + (i * 0.5f * screen.y), 0.5f * screen.x, 0.5f * screen.y), "<"))
            {
                SetTexture(materialNames[i], -1);
            }

            GUI.Box(new Rect(0.75f * screen.x, 2.5f * screen.y + (i * 0.5f * screen.y), 1.5f * screen.x, 0.5f * screen.y), materialNames[i]);

            if (GUI.Button(new Rect(2.25f * screen.x, 2.5f * screen.y + (i * 0.5f * screen.y), 0.5f * screen.x, 0.5f * screen.y), ">"))
            {
                SetTexture(materialNames[i], 1);
            }
        }
    }
}
