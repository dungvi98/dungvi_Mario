using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    public static System.Action GameStateChanged;
    public static GameState CurrentState
    {
        get => instance._currentState;
        set
        {
            if(instance._currentState != value)
            {
                instance._currentState = value;
                if(GameStateChanged != null)
                    GameStateChanged.Invoke();
            }
        }
    }

    [SerializeField] GameState _currentState = GameState.None;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CurrentState = GameState.Play;
    }
}


public enum GameState
{
    None,
    Idle, 
    Play,
    GameOver
}
