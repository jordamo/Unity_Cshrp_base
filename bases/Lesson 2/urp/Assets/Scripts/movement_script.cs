using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
class PlayerSettings
{
    [SerializeField] public float speed = 40f;
    [SerializeField] public float jumpForce = 100f;
    [SerializeField] [Range(0f, 1f)] public float smoothTime = 0.05f;
    [SerializeField] [Range(0f, 1f)] public float crouchScale = 0.27f;
    [SerializeField] internal int additionalJumps = 2;
}

[Serializable]
class PlayerAbsSettings
{
    [SerializeField] internal Collider2D hideCollider;
    [SerializeField] internal  Rigidbody2D playerRB;
    [SerializeField] internal  Transform playerBottom;
    [SerializeField] internal  Transform playerTop;
    [SerializeField] internal  float overlapRadius = 0.2f;
    [SerializeField] internal  LayerMask groundsMask;
    [SerializeField] internal bool facingRight = true;
    
}

public class movement_script : MonoBehaviour
{
    [SerializeField] private PlayerSettings p_settings = new PlayerSettings();
    [SerializeField] private PlayerAbsSettings p_abs_settings = new PlayerAbsSettings();

    private bool onGround = false;
    private bool inAir = false;
    private bool wasCrouching = false;
    private Vector2 zVector = Vector2.zero;
    private int jumpCount;
    
    public event EventHandler<bool> onCrouchEvent;
    public event EventHandler<bool> inAirEvent;
    
    
    private void Awake()
    {
        if (p_abs_settings.hideCollider == null)
            p_abs_settings.hideCollider = GetComponent<BoxCollider2D>();
        if (p_abs_settings.playerRB == null)
            p_abs_settings.playerRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        onGround = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(
            p_abs_settings.playerBottom.position, 
            p_abs_settings.overlapRadius, 
            p_abs_settings.groundsMask
            );
        foreach (var col in colliders)
        {
            if (col.gameObject != gameObject)
            {
                if (!onGround)
                {
                    jumpCount = p_settings.additionalJumps;
                    onGround = true;
                    inAirEvent?.Invoke(gameObject, false);
                }
            }
        }

        if (!onGround)
        {
            inAirEvent?.Invoke(gameObject, true);
        }
    }

    private void Update()
    {
        bool onCrouch = false, onJump = false;
        float toMove = Time.fixedDeltaTime* p_settings.speed * Input.GetAxisRaw("Horizontal");
        if (Input.GetButton("Crouch"))
        {
            onCrouch = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            onJump = true;
        }
        
        Move(
            toMove,
            onCrouch,
            onJump
            );
    }

    public void Move(float move, bool crouch, bool jump)
    {
        move *= 10;
        if (!crouch)
        {
            if (Physics2D.OverlapCircle(
                p_abs_settings.playerTop.position,
                p_abs_settings.overlapRadius,
                p_abs_settings.groundsMask) != null)
            {
                crouch = true;
            }
        }

        
        if (crouch && onGround)
        {
            if (!wasCrouching)
            {
                wasCrouching = true;
                onCrouchEvent?.Invoke(gameObject, true);
                if (p_abs_settings.hideCollider != null)
                    p_abs_settings.hideCollider.enabled = false;
            }
            move *= p_settings.crouchScale;
        }
        else
        {
            if (wasCrouching)
            {
                wasCrouching = false;
                onCrouchEvent?.Invoke(gameObject, false);
                if (p_abs_settings.hideCollider != null)
                    p_abs_settings.hideCollider.enabled = true;
            }
            
            if (jump && onGround)
            {
                p_abs_settings.playerRB.AddForce(
                    new Vector2(0f, p_settings.jumpForce), 
                    ForceMode2D.Impulse
                    );
                onGround = false;
            } else if (jump && jumpCount > 0)
            {
                p_abs_settings.playerRB.velocity = new Vector2(p_abs_settings.playerRB.velocity.x, 0f);
                p_abs_settings.playerRB.AddForce(
                    new Vector2(0f, p_settings.jumpForce), 
                    ForceMode2D.Impulse
                );
                jumpCount--;
            }
            onCrouchEvent?.Invoke(gameObject, false);
        }
        

        if (move > 0 && !p_abs_settings.facingRight)
            Flip();
        if (move < 0 && p_abs_settings.facingRight)
            Flip();

        p_abs_settings.playerRB.velocity = Vector2.SmoothDamp(
            p_abs_settings.playerRB.velocity,
            new Vector2(move, 0f),
            ref zVector,
            p_settings.smoothTime
            );
    }

    private void Flip()
    {
        p_abs_settings.facingRight = !p_abs_settings.facingRight;
        transform.Rotate(Vector3.up, 180f);
    }

}
