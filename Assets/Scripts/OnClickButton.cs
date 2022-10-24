using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickButton : MonoBehaviour//click vao button da unlock
{
    Button mButton;
    void Start()
    {
        mButton = GetComponent<Button>();
        mButton?.onClick.AddListener(this.Click);
    }

    private void Click()
    {
        string sText = mButton.transform.GetChild(0).GetComponent<Text>().text;
        int iText = int.Parse(sText);
        Debug.Log("Ban da nhan nut thu  :" + sText);
        UiManager.instance.m_objLevel= Instantiate(Resources.Load<GameObject>("Levels/level " + iText));
        mButton.transform.parent.parent.parent.parent.gameObject.SetActive(false);
    }
}
