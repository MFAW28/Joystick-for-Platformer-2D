using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	///for movement player
    private Rigidbody2D rb2D;
    public float speedMove;
    private Vector2 movement;

    ///for make face player left/right when press left/right
    private bool facingRight;
    public float movementTest;
	
	///for detect ground when want to jump
	public int jumpForce;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool isGrounded;

    ///for Joystick access
    public Joystick joystickMovement;

    void Start()
    {
        ///get component rigidbody on this
        rb2D = GetComponent<Rigidbody2D>();

        ///make face to right in first time (follow the sprite image)
        facingRight = true;
    }

    void Update()
    {
        ///input Left Right or Keys A D to movement horizontal
        movement.x = Input.GetAxisRaw("Horizontal");
        ///input movement left right with joystick for handphone
        movement.x = joystickMovement.Horizontal;
        movementTest = movement.x; 

        ///make face to left/right when press left/right
        if(movement.x > 0.1f && facingRight == false)
        {
            facingRight = true;
        }
        else if(movement.x < -0.1f && facingRight == true)
        {
            facingRight = false;
        }

        if(facingRight == true)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);

        }

        //script for jump when press key uparrow and in ground
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb2D.velocity = Vector2.up * jumpForce;
        }
    }

    private void FixedUpdate()
    {
        ///for move the player with rigidbody to left and right
        rb2D.velocity = new Vector2(movement.x * speedMove, rb2D.velocity.y);
		
        ///check player when is grounded true
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    ///for button jump
    public void BtnJump()
    {
        if (isGrounded)
        {
            rb2D.velocity = Vector2.up * jumpForce;
        }
    }
}
