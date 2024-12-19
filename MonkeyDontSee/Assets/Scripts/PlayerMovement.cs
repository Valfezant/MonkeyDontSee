using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMove;
    //Controllable
    public float moveSpeed;
    public float jumpPower;
    public float doubleJumpPower;

    [SerializeField] private Rigidbody2D rb;

    private bool _doubleJump;
    private bool _facingRight = true;
    private bool _onGround;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        Flip();


        //jumping
        if (_onGround && !Input.GetButton("Jump"))
        {
            _doubleJump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (_onGround || _doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, _doubleJump ? doubleJumpPower : jumpPower);

                _doubleJump = !_doubleJump;
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);

        CheckCollision();
    }

    //sprite flip
    private void Flip()
    {
        if (_facingRight && horizontalMove < 0f || !_facingRight && horizontalMove > 0f)
        {
            Vector3 localScale = transform.localScale;
            _facingRight = !_facingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void CheckCollision()
    {
        _onGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
