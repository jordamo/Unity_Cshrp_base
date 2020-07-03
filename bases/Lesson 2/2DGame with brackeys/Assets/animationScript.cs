using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationScript : MonoBehaviour
{
    public Animator animator;

    private Rigidbody2D rb;
    // Update is called once per frame
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButton("Horizontal"))
            animator.SetTrigger("runTrigger");
        if (Input.GetButton("Jump"))
            animator.SetTrigger("jumpSTrigger");
        if (rb.velocity.y < 0)
        {
            animator.ResetTrigger("jumpSTrigger");
            animator.SetTrigger("jumpETrigger");
        }

        if (rb.velocity.y == 0)
        {
            animator.ResetTrigger("jumpETrigger");

        }
        
    }
}
