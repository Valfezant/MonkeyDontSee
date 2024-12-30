using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMove;
    private float verticalMove;

    private float normGravityScale;
    
    [Header("Stats")]
    public float moveSpeed;
    public float jumpPower;
    public float doubleJumpPower;
    public float climbingSpeed;

    [Header("Utility")]
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    private bool _doubleJump;
    private bool _facingRight = true;
    private bool _onGround;
    private bool _isLadder;
    private bool _isClimbing;

    void Start()
    {
        normGravityScale = rb.gravityScale;
    }
    
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        Flip();

        //JUMPING
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

        //CLIMBING
        if (_isLadder && Input.GetButton("Fire3"))
        {
            _isClimbing = true;
            _onGround = true;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);

        if (_isClimbing && Input.GetButton("Fire3"))
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, verticalMove * climbingSpeed);
        }
        else
        {
            rb.gravityScale = normGravityScale;
            //_onGround = false;
        }

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

    //collisions
    private void CheckCollision()
    {
        if (!_isClimbing)
        {
            _onGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Climbable"))
        {
            _isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Climbable"))
        {
            _isLadder = false;
            _isClimbing = false;
            _onGround = true;
        }
    }
}
