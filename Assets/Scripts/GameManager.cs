using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Singleton
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
    bool freezed;
    bool over;

    //Pickups
    int diamonds;
    int redKeys, greenKeys, goldKeys;
    public int Diamonds => diamonds;
    public int RedKeys => redKeys;
    public int GreenKeys => greenKeys;
    public int GoldKeys => goldKeys;

    //Sounds
    public AudioClip freezeOff;

    //UI
    public GameObject pausePanel, winPanel, loosePanel;

    private void Start()
    {
        InvokeRepeating(nameof(Stopper), 3, 1);
        pausePanel.SetActive(false);
        winPanel.SetActive(false);
        loosePanel.SetActive(false);
    }
    private void Update()
    {
        if(over || paused)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Time.timeScale = 1;
            }

            if(!paused)
                return;
        }

        if(Input.GetButtonDown("Cancel"))
        {
            if (paused)
                Resume();
            else
                Pause();

            paused = !paused;
        }
    }

    //game time
    void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    void Stopper()
    {
        DisplayUI.Instance.ActivateFreeze(false);
        time--;
        if(time <= 0)
        {
            //Game over
            GameOver();
        }
    }
    public void GameWin()
    {
        CancelInvoke(nameof(Stopper));
        Time.timeScale = 0;
        over = true;
        winPanel.SetActive(true);
    }
    public void GameOver()
    {
        CancelInvoke(nameof(Stopper));
        Time.timeScale = 0;
        over = true;
        loosePanel.SetActive(true);
    }

    //Pickups
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
        if(freezed)
        {
            CancelInvoke(nameof(FreezeOff));
        }
        freezed = true;
        CancelInvoke(nameof(Stopper));
        InvokeRepeating(nameof(Stopper), freezeTime, 1);
        Invoke(nameof(FreezeOff), freezeTime);
        DisplayUI.Instance.ActivateFreeze(true);
    }
    void FreezeOff()
    {
        freezed = false;
        SoundManager.Instance.PlaySFX(freezeOff);
    }

    //keys and doors
    public bool HasKey(KeyColor keyColor)
    {
        switch (keyColor)
        {
            case KeyColor.RedKey:
                return redKeys > 0;
            case KeyColor.GreenKey:
                return greenKeys > 0;
            case KeyColor.GoldKey:
                return goldKeys > 0;
        }
        return false;
    }
    public void UseKey(KeyColor keyColor)
    {
        switch (keyColor)
        {
            case KeyColor.RedKey:
                redKeys--;
                break;
            case KeyColor.GreenKey:
                greenKeys--;
                break;
            case KeyColor.GoldKey:
                goldKeys--;
                break;
        }
    }

}
