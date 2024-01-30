using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManager : NetworkBehaviour
{
    public GameObject card;
    public Material material;

    public static GameManager instance;

    public GameState state;
    
    // public static event Action<GameState> onGameStateChanged;

    void Awake()
    {
        instance = this;
        Debug.Log("game manager awakened");
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch(newState)
        {

        }
    }

    public enum GameState{

    }


    //Old script
    // public int turnsPlayed = 0;

    // public void UpdateTurnsPlayed()
    // {
    //     turnsPlayed++;
    // }
}
