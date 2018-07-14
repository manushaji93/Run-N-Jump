using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float moveVelocity, jumpForce;

    public bool onLadder, isGrounded;

    public Rigidbody2D myRB;

    public GameObject groundCheck;

    public LayerMask groundCheckMask;

	// Use this for initialization
	void Start () {

        moveVelocity = 7f;

        jumpForce = 5f;

        myRB = GetComponent<Rigidbody2D>();

        onLadder = false;

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("Horizontal") != 0)
        {
            myRB.velocity = new Vector2(moveVelocity * Input.GetAxis("Horizontal"), myRB.velocity.y);
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
}
