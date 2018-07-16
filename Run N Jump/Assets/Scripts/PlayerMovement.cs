using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float moveVelocity, jumpForce;

    public bool onLadder, isGrounded;

    public Rigidbody2D myRB;

    public GameObject groundCheck;

    public LayerMask groundCheckMask;

    bool facingLeft;

	// Use this for initialization
	void Start ()
    {

        moveVelocity = 7f;

        jumpForce = 5f;

        myRB = GetComponent<Rigidbody2D>();

        onLadder = false;

        facingLeft = false;

	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetAxis("Horizontal") != 0)
        {
            myRB.velocity = new Vector2(moveVelocity * Input.GetAxis("Horizontal"), myRB.velocity.y);

            if (Input.GetAxis("Horizontal") < 0 && !facingLeft)
            {
                FlipPlayer();
                facingLeft = true;
            }
            else if (Input.GetAxis("Horizontal") > 0 && facingLeft)
            {
                FlipPlayer();
                facingLeft = false;
            }

        }
        else
        {
            myRB.velocity = new Vector2(0f, myRB.velocity.y);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, 0.1f, groundCheckMask);
		
        if ((Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.Space)) && isGrounded && !onLadder)
        {
            myRB.AddForce(new Vector2(0f, jumpForce * 75f));
        }

        if (onLadder)
        {
            myRB.gravityScale = 0f;

            if (Input.GetAxis("Vertical") != 0)
            {
                myRB.velocity = new Vector2(myRB.velocity.x, moveVelocity * Input.GetAxis("Vertical"));
            }
            else
                myRB.velocity = new Vector2(myRB.velocity.x, 0f);

        }

	}

    void FlipPlayer()
    {
        transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
    }
}
