using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GMNetworkManager : NetworkBehaviour
{
    [Client]
    public void TellServerToDestroyObject(GameObject obj)
    {
        CmdDestroyObject(obj);
    }

    // Executed only on the server
    [Command]
    private void CmdDestroyObject(GameObject obj)
    {
        // It is very unlikely but due to the network delay
        // possisble that the other player also tries to
        // destroy exactly the same object beofre the server
        // can tell him that this object was already destroyed.
        // So in that case just do nothing.
        if(!obj) return;

        NetworkServer.Destroy(obj);
    }
}
