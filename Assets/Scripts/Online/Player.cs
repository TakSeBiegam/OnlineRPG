using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : NetworkBehaviour
{
   void Update()
   {
        if(isLocalPlayer && Input.GetKeyDown(KeyCode.X))
        {
          Debug.Log("Sending Hola to Server");
          Hola();
        }
   }

[Command]
   void Hola()
   {
     Debug.Log("Recived Hola from client");
   }
}
