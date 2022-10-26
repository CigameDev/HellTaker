using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private Button[] LevelButtons;
    [SerializeField] private Sprite spriteUnlock;
    [SerializeField] private Sprite spriteLock;
    //private int m_LevelCurrent;
    void Awake()
    {
        MakeSingleton();
        //int ReachedLevel = PlayerPrefs.GetInt("ReachedLevel", 1);
        PlayerPrefs.SetInt("ReachedLevel",1);
        int ReachedLevel = PlayerPrefs.GetInt("ReachedLevel");
        if (PlayerPrefs.GetInt("ReachedLevel") >= 2)
        {
            ReachedLevel = PlayerPrefs.GetInt("ReachedLevel");
        }
        LevelButtons = new Button[transform.childCount];//mang cac button ,childCount la so luong button tuc la so con cua tap lenh gan vao
        for (int i = 0; i < LevelButtons.Length; i++)
        {
            LevelButtons[i] = transform.GetChild(i).GetComponent<Button>();
            LevelButtons[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
            LevelButtons[i].image.sprite = spriteUnlock;
            if (i + 1 > ReachedLevel)
            {
                LevelButtons[i].image.sprite = spriteLock;
                LevelButtons[i].interactable = false;
            }
        }

    }

    public void  Unlock(int count)//unlock level count
    {
        LevelButtons[count].interactable = true;
        LevelButtons[count].image.sprite = spriteUnlock;
    }

   
    public void Loadlevel(int Level)
    {
        PlayerPrefs.GetInt("Level", Level);
    }

    public void OnClickButton(Button btn)
    {
        string sText = btn.transform.GetChild(0).GetComponent<Text>().text;
        int iText = int.Parse(sText);
        PlayerPrefs.SetInt("Level_Current",iText);
        Debug.Log("Level dang choi "+PlayerPrefs.GetInt("Level_Current"));
        Debug.Log("Level da unlock "+PlayerPrefs.GetInt("ReachedLevel"));
        
        if(UiManager.instance.m_objLevel!=null)Destroy(UiManager.instance.m_objLevel);
        UiManager.instance.m_objLevel = Instantiate(Resources.Load<GameObject>("Levels/level " + iText));
        gameObject.transform.parent.gameObject.SetActive(false);//an danh sach cac level di
        GameManager.instance.IsReady = true;
    }

    void Update()
    {
        
    }

    void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
