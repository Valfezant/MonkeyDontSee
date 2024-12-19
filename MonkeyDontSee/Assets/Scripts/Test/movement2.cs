using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class movement2 : MonoBehaviour
{
    public float horizontal2;
    public float speed2 = 8f;
    public float jumpingpower2 = 10f;
    public float doublejumpingpower2 = 16f;
    public bool isfacingright2 = true;

    private bool doublejump2;

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public bool GotWings = false;

    //Animation
    //public Animator animator;
    //public bool wingedSprite = false;

    private bool _onGround;
    
    public bool jump = false;
    
    // Update is called once per frame
    private void Update()
    {
        horizontal2 = Input.GetAxisRaw("Horizontal");

        //Animation
        //animator.SetFloat("Speed", Mathf.Abs(horizontal2));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, doublejump2 ? doublejumpingpower2 : jumpingpower2);
            jump = true;
            //Debug.Log("jumop");
        }

        //DoubleJump Condition
        /*if (GotWings)
        {
            //doublejumping
            if (_onGround && !Input.GetButton("Jump"))
            {
                doublejump2 = false;
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (_onGround || doublejump2)
                {
                    rb.velocity = new Vector2(rb.velocity.x, doublejump2 ? doublejumpingpower2 : jumpingpower2);

                    doublejump2 = !doublejump2;

                    //Animation
                    //animator.SetBool("IsDJ", true);
                    //animator.SetBool("IsJumping", false);
                }

                //Animation
                //animator.SetBool("IsJumping", true);
            }
        }
        else
        {
            //Jumping
                doublejump2 = false;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_onGround)
                {
                    rb.velocity = new Vector2(rb.velocity.x, doublejump2 ? doublejumpingpower2 : jumpingpower2);

                    //Animation
                    //animator.SetBool("IsJumping", true);
                }
            }
        }*/

        //just speed i think???
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip ();
        //JumpAnimation();
    }

    private void FixedUpdate ()
    {
        rb.velocity = new Vector2(horizontal2 * speed2, rb.velocity.y);

        jump = false;

        CheckCollision();

        /*if(IsGrounded2())
        {
            animator.SetBool("IsJumping", false);
        }*/
    }

    /*private bool IsGrounded2()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }*/

    private void CheckCollision()
    {
        _onGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //Sprite flip
    private void Flip ()
    {
        if (isfacingright2 && horizontal2 < 0f || !isfacingright2 && horizontal2 > 0f)
        {
            Vector3 localScale = transform.localScale;
            isfacingright2 = !isfacingright2;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    /*void JumpAnimation()
    {
        if (_onGround)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsDJ", false);
        }
        else
        {
            animator.SetBool("IsJumping", true);
            
            
            
        }
    }*/
}
