using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    //xem monster co va cham voi bay tinh khong
    void Update()
    {
        Collider2D col = Physics2D.OverlapCircle(this.transform.position, 0.2f, 1 << 6);
        if (col && col.gameObject.tag == "TrapTinh")
        {
            Destroy(gameObject);
        }
    }
}
