using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayManager : NetworkBehaviour
{

    public GameObject card1;
    List<GameObject> cards = new List<GameObject>();

    public GameObject playerArea;
    public GameObject enemyArea;
    public GameObject dropArea;

    public override void OnStartClient()
    {
        base.OnStartClient();

        // NetworkServer.SetClientReady(NetworkClient);

        playerArea = GameObject.Find("PlayerArea");
        enemyArea = GameObject.Find("EnemyArea");
        dropArea = GameObject.Find("DropArea");
    }

    [Server]
    public override void OnStartServer()
    {
        base.OnStartServer();

        cards.Add(card1);
        Debug.Log("Logging: " + cards[0]);
    }

    [Command]
    public void CmdDealCards() //when client makes request for server to do something; must always start w Cmd
    {
        for (int i=0; i<5; i++)
        {
            GameObject card = Instantiate(cards[Random.Range(0,cards.Count)],new Vector3(0,0,-18), Quaternion.identity);

            // GameObject card = Instantiate(cards[Random.Range(0,cards.Count)],new Vector3(0,0,-18), Quaternion.identity);
            NetworkServer.Spawn(card,connectionToClient); //makes the client own authority over the game object
            RpcShowCard(card,"Dealt");
        }
    }

    public void PlayCard(GameObject card)
    {
        CmdPlayCard(card);
    }

    [Command]
    void CmdPlayCard(GameObject card)
    {
        RpcShowCard(card, "Played");

        if(isServer)
        {
            // UpdateTurnsPlayed();
        }
    }

    // [Server]
    // void UpdateTurnsPlayed()
    // {
    //     GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    //     gm.UpdateTurnsPlayed();
    //     RpcLogToClients("Turns Played " + gm.turnsPlayed);
    // }

    [ClientRpc]
    void RpcLogToClients(string message)
    {
        Debug.Log(message);
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
                card.GetComponent<CardFlipper>().Flip();
            }
        }
        else if (type == "Played")
        {
            card.transform.SetParent(dropArea.transform,false);
            if(!isOwned)
            {
                card.GetComponent<CardFlipper>().Flip();
            }
        }
    }

    [Command]
    public void CmdTargetSelfCard()
    {
        TargetSelfCard();
    }

    [Command]
    public void CmdTargetOtherCard(GameObject target)
    {
        NetworkIdentity opponentIdentity = target.GetComponent<NetworkIdentity>();
        TargetOtherCard(opponentIdentity.connectionToClient);
    }

    [TargetRpc]
    void TargetSelfCard()
    {
        Debug.Log("Targeted Self");
    }

    [TargetRpc]
    void TargetOtherCard(NetworkConnection target) // this get printed in the other clients logs
    {
        Debug.Log("Targeted Other");
    }

    [Command]
    public void CmdIncrementClick(GameObject card)
    {
        RpcIncrementClick(card);
    }

    [ClientRpc]
    void RpcIncrementClick(GameObject card)
    {
        card.GetComponent<IncrementClick>().NumberOfClicks++;
        Debug.Log("Clicked: " + card.GetComponent<IncrementClick>().NumberOfClicks);
    }
}
