using System;
using UnityEngine;
using UnityEngine.Events;

public class moveManager : MonoBehaviour
{
    [SerializeField] private float jumpVel = 200f;
    [SerializeField] [Range(0f, 1f)] private float smoothTime = 0.05f;
    [SerializeField] private bool facingRight = true;
    [SerializeField] private Transform playerBottom;
    [SerializeField] private LayerMask grounds;
    
    public event EventHandler<bool> inAirEvent;

    public event EventHandler onGroundEvent;

    private Vector2 curVector = Vector2.zero;
    private Rigidbody2D playerRB;
    private float overlapRadius = 0.1f;
    private bool onGround = false;
    
    private void Awake()
    {
        
        if (grounds == 0) grounds = LayerMask.GetMask("Ground");
        if (playerBottom == null)
        {
            playerBottom = new GameObject().transform;
            gameObject.transform.Translate(-1f,0,0);
        }
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        onGround = false;
        Collider2D[] collider = Physics2D.OverlapCircleAll(playerBottom.position, overlapRadius, grounds);
        foreach (var col in collider)
        {
            if (col.gameObject != gameObject)
            {
                if (!onGround){
                    onGroundEvent?.Invoke(gameObject, EventArgs.Empty);
                    inAirEvent?.Invoke(gameObject, false);
                }
                onGround = true;
            }
        }
        if (!onGround && playerRB.velocity.y < 0){
            inAirEvent?.Invoke(gameObject, true);    
            
            Debug.Log("IN AIR");
        }
        
    }

    public void Move(float move, bool toJump)
    {
        if (facingRight && move < 0)
            Flip();
        if (!facingRight && move > 0)
            Flip();

        if (toJump && onGround)
        {
            onGround = false;
            // playerRB.velocity = new Vector2(playerRB.velocity.x, 0f);
            playerRB.AddForce(new Vector2(0f,jumpVel), ForceMode2D.Impulse);
        }
        
        Vector2 targetVel = new Vector2(move, 0f);
        playerRB.velocity = Vector2.SmoothDamp(playerRB.velocity, targetVel, ref curVector, smoothTime);
        
    }

    private void Flip()
    {
        facingRight = !facingRight;
        gameObject.transform.Rotate(gameObject.transform.up, 180f);
    }
}
