using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("saw2");
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.Play("saw2");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.Play("saw1");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.Play("sawIdle");
        }
    }
}
