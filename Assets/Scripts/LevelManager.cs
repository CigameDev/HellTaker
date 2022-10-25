using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private Button[] LevelButtons;
    [SerializeField] private Image imageUnlock;
    [SerializeField] private Image imageLock;

    void Awake()
    {
        int ReachedLevel = PlayerPrefs.GetInt("ReachedLevel", 1);
        if (PlayerPrefs.GetInt("ReachedLevel") >= 2)
        {
            ReachedLevel = PlayerPrefs.GetInt("ReachedLevel");
        }
        LevelButtons = new Button[transform.childCount];//mang cac button ,childCount la so luong button tuc la so con cua tap lenh gan vao
        for (int i = 0; i < LevelButtons.Length; i++)
        {
            LevelButtons[i] = transform.GetChild(i).GetComponent<Button>();
            LevelButtons[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
            if (i + 1 > ReachedLevel)
            {
                LevelButtons[i].interactable = false;
            }
        }

    }

    public void Loadlevel(int Level)
    {
        PlayerPrefs.GetInt("Level", Level);
    }
    

    
    void Update()
    {
        
    }
}
