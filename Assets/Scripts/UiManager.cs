using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    [SerializeField] private GameObject m_panelWinGame;
    [SerializeField] private GameObject m_panelLoseGame;
    [SerializeField] private GameObject m_panelHome;
    [SerializeField] private GameObject m_panelLevel;
   
    private int m_currentLevel;
    public  GameObject m_objLevel, m_nextLevel;
    private void Awake()
    {
        MakeSingleton();

        m_currentLevel = PlayerPrefs.GetInt("current_level", 1);
       
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void ShowGameOver()
    {
        m_panelLoseGame.SetActive(true);
    }
    public void ShowWinGame()
    {
        m_panelWinGame.SetActive(true);
    }    
    public void ShowHome()
    {
        m_panelHome.SetActive(true);
    }
    public void ShowLevel()
    {
        m_panelWinGame.SetActive(false);
        m_panelLevel.SetActive(true);
    }
    void MakeSingleton()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //private void OnClickButtonUnLock()
    //{
    //    string a = m_buttonUnLock.transform.GetChild(0).GetComponent<Text>().text;
    //    int n = int.Parse(a);
    //    m_objLevel = Instantiate(Resources.Load<GameObject>("Levels/level " + n));
    //    m_panelHome.SetActive(false);
    //}

    //public void OnclickLevel(Button btn)//cach lay ten cua 1 button khi nhan button do
    //{
    //    string a = btn.transform.GetChild(0).GetComponent<Text>().text;
    //    int n = int.Parse(a);
    //    m_objLevel = Instantiate(Resources.Load<GameObject>("Levels/level " + n));
    //    m_panelHome.SetActive(false);
    //}


}
