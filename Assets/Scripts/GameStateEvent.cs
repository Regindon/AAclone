using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateEvent : MonoBehaviour
{
    // Event triggered when the game state changes
    public event Action<GameState> OnGameStateChange;

    private GameState _currentState;

    public GameState CurrentState
    {
        get { return _currentState; }
        set
        {
            if (_currentState != value)
            {
                _currentState = value;
                OnGameStateChange?.Invoke(_currentState);
            }
        }
    }

    // Example method to change the game state
    public void ChangeGameState(GameState newState)
    {
        CurrentState = newState;
    }
}
