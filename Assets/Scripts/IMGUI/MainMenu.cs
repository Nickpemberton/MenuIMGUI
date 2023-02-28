using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{

    public Vector2 screenScale; // Hold x and y floats.
    public bool toggleGrid; //Allows us to toggle grid
    public bool toggleMenu, toggleOptions;
    public AudioSource audioSource;
    [Space(10), Header("Slider Values"), Range(0, 1)]
    public float brightness;
    public Light dirLight;

  //  public PostProcessProfile 

    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
        dirLight = GameObject.FindGameObjectWithTag("Light").GetComponent<Light>();
    }


    #region OnGUI - Renderer for IMGUI
    // OnGui Render IMGUI code and events, elements will not render outside OnGUI
    void OnGUI()
    {
        //Create a 1:1 ratio grid which resizes based on pixels for only 16:9
        screenScale.x = Screen.width / 16;
        screenScale.y = Screen.height / 9;
        //Grid to display 16:9 aspect ratio

        Grid();
        Menu();
        Options();
    }
    #endregion


    #region Menu - Creates the Menu
    void Menu()
    {
        if (toggleMenu)
        {
            //Panel
            GUI.Box(new Rect(0, 0, screenScale.x * 16, screenScale.y * 9), "");

            //Title
            GUI.Box(new Rect(6 * screenScale.x, screenScale.y, screenScale.x * 4, screenScale.y), "Testing Game");
            //Play
            if(GUI.Button(new Rect(7 * screenScale.x, screenScale.y * 2, screenScale.x * 2, screenScale.y), "Play"))
            {
                SceneManager.LoadScene("GameScene");
            }
            //Options
            if(GUI.Button(new Rect(7 * screenScale.x, screenScale.y * 4, screenScale.x * 2, screenScale.y), "Options"))
            {
                toggleOptions = true;
                toggleMenu = false;
                
            }
            //Exit Button
            if(GUI.Button(new Rect(7 * screenScale.x, screenScale.y * 6, screenScale.x * 2, screenScale.y), "Exit"))
            {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #endif
                Application.Quit();
            }
            
        }

    }
    #endregion


    #region Options - Creates the options menu
    void Options()
    {
        if (toggleOptions)
        {
            //panel
            GUI.Box(new Rect(0, 0, screenScale.x * 16, screenScale.y * 9), "");

            //Audio - Sliders
            GUI.Label(new Rect(screenScale.x, 0, screenScale.x, screenScale.y), "Audio");
            GUI.Box(new Rect(0, 0, screenScale.x * 3, screenScale.y * 2), "");
            audioSource.volume = GUI.HorizontalSlider(new Rect(screenScale.x / 2, screenScale.y, screenScale.x *2 , screenScale.y /2), audioSource.volume, 0f, 1f);

            //Brightness - Sliders
            GUI.Label(new Rect(screenScale.x * 0.75f, screenScale.y * 2, screenScale.x * 1.5f, screenScale.y), "Brightness");
            GUI.Box(new Rect(0, screenScale.y * 2, screenScale.x * 3, screenScale.y * 2), "");
            brightness = GUI.HorizontalSlider(new Rect(screenScale.x / 2, screenScale.y * 3, screenScale.x * 2, screenScale.y / 2), brightness, 0f, 1f);
            dirLight.intensity = brightness;
            //Quality - Dropdown
            GUI.Label(new Rect(screenScale.x, screenScale.y * 4, screenScale.x, screenScale.y), "Quality");
            GUI.Box(new Rect(0, screenScale.y * 4, screenScale.x * 3, screenScale.y * 2), "");

            //Resolutions - Dropdown
            GUI.Label(new Rect(screenScale.x * 0.75f, screenScale.y * 6, screenScale.x * 1.5f, screenScale.y), "Resolution");
            GUI.Box(new Rect(0, screenScale.y * 6, screenScale.x * 3, screenScale.y * 2), "");
            //Fullscreen Toggle - Bool Toggle
            GUI.Label(new Rect(0, screenScale.y * 8, screenScale.x * 1.5f, screenScale.y / 2), "Fullscreen");
            GUI.Box(new Rect(0, screenScale.y * 8, screenScale.x * 3, screenScale.y / 2), "");
            //Screen.fullScreen = GUI.Toggle(new Rect(screenScale.x * 1.5f, screenScale.y * 8, screenScale.x / 4, screenScale.y / 4), Screen.fullScreen, "Toggle");
            //Keybinds - big
            


            //Back
            if (GUI.Button(new Rect(0, screenScale.y * 8.5f, screenScale.x * 3, screenScale.y / 2), "Back"))
            {
                toggleMenu = true;
                toggleOptions = false;
            }


        }
    }
    #endregion

    #region Grid - Creates a grid
    void Grid()
    {
        //if the toggleGrid is set to true
        if (toggleGrid)
        {
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    GUI.Box(new Rect(x * screenScale.x, y * screenScale.y, screenScale.x, screenScale.y), "");
                    GUI.Label(new Rect(x * screenScale.x, y * screenScale.y, screenScale.x, screenScale.y), x + ":" + y);
                }
            }
        }
    }
    #endregion
}
