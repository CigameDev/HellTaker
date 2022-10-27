using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLevelCtrl : MonoBehaviour
{
    public Player MainPlayer;
    public int Step;


    public virtual void OnMoveStep()
    {
        Step--;

        if (Step <= 0)
        {
            Debug.Log("Lose Game");
        }
    }

    public virtual void OnWinGame()
    {

    }
}
