using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple GMs in the Scene");

        Instance = this;
    }

    //Game Time
    public int time = 60;
    bool paused;

    //Pickups
    int diamonds;
    int redKeys, greenKeys, goldKeys;

    private void Start()
    {
        InvokeRepeating(nameof(Stopper), 3, 1);
    }
    private void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if (paused)
                Resume();
            else
                Pause();

            paused = !paused;
        }
    }

    void Resume()
    {
        Time.timeScale = 1;
    }
    void Pause()
    {
        Time.timeScale = 0;
    }
    void Stopper()
    {
        time--;
        if(time <= 0)
        {
            //Game over
            CancelInvoke();
        }
    }

    public void PickDiamond()
    {
        diamonds++;
    }
    public void AddKey(KeyColor color)
    {
        switch (color)
        {
            case KeyColor.RedKey:
                redKeys++;
                break;
            case KeyColor.GreenKey:
                greenKeys++;
                break;
            case KeyColor.GoldKey:
                goldKeys++;
                break;
        }
    }
    public void AddTime(int time)
    {
        this.time += time;
        if (this.time <= 0)
            this.time = 1;
    }
    public void FreezeTime(int freezeTime)
    {
        CancelInvoke(nameof(Stopper));
        InvokeRepeating(nameof(Stopper), freezeTime, 1);
    }
}
