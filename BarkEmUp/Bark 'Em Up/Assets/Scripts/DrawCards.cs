using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DrawCards : NetworkBehaviour
{
    public PlayerManagerr playerManager;

    // public GameObject card1;
    // public GameObject playerArea;


    public void OnClick()
    {
        //look for a network identity that is governed by the network client in this game scene
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerManager = networkIdentity.GetComponent<PlayerManagerr>();

        // // if(!NetworkClient.ready){playerManager.CmdDealCards();}
        // // else{Debug.Log("NotReady");}
        playerManager.CmdDealCards();

        // for (int i=0; i<5; i++)
        // {
        //     GameObject card = Instantiate(card1,new Vector3(0,0,-18), Quaternion.identity);

        //     // GameObject card = Instantiate(cards[Random.Range(0,cards.Count)],new Vector3(0,0,-18), Quaternion.identity);
        //     // NetworkServer.Spawn(card1,connectionToClient); //makes the client own authority over the game object
        //     card.transform.arent(playerArea.transform,false);
        // }
    }

}
