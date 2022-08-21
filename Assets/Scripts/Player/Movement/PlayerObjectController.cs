using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Cinemachine;

public class PlayerObjectController : NetworkBehaviour
{
    Transform cameraPos;
    void Start()
    {
        if (isLocalPlayer)
        {
            cameraPos = Camera.main.transform;
        }
    }
    [ClientCallback]
    void HandleMovement()
    {
        if (isLocalPlayer)
        {
            float playerVerticalInput = Input.GetAxis("Vertical");
            float playerHorizontalInput = Input.GetAxis("Horizontal");
            // Get Camera-Normalized Directional Vectors
            Vector3 forward = Camera.main.transform.forward;
            Vector3 right = Camera.main.transform.right;
            forward.y = 0;
            right.y = 0;
            forward = forward.normalized;
            right = right.normalized;
            this.transform.Translate((playerVerticalInput * forward +
            playerHorizontalInput * right) * Time.deltaTime * 10f, Space.World);
            this.transform.rotation = Quaternion.Euler(0, cameraPos.eulerAngles.y, 0);
        }
    }
    [Client]
    void FixedUpdate()
    {
        HandleMovement();
    }

    // [Command]
    // void CmdSendTransformToServer(Vector3 localPosition, Quaternion localRotation, GameObject player)
    // {
    //     player.transform.position = localPosition;
    //     player.transform.rotation = localRotation;
    // }
}