using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDong : MonoBehaviour
{
    
    void Start()
    {
        GameManager.instance?.traps.Add(gameObject);
    }

}
