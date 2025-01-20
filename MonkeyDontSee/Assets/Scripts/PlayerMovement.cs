using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMove;
    private float verticalMove;
    [HideInInspector] public float normGravityScale;
    
    [Header("Stats")]
    public float moveSpeed;
    public float jumpPower;
    public float doubleJumpPower;
    public float climbingSpeed;
    public float waterSpeed;
    public float Fallmultiplier;

    [Header("Utility")]
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    private bool _doubleJump;
    private bool _facingRight = true;
    private bool _onGround;
    private bool _isClimbable;
    public bool _isClimbing;
    private bool _inWater;
    [HideInInspector] public bool _onWall;

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
        if (_isClimbable && Input.GetButton("Fire3"))
        {
            _isClimbing = true;
            _onGround = true;

            _onWall = true;
        }
        else
        {
            _onWall = false;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);

        if (rb.velocity.y < 1 && !_inWater)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * Fallmultiplier * Time.deltaTime;
        }

        if (_isClimbing && Input.GetButton("Fire3"))
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, verticalMove * climbingSpeed);
        }
        else if (_inWater)
        {
            rb.gravityScale = 0f;
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

    //on ground check
    private void CheckCollision()
    {
        if (!_isClimbing && !_inWater)
        {
            _onGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }
    }

    //find climbable walls
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Climbable"))
        {
            _isClimbable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Climbable"))
        {
            _isClimbable = false;
            _isClimbing = false;
            _onGround = true;
        }
    }

    //water movement
    public void EnterWater()
    {
        _inWater = true;
        _onGround = true;
        
        moveSpeed /= waterSpeed;
        jumpPower /= waterSpeed;
        doubleJumpPower /= waterSpeed;
        climbingSpeed /= waterSpeed;
    }

    public void ExitWater()
    {
        _inWater = false;

        moveSpeed *= waterSpeed;
        jumpPower *= waterSpeed;
        doubleJumpPower *= waterSpeed;
        climbingSpeed *= waterSpeed;
    }
}
