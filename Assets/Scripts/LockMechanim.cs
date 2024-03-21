using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMechanim : MonoBehaviour
{
    public DoorMechanim[] doorsToOpen;
    public KeyColor keyColor;
    bool playerInRange;
    bool alreadyOpen;

    private void Update()
    {
        if(playerInRange)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (!GameManager.Instance.HasKey(keyColor) && !alreadyOpen)
                    return;

                if(!alreadyOpen)
                    GameManager.Instance.UseKey(keyColor);
                alreadyOpen = true;

                foreach (var d in doorsToOpen)
                {
                    d.open = !d.open;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
