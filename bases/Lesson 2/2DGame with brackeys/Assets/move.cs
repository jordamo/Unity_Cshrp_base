using System;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 10f;

    private moveController moveManager;
    private bool toJump = false;
    public Animator anim;

    private void Awake()
    {
        moveManager = GetComponent<moveController>();
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxisRaw("Horizontal") * horizontalSpeed * Time.fixedDeltaTime;
        if (Input.GetButtonDown("Jump")) toJump = true;
        if (Input.GetButtonUp("Jump")) toJump = false;
        moveManager.Move(move, toJump);
        anim.SetBool("toJump", toJump);
        anim.SetBool("toRun", Math.Abs(move) > 0 ? true : false);
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
