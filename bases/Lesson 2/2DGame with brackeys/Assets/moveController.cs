using System;
using UnityEngine;
using UnityEngine.Events;

public class moveController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 100f;
    [SerializeField] private ushort numberOfJumps = 1;
    [Range(0f, 10f)] private float smooth;
    
    // [SerializeField] private Transform p_top;
    [SerializeField] private Transform p_bot;
    [SerializeField] private LayerMask ground;

    [Header("Events")] [Space] [SerializeField]
    private UnityEvent onLandEvent;

    private bool onGround = false;
    private bool facingRight = true;
    private float groundedRadius = 0.2f;
    private Vector2 z_vel = Vector2.zero;
    private ushort jumpCounter = 1;
    private Rigidbody2D heroRB2D;
    
    
    private void Awake()
    {
        heroRB2D = GetComponent<Rigidbody2D>();
        if (onLandEvent == null)
            onLandEvent = new UnityEvent();
    }

    private void FixedUpdate()
    {
        onGround = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(p_bot.position, groundedRadius, ground);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                // Debug.Log($"collision with {colliders[i].gameObject}");
                if (!onGround)
                {
                    onGround = true;
                    jumpCounter = 1;
                    onLandEvent?.Invoke();
                }
            }
        }
        
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up, 180f);
    }

    public void Move(float move, bool toJump)
    {
        Vector2 vel = new Vector2(move*10f, heroRB2D.velocity.y);
        heroRB2D.velocity = Vector2.SmoothDamp(heroRB2D.velocity, vel, ref z_vel, smooth);

        if (move > 0 && !facingRight)
        {
            Flip();
        } 
        else if (move < 0 && facingRight)
        {
            Flip();
        }
        
        if (toJump && onGround)
        {

                jumpCounter++;
                onGround = false;
                heroRB2D.AddForce(new Vector2(0f, jumpForce));
            
        }
        Debug.Log($"jumpCounter {jumpCounter}");
    }
}
