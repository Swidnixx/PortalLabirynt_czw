using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUI : MonoBehaviour
{
    //Singleton
    public static DisplayUI Instance;
    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Multiple UI Displays in the Scene");

        Instance = this;
    }

    public Text timeText, diamondsText, redKeysText, greenKeysText, goldKeysText;
    public Image freezeImg;

    private void Update()
    {
        timeText.text = GameManager.Instance.time.ToString();
        diamondsText.text = GameManager.Instance.Diamonds.ToString();
        redKeysText.text = GameManager.Instance.RedKeys.ToString();
        greenKeysText.text = GameManager.Instance.GreenKeys.ToString();
        goldKeysText.text = GameManager.Instance.GoldKeys.ToString();
    }

    public void ActivateFreeze(bool active)
    {
        freezeImg.enabled = active;
    }
}
