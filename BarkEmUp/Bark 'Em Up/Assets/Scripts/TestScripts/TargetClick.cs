using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TargetClick : NetworkBehaviour
{
    public PlayManager playerManager;

    public void OnTargetClick()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerManager = networkIdentity.GetComponent<PlayManager>();

        if(isOwned)
        {
            playerManager.CmdTargetSelfCard();
        }
        else // if object targeted is not owned by the client
        {
            playerManager.CmdTargetOtherCard(gameObject);
        }
    }
}
