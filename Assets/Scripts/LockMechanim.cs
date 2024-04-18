using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMechanim : MonoBehaviour
{
    public DoorMechanim[] doorsToOpen;
    public KeyColor keyColor;
    bool playerInRange;
    bool alreadyOpen;
    Animator animator;

    public AudioClip sfx;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

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
                else
                {
                    Open();
                    return;
                }

                SoundManager.Instance.PlaySFX(sfx);
                alreadyOpen = true;
                switch (keyColor)
                {
                    case KeyColor.RedKey:
                        animator.SetTrigger("openRed");
                        break;
                    case KeyColor.GreenKey:
                        animator.SetTrigger("openGreen");
                        break;
                    case KeyColor.GoldKey:
                        animator.SetTrigger("openGold");
                        break;
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

    public void Open()
    {
        foreach (var d in doorsToOpen)
        {
            d.open = !d.open;
        }
    }
}
