using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class IncrementClick : NetworkBehaviour
{
    public PlayManager playerManager;

    [SyncVar]
    public int NumberOfClicks = 0;

    public void IncrementClicks()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        playerManager = networkIdentity.GetComponent<PlayManager>();
        playerManager.CmdIncrementClick(gameObject);
    }
}
