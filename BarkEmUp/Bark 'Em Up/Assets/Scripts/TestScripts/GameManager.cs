using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManager : NetworkBehaviour
{
    public GameObject card;
    public Material material;

    void Start()
    {
        // material = card.GetComponent
    }


    //Old script
    // public int turnsPlayed = 0;

    // public void UpdateTurnsPlayed()
    // {
    //     turnsPlayed++;
    // }
}
