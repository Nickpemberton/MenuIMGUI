using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState gameState = GameState.Alive;
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }
    private void Awake()
    {
        if (Instance != null && Instance != this) // If instance is already found, and it is not this script "THERE CAN BE ONLY ONE"
        {
            Destroy(this); // Destroy this
        }
        else
        {
            Instance = this; //set the instance to this instance
        }
    }
}

public enum GameState
{
    Alive,
    Dead,
    Pause,
    MenuOpenMISC
}
