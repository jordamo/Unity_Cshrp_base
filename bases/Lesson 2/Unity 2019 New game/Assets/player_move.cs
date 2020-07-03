using System;
using UnityEngine;

public class player_move : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 100f;
    [SerializeField] private Animator playerAnimator;
    private moveManager playerMoveManager;
    private bool toJump = false;
    private float move;
    
    private void Awake()
    {
        playerMoveManager = GetComponent<moveManager>();

        if (playerAnimator == null) playerAnimator = GetComponent<Animator>();
        playerMoveManager.inAirEvent?.AddListener(playJumpAnim);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        move = maxSpeed * Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime;
        if (Input.GetAxisRaw("Jump") == 1) toJump = true;
        else toJump = false;
        
        // Animation section
        ;
        playerAnimator.SetFloat("speed", Math.Abs(move));
        
    }

    public void playJumpAnim(bool inAir)
    {
        playerAnimator.SetBool("jump", inAir);
    }
    
    private void Update()
    {
        playerMoveManager.Move(move, toJump);
        toJump = false;
    }
}
