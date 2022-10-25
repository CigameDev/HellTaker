using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void nextlevel()
    {
        PlayerPrefs.SetInt("ReachedLevel",PlayerPrefs.GetInt("ReachedLevel")+1);
    }
}
