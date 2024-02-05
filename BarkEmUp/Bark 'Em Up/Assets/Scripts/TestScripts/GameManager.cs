using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManager : NetworkBehaviour
{
    public GameObject card;
    // public Material material;

    public static GameManager instance;

    public GameState state;
    
    // public static event Action<GameState> onGameStateChanged;

    void Awake()
    {
        instance = this;
        Debug.Log("game manager awakened");
    }

    void Start()
    {
        // UpdateGameState(GameState.DrawPhase);
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch(newState)
        {
            case GameState.DrawPhase:
                HandleDrawPhase();
                break;
            case GameState.DiscardPhase:
                break;
            case GameState.BettingPhase:
                break;
            case GameState.RevealPhase:
                break;
            // default:
                // throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        // onGameStateChanged?.Invoke(newState);
    }

    private void HandleDrawPhase()
    {
        // lets each player draw 2 cards
    }

    public enum GameState{
        DrawPhase,
        DiscardPhase,
        BettingPhase,
        RevealPhase
    }


    //Old script
    // public int turnsPlayed = 0;

    // public void UpdateTurnsPlayed()
    // {
    //     turnsPlayed++;
    // }
}
