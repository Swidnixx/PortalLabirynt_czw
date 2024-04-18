using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Singleton
    public static SoundManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
