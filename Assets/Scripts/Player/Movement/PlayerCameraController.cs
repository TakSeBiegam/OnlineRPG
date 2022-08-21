using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Mirror;

namespace Testing.Inputs
{
    public class PlayerCameraController : NetworkBehaviour
    {
        [Header("Camera")]
        // [SerializeField] private Transform playerTransform = null;
        [SerializeField] private CinemachineFreeLook freeLookCamera = null;

        void Start()
        {
            if (isLocalPlayer)
            {
                freeLookCamera = CinemachineFreeLook.FindObjectOfType<CinemachineFreeLook>();
                freeLookCamera.Follow = this.gameObject.transform;
                freeLookCamera.LookAt = this.gameObject.transform;
            }
        }
    }
}
