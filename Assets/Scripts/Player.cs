using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public static Player instance;
    public bool isAction;
    bool m_Unlock=false;

    private void Awake()
    {
        MakeSingleton();
        isAction = false;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
        if (Time.timeScale > 0 && GameManager.instance.IsReady )
        {
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveRight();
                KickRight();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveLeft();
                KickLeft();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                MoveUp();
                KickUp();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                MoveDown();
                KickDown();
            }
        }
        
    }
    
    DoubleCollider ColliderRight(Transform pos)
    {
        DoubleCollider collider = new DoubleCollider();
        Vector2 temp = new Vector2(pos.position.x + 1f, pos.position.y);
        Vector2 temp2 = new Vector2(pos.position.x + 2f, pos.position.y);
        collider.col1 = Physics2D.OverlapCircle(temp, 0.2f);
        collider.col2 = Physics2D.OverlapCircle(temp2, 0.2f);
        return collider;
    }
    DoubleCollider ColliderLeft(Transform pos)
    {
        DoubleCollider collider = new DoubleCollider();
        Vector2 temp = new Vector2(pos.position.x - 1f, pos.position.y);
        Vector2 temp2 = new Vector2(pos.position.x - 2f, pos.position.y);
        collider.col1 = Physics2D.OverlapCircle(temp, 0.2f);
        collider.col2 = Physics2D.OverlapCircle(temp2, 0.2f);
        return collider;
    }
    DoubleCollider ColliderUp(Transform pos)
    {
        DoubleCollider collider = new DoubleCollider();
        Vector2 temp = new Vector2(pos.position.x , pos.position.y +1f);
        Vector2 temp2 = new Vector2(pos.position.x , pos.position.y +2f);
        collider.col1 = Physics2D.OverlapCircle(temp, 0.2f);
        collider.col2 = Physics2D.OverlapCircle(temp2, 0.2f);
        return collider;
    }
    DoubleCollider ColliderDown(Transform pos)
    {
        DoubleCollider collider = new DoubleCollider();
        Vector2 temp = new Vector2(pos.position.x, pos.position.y - 1f);
        Vector2 temp2 = new Vector2(pos.position.x, pos.position.y - 2f);
        collider.col1 = Physics2D.OverlapCircle(temp, 0.2f);
        collider.col2 = Physics2D.OverlapCircle(temp2, 0.2f);
        return collider;
    }
    

   
     void MoveRight()
    {
        DoubleCollider col = ColliderRight(this.transform);
        
        if(col.col1==null|| col.col1.gameObject.tag == "TrapTinh"|| col.col1.gameObject.tag == "Trap"
            || col.col1.gameObject.tag == "Rong"|| col.col1.gameObject.tag == "Key"||(col.col1.gameObject.tag == "Lock"&&m_Unlock))
        {
            isAction=true;
            this.transform.DOMoveX(this.transform.position.x + 1f, 0.2f).OnComplete(() =>
            {
                GameManager.instance.ReduceEnergy(1);
                GameManager.instance.WinGame();
            }
           );
            if (col.col1)
            {
                if (col.col1.gameObject.tag == "Key")
                {
                    m_Unlock = true;
                    Destroy(col.col1.gameObject);
                }
                else if (col.col1.gameObject.tag == "Lock" && m_Unlock)
                {
                    Destroy(col.col1.gameObject);
                }
                else if (col.col1.gameObject.tag == "Trap" || col.col1.gameObject.tag == "Rong")
                {
                    GameManager.instance.ReduceEnergy(1);
                }
            }
        }    
    }

    void MoveLeft()
    {
        DoubleCollider col = ColliderLeft(this.transform);
        if (col.col1 == null || col.col1.gameObject.tag == "TrapTinh" || col.col1.gameObject.tag == "Trap" 
            || col.col1.gameObject.tag == "Rong" || col.col1.gameObject.tag == "Key" || (col.col1.gameObject.tag == "Lock" && m_Unlock))
        {
            isAction = true;
            this.transform.DOMoveX(this.transform.position.x - 1f, 0.2f).OnComplete(() =>
            {
                GameManager.instance.ReduceEnergy(1);
                GameManager.instance.WinGame();
            }
           );
            if (col.col1)
            {
                if (col.col1.gameObject.tag == "Key")
                {
                    m_Unlock = true;
                    Destroy(col.col1.gameObject);
                }
                else if (col.col1.gameObject.tag == "Lock" && m_Unlock)
                {
                    Destroy(col.col1.gameObject);
                }
                else if (col.col1.gameObject.tag == "Trap" || col.col1.gameObject.tag == "Rong")
                {
                    GameManager.instance.ReduceEnergy(1);
                }
            }
        }
    }

    void MoveUp()
    {
        DoubleCollider col = ColliderUp(this.transform);
        if (col.col1 == null || col.col1.gameObject.tag == "TrapTinh" || col.col1.gameObject.tag == "Trap" 
            || col.col1.gameObject.tag == "Rong" || col.col1.gameObject.tag == "Key" || (col.col1.gameObject.tag == "Lock" && m_Unlock))
        {
            isAction = true;
            this.transform.DOMoveY(this.transform.position.y + 1f, 0.2f).OnComplete(() =>
            {
                GameManager.instance.ReduceEnergy(1);
                GameManager.instance.WinGame();
            }
           );
            if (col.col1)
            {
                if (col.col1.gameObject.tag == "Key")
                {
                    m_Unlock = true;
                    Destroy(col.col1.gameObject);
                }
                else if (col.col1.gameObject.tag == "Lock" && m_Unlock)
                {
                    Destroy(col.col1.gameObject);
                }
                else if (col.col1.gameObject.tag == "Trap" || col.col1.gameObject.tag == "Rong")
                {
                    GameManager.instance.ReduceEnergy(1);
                }
            }
        }
    }

    void MoveDown()
    {
        DoubleCollider col = ColliderDown(this.transform);

        if (col.col1==null || col.col1.gameObject.tag == "TrapTinh" || col.col1.gameObject.tag == "Trap" 
            || col.col1.gameObject.tag == "Rong" || col.col1.gameObject.tag == "Key" || (col.col1.gameObject.tag == "Lock" && m_Unlock))
        {
            isAction = true;
            this.transform.DOMoveY(this.transform.position.y - 1f, 0.2f).OnComplete(() =>
            {
                GameManager.instance.ReduceEnergy(1);
                GameManager.instance.WinGame();
            }
           );
            if (col.col1)
            {
                if (col.col1.gameObject.tag == "Key")
                {
                    m_Unlock = true;
                    Destroy(col.col1.gameObject);
                }
                else if (col.col1.gameObject.tag == "Lock" && m_Unlock)
                {
                    Destroy(col.col1.gameObject);
                }
                else if (col.col1.gameObject.tag == "Trap" || col.col1.gameObject.tag == "Rong")
                {
                    GameManager.instance.ReduceEnergy(1);
                }
            }
        }
    }
   
   
    void KickRight()
    {
        DoubleCollider col = ColliderRight(this.transform);
        if (col.col1 && (col.col1.gameObject.tag == "Devil" || col.col1.gameObject.tag == "Stone"))
        {
            isAction = true;
            Collider2D collider = Physics2D.OverlapCircle(this.transform.position, 0.2f);//xem vi tri dang dung co la cai bay khong,da tu bay se mat 2 diem
            if (collider == null ||collider.gameObject.tag=="TrapTinh")//da tu day mat 1 energy
            {
                
                GameManager.instance.ReduceEnergy(1);
            }
            else if (collider.gameObject.tag == "Trap"||collider.gameObject.tag=="Rong")//dung o day da mat 2 nang luong
            {
                GameManager.instance.ReduceEnergy(2);
            }

            if (!col.col2||col.col2.gameObject.tag=="TrapTinh")//col2 ==null thi di chuyen bt
            {
                col.col1.gameObject.transform.DOMoveX(this.transform.position.x + 2f, 0.2f);
            }
            else
            {
                if (col.col1.gameObject.tag == "Devil")
                {
                    if (col.col2.gameObject.tag == "Trap"||col.col2.gameObject.tag=="Rong")
                    {
                        col.col1.gameObject.transform.DOMoveX(this.transform.position.x + 2f, 0.2f)
                            .OnComplete(() => Destroy(col.col1.gameObject));
                    }
                    else
                    {
                        Destroy(col.col1.gameObject);
                    }
                }
                else
                {
                    {
                        if (col.col2.gameObject.tag == "Trap"||col.col2.gameObject.tag=="Rong")
                        {
                            col.col1.gameObject.transform.DOMoveX(this.transform.position.x + 2f, 0.2f);
                        }
                    }
                }
            }
        }
    }

    void KickLeft()
    {
        DoubleCollider col = ColliderLeft(this.transform);
        if (col.col1 && (col.col1.gameObject.tag == "Devil" || col.col1.gameObject.tag == "Stone"))
        {
            isAction = true;
            Collider2D collider = Physics2D.OverlapCircle(this.transform.position, 0.2f);//xem vi tri dang dung co la cai bay khong,da tu bay se mat 2 diem
            if (collider == null || collider.gameObject.tag == "TrapTinh")//da tu day mat 1 energy
            {
                
                GameManager.instance.ReduceEnergy(1);
            }
            else if (collider.gameObject.tag == "Trap" || collider.gameObject.tag == "Rong")//dung o day da mat 2 nang luong
            {
                GameManager.instance.ReduceEnergy(2);
            }

            if (!col.col2 || col.col2.gameObject.tag == "TrapTinh")//col2 ==null thi di chuyen bt
            {
                col.col1.gameObject.transform.DOMoveX(this.transform.position.x - 2f, 0.2f);
            }
            else
            {
                if (col.col1.gameObject.tag == "Devil")
                {
                    if (col.col2.gameObject.tag == "Trap" || col.col2.gameObject.tag == "Rong")
                    {
                        col.col1.gameObject.transform.DOMoveX(this.transform.position.x - 2f, 0.2f)
                            .OnComplete(() => Destroy(col.col1.gameObject));
                    }
                    else
                    {
                        Destroy(col.col1.gameObject);
                    }
                }
                else
                {
                    {
                        if (col.col2.gameObject.tag == "Trap" || col.col2.gameObject.tag == "Rong")
                        {
                            col.col1.gameObject.transform.DOMoveX(this.transform.position.x - 2f, 0.2f);
                        }
                    }
                }
            }
        }
    }

    void KickUp()
    {
        DoubleCollider col = ColliderUp(this.transform);
        if (col.col1 && (col.col1.gameObject.tag == "Devil" || col.col1.gameObject.tag == "Stone"))
        {
            isAction = true;
            Collider2D collider = Physics2D.OverlapCircle(this.transform.position, 0.2f);//xem vi tri dang dung co la cai bay khong,da tu bay se mat 2 diem
            if (collider == null || collider.gameObject.tag == "TrapTinh")//da tu day mat 1 energy
            {
                GameManager.instance.ReduceEnergy(1);
            }
            else if (collider.gameObject.tag == "Trap" || collider.gameObject.tag == "Rong")//dung o day da mat 2 nang luong
            {
                GameManager.instance.ReduceEnergy(2);
            }

            if (!col.col2 || col.col2.gameObject.tag == "TrapTinh")//col2 ==null thi di chuyen bt
            {
                col.col1.gameObject.transform.DOMoveY(this.transform.position.y + 2f, 0.2f);
            }
            else
            {
                if (col.col1.gameObject.tag == "Devil")
                {
                    if (col.col2.gameObject.tag == "Trap" || col.col2.gameObject.tag == "Rong")
                    {
                        col.col1.gameObject.transform.DOMoveY(this.transform.position.y + 2f, 0.2f)
                            .OnComplete(() => Destroy(col.col1.gameObject));
                    }
                    else
                    {
                        Destroy(col.col1.gameObject);
                    }
                }
                else
                {
                    {
                        if (col.col2.gameObject.tag == "Trap" || col.col2.gameObject.tag == "Rong")
                        {
                            col.col1.gameObject.transform.DOMoveY(this.transform.position.y + 2f, 0.2f);
                        }
                    }
                }
            }
        }
    }

    void KickDown()
    {
        DoubleCollider col = ColliderDown(this.transform);
        if (col.col1 && (col.col1.gameObject.tag == "Devil" || col.col1.gameObject.tag == "Stone"))
        {
            isAction = true;
            Collider2D collider = Physics2D.OverlapCircle(this.transform.position, 0.2f);//xem vi tri dang dung co la cai bay khong,da tu bay se mat 2 diem
            if (collider == null || collider.gameObject.tag == "TrapTinh")//da tu day mat 1 energy
            {
                GameManager.instance.ReduceEnergy(1);
            }
            else if (collider.gameObject.tag == "Trap" || collider.gameObject.tag == "Rong")//dung o day da mat 2 nang luong
            {
                GameManager.instance.ReduceEnergy(2);
            }

            if (!col.col2 || col.col2.gameObject.tag == "TrapTinh")//col2 ==null thi di chuyen bt
            {
                col.col1.gameObject.transform.DOMoveY(this.transform.position.y - 2f, 0.2f);
            }
            else
            {
                if (col.col1.gameObject.tag == "Devil")
                {
                    if (col.col2.gameObject.tag == "Trap" || col.col2.gameObject.tag == "Rong")
                    {
                        col.col1.gameObject.transform.DOMoveY(this.transform.position.y - 2f, 0.2f)
                            .OnComplete(() => Destroy(col.col1.gameObject));
                    }
                    else
                    {
                        Destroy(col.col1.gameObject);
                    }
                }
                else
                {
                    {
                        if (col.col2.gameObject.tag == "Trap" || col.col2.gameObject.tag == "Rong")
                        {
                            col.col1.gameObject.transform.DOMoveY(this.transform.position.y - 2f, 0.2f);
                        }
                    }
                }
            }
        }
    }
    
   
   
    void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
        //    Destroy(gameObject);
        }
    }
}


struct DoubleCollider
{
    public Collider2D col1;
    public Collider2D col2;
}
