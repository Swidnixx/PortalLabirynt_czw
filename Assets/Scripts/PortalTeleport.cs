using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    [HideInInspector] public Transform receiver;
    Transform player;

    private void FixedUpdate()
    {
        if(player)
        {
            Vector3 portalForward = transform.up;
            Vector3 portalToPlayer = player.position - transform.position;
            float dot = Vector3.Dot(portalToPlayer, portalForward);
            if(dot < 0)
            {
                //teleporting
                portalToPlayer = transform.parent.InverseTransformDirection(portalToPlayer);
                portalToPlayer = receiver.parent.TransformDirection(portalToPlayer);

                player.position = receiver.position + portalToPlayer;

                Vector3 playerForward = player.forward;
                playerForward = transform.parent.InverseTransformDirection(playerForward);
                playerForward = receiver.parent.TransformDirection(playerForward);

                player.forward = playerForward;

                player = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }
}
