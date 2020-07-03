using UnityEngine;
using UnityEngine.Events;

public class moveManager : MonoBehaviour
{
    public class BoolEvent : UnityEvent<bool> {};
    [SerializeField] private float jumpForce = 200f;
    [SerializeField] private LayerMask groundObjects;
    [SerializeField] private Transform playerBottom;
    [SerializeField] private bool faceRight = true;
    [SerializeField][Range(0f,1f)] private float smoothTime = .1f;
    
    [Space] 
    public UnityEvent onGroundEvent;
    public BoolEvent inAirEvent;
    private Rigidbody2D playerRB;
    private Vector2 velVector = Vector2.zero;

    private float checkRadius = 0.1f;
    private bool onGround = false;
    
    private void Awake()
    {
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        if (groundObjects == 0) groundObjects = LayerMask.GetMask("Ground");
        if (playerRB == null) playerRB = new Rigidbody2D();
        if (onGroundEvent == null) onGroundEvent = new UnityEvent();
        if (inAirEvent == null) inAirEvent = new BoolEvent();
        if (playerBottom == null)
        {
            playerBottom = gameObject.transform;
            playerBottom.Translate(playerBottom.position.x - 1f,0f,0f);
        }
    }

    private void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(playerBottom.position, checkRadius, groundObjects);
        foreach (var col in colliders)
        {
            if (col.gameObject != gameObject)
            {
                if (!onGround)
                {
                    onGroundEvent?.Invoke();
                    inAirEvent?.Invoke(false);                    
                }
                onGround = true;
            }
        }
        if (!onGround && playerRB.velocity.y > 0)
            inAirEvent?.Invoke(true);
    }

    public void Move(float move, bool toJump)
    {
        
        if (faceRight && move < 0) Flip();
        if (!faceRight && move > 0) Flip();
        
        playerRB.velocity = Vector2.SmoothDamp(playerRB.velocity, new Vector2(move, playerRB.velocity.y), ref velVector, smoothTime);
        
        if (onGround && toJump)
        {
            onGround = false;
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0f);
            playerRB.AddForce(new Vector2(0, jumpForce));
        }
        
    }

    private void Flip()
    {
        faceRight = !faceRight;
        transform.Rotate(Vector3.up, 180f);
    }
}
