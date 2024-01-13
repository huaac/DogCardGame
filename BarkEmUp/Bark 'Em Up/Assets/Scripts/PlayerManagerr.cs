using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManagerr : NetworkBehaviour
{
    public GameObject card1;

    public GameObject playerArea;
    public GameObject enemyArea;
    public GameObject dropArea;

    // public int test = 1;

    List<GameObject> cards = new List<GameObject>();

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
            GameObject card = Instantiate(card1,new Vector3(0,0,-18), Quaternion.identity);

            // GameObject card = Instantiate(cards[Random.Range(0,cards.Count)],new Vector3(0,0,-18), Quaternion.identity);
            NetworkServer.Spawn(card,connectionToClient); //makes the client own authority over the game object
            card.transform.SetParent(playerArea.transform,false);
        }
    }

}
