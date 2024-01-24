using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour
{
    public GameObject card1;

    public GameObject playerArea;
    public GameObject enemyArea;

    public override void OnStartClient()
    {
        base.OnStartClient();

        playerArea = GameObject.Find("PlayerArea");
        enemyArea = GameObject.Find("EnemyArea");

        // NetworkServer.SetClientReady(NetworkClient);
    }

    [Server]
    public override void OnStartServer()
    {
        base.OnStartServer();

        // cards.Add(card1);
        // Debug.Log("Logging: " + cards[0]);
    }

    [Command]
    public void CmdDealCards() //when client makes request for server to do something; must always start w Cmd
    {
        for (int i=0; i<2; i++)
        {
            GameObject card = Instantiate(card1,new Vector3(0,0,0), Quaternion.identity);

            // GameObject card = Instantiate(cards[Random.Range(0,cards.Count)],new Vector3(0,0,-18), Quaternion.identity);
            NetworkServer.Spawn(card,connectionToClient); //makes the client own authority over the game object
            RpcShowCard(card,"Dealt");
        }
    }

    [ClientRpc]
    void RpcShowCard(GameObject card, string type)
    {
        if(type == "Dealt")
        {
            if(isOwned)
            {
                card.transform.SetParent(playerArea.transform,false);
            }
            else
            {
                card.transform.SetParent(enemyArea.transform,false);
                // card.GetComponent<CardFlipper>().Flip();
            }
        }
        // else if (type == "Played")
        // {
        //     card.transform.SetParent(dropArea.transform,false);
        //     if(!isOwned)
        //     {
        //         card.GetComponent<CardFlipper>().Flip();
        //     }
        // }
    }
}
