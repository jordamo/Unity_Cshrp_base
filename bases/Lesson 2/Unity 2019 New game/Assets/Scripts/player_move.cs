using System;
using UnityEngine;

public class player_move : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    private float move;
    private bool toJump = false;

    [SerializeField] private Animator anim;
    private moveManager playerMM;

    private void playJumpAnim(object sender, bool toJump)
    {
        anim.SetBool("jump", toJump);
    }
    private void Awake()
    {
        playerMM = GetComponent<moveManager>();
        playerMM.inAirEvent += playJumpAnim;
        if (anim == null) anim = GetComponent<Animator>();
    }

    private void Update()
    {
        playerMM.Move(move, toJump);
        toJump = false;
    }

    private void FixedUpdate()
    {
        move = Input.GetAxisRaw("Horizontal") * speed;
        if (Input.GetAxisRaw("Jump") >= .5) toJump = true;
        else if (Input.GetAxisRaw("Jump") < .5) toJump = false;
        
        // Animation section
        anim.SetFloat("speed", Math.Abs(move));
    }
    
}
