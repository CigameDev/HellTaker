using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelHomeController : MonoBehaviour
{
    [SerializeField]private Button bnLock;
    [SerializeField]private Button bnUnLock;
    int m_numberLevel = 20;
    int m_currentUnLock = 5;
    void Awake()
    {
         for(int i=1;i<=m_numberLevel;i++)
        {
            if(i<=m_currentUnLock)
            {
                Button temp = Instantiate(bnUnLock, gameObject.transform.GetChild(1).GetChild(0).GetChild(0).transform,true);
                
                temp.transform.GetChild(0).GetComponent<Text>().text = i.ToString();
                temp.gameObject.SetActive(true);
               
            }    
            else
            {
                Button temp = Instantiate(bnLock, gameObject.transform.GetChild(1).GetChild(0).GetChild(0).transform, true);
                temp.transform.GetChild(0).GetComponent<Text>().text = i.ToString();
                temp.gameObject.SetActive(true);
            }    
        }    

    }
}
