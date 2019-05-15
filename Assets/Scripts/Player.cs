using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 10.00f;
    Animator animator;


    bool grounded = false;
    bool movingRight = true;
    bool canClimb = false;
    bool climbing = false;

    // bool hitWall = false;
    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // MoveVertical();
        // MoveHorizontal();

        var vertical = Input.GetAxis("Vertical");
        if (vertical != 0)
        {
            MoveVertical();
        }
        var horizontal = Input.GetAxis("Horizontal");

        if (!grounded && movingRight && !canClimb)
        {
            MoveVertical();
            MoveHorizontal();
            movingRight = true;
            animator.SetInteger("Action", 4);
        }
        else if (!grounded && !movingRight && !canClimb)
        {
            MoveVertical();
            MoveHorizontal();
            movingRight = false;
            animator.SetInteger("Action", 5);
        }
        else if (climbing && vertical == 0)
        {
            animator.SetInteger("Action", 6);
        }
        else if (vertical == 0 && horizontal == 0)
        {
           animator.SetInteger("Action", 0);
        }
        else if (vertical == 0 && horizontal > 0)
        {
            MoveHorizontal();
            movingRight = true;
            animator.SetInteger("Action", 1);
        }
        else if (vertical == 0 && horizontal < 0)
        {
            MoveHorizontal();
            movingRight = false;
            animator.SetInteger("Action", 2);
        }
        else if (canClimb && vertical != 0)
        {
            climbing = true;
            MoveVertical();
            MoveHorizontal();
            animator.SetInteger("Action", 3);
        }
    }

    private void MoveHorizontal()
    {
        climbing = false;
        var deltaX = Input.GetAxis("Horizontal") * speed;
        var movement = deltaX *= Time.deltaTime;
        transform.Translate(movement, 0, 0);
    }
    private void MoveVertical()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && grounded && !canClimb)
        {
            rigidBody.AddForce(new Vector3(0, 6, 0), ForceMode2D.Impulse);
        }
        else if (canClimb && climbing)
        {
            rigidBody.gravityScale = 0;
            var deltaY = Input.GetAxis("Vertical");
            var newYPos = transform.position.y + deltaY / 10;
            transform.position = new Vector3(transform.position.x, newYPos, transform.position.z);
        }
    }

    // public void HitWall()
    // {
    //     hitWall = true;
    // }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
        animator.SetInteger("Action", 0);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (rigidBody.velocity.y != 0)
        {
            grounded = false;
        }
    }

    public void ClimbingLadder()
    {
        rigidBody.velocity = new Vector2(0,0);
        canClimb = true;
    }

    public void LeavingLadder()
    {
        rigidBody.gravityScale = 1;
        canClimb = false;
    }
}