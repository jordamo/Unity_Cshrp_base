using System;
using UnityEngine.Events;
using UnityEngine;

public class charactrer_move2D : MonoBehaviour
{
    public Brackeys_script_2D contoller;
    public float runSpeed = 40f;
    public float jumpVel = 40f;
    private float hMove = 0f;
    
    public void Update()
    {
        hMove = Input.GetAxisRaw("Horizontal")*runSpeed;
        
    }

    private void FixedUpdate()
    {
        contoller.Move(hMove * Time.fixedDeltaTime, false, false);
        if (Input.GetKey(KeyCode.Space))
        {
            contoller.Move(jumpVel * Time.fixedDeltaTime, true, true);
        }
    }
}
























// abstract.,







