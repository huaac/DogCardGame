using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DrawCards : NetworkBehaviour
{
    public List<Material> numMaterials = new List<Material>();

    public PlayerManager playerManager;

    public void OnClick()
    {
        int cardNumber = Random.Range(0, numMaterials.Count);

        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerManager = networkIdentity.GetComponent<PlayerManager>();
        playerManager.CmdDealCards(cardNumber);

    }


    //old script
    // public PlayerManager playerManager;

    // public void OnClick()
    // {
    //     NetworkIdentity networkIdentity = NetworkClient.connection.identity;
    //     playerManager = networkIdentity.GetComponent<PlayerManager>();
    //     playerManager.CmdDealCards();

    // }

}
