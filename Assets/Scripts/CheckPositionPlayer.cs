using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPositionPlayer : MonoBehaviour
{
    public static CheckPositionPlayer instance;

    void Awake()
    {
        MakeSingleton();
    }
    public  bool CheckGirl()//Is the next position a girl?
    {
        Vector2 temp = new Vector2(this.transform.position.x, this.transform.position.y);
        Collider2D col1 = Physics2D.OverlapCircle(new Vector2(temp.x + 1f, temp.y), 0.2f);
        if (col1 && col1.gameObject.tag == "Girl") return true;

        Collider2D col2 = Physics2D.OverlapCircle(new Vector2(temp.x - 1f, temp.y), 0.2f);
        if (col2 && col2.gameObject.tag == "Girl") return true;

        Collider2D col3 = Physics2D.OverlapCircle(new Vector2(temp.x, temp.y + 1f), 0.2f);
        if (col3 && col3.gameObject.tag == "Girl") return true;

        Collider2D col4 = Physics2D.OverlapCircle(new Vector2(temp.x, temp.y - 1f), 0.2f);
        if (col4 && col4.gameObject.tag == "Girl") return true;

        return false;
    }
    public void MakeSingleton()
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
}
