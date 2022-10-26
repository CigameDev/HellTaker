using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int energy;
    private CheckPositionPlayer checkPositionPlayer;
    public List<GameObject> traps;
    private bool _IsReady;
    public bool IsReady { get => _IsReady; set => _IsReady = value; }

    private void Awake()
    {
        MakeSingleton();
        traps = new List<GameObject>();
        checkPositionPlayer = FindObjectOfType<CheckPositionPlayer>();

    }
    void Start()
    {
        _IsReady = true;
        //checkPositionPlayer = FindObjectOfType<CheckPositionPlayer>();
        Debug.Log(traps.Count);
    }

    
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ContinuePlay();
        }
        ActiveTrap();
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
    }
    private void ContinuePlay()
    {
        Time.timeScale = 1f;
    }

    public void Replay()
    {
        SceneManager.LoadScene("GamePlay");
    }
    void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ReduceEnergy(int value)
    {
        energy-=value;
        this.LoseGame();
    }
    
    public void WinGame()
    {
        if (checkPositionPlayer.CheckGirl())
        {
            Debug.Log("Win roi");
            if (PlayerPrefs.GetInt("ReachedLevel")==PlayerPrefs.GetInt("Level_Current"))//da thang man cuoi cung thi mo khoa man ke tiep
            {
                Debug.Log("Bang nhau");
                PlayerPrefs.SetInt("ReachedLevel",PlayerPrefs.GetInt("Level_Current"));
               LevelManager.instance.Unlock(PlayerPrefs.GetInt("ReachedLevel"));
            }
            UiManager.instance.ShowWinGame();
            //Player.instance = null;
            _IsReady = false;
        }
    }

    private void LoseGame()
    {
        if(energy <=0 && !checkPositionPlayer.CheckGirl() )//khong dung canh dua con gai
        {
            Debug.Log("Lose Game");
            UiManager.instance.ShowGameOver();
            _IsReady =false;
        }    
    }    
    private void ActiveTrap()
    {
        if (traps.Count == 0) return;
        if (Player.instance.isAction)
        {
            for (int i = 0; i < traps.Count; i++)
            {
                bool tempStatus = traps[i].transform.GetChild(0).gameObject.activeInHierarchy;//lay trang thai hien tai
                traps[i].transform.GetChild(0).gameObject.SetActive(!tempStatus);//true trap
                traps[i].transform.GetChild(1).gameObject.SetActive(tempStatus);//rong
            }
            
            Player.instance.isAction = false;
        }
    }
}


