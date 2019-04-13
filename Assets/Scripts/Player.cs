using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //[SerializeField] Sprite[] walking;
    //[SerializeField] Sprite[] idle;
    //[SerializeField] Sprite[] jumping;

    float speed = 10.00f;
    Animator animator;


    bool grounded = false;
    bool movingRight = true;
    bool canClimb = false;
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
        MoveVertical();
        MoveHorizontal();

        //var vertical = Input.GetAxis("Vertical");
        //var horizontal = Input.GetAxis("Horizontal");

        //if (vertical == 0 && horizontal == 0)
        //{
        //    animator.SetInteger("Action", 0);
        //}
        //else if (vertical == 0 && horizontal > 0)
        //{
        //    animator.SetInteger("Action", 1);
        //}
        //else if (vertical == 0 && horizontal < 0)
        //{
        //    animator.SetInteger("Action", 2);
        //}
        //else if (vertical != 0 && horizontal > 0)
        //{
        //    animator.SetInteger("Action", 4);
        //}
        //else if (vertical != 0 && horizontal < 0)
        //{
        //    animator.SetInteger("Action", 5);
        //}
        //else if (canClimb & horizontal == 0)
        //{
        //    animator.SetInteger("Action", 3);
        //}
    }

    private void MoveHorizontal()
    {
        var deltaX = Input.GetAxis("Horizontal") * speed;
        var movement = deltaX *= Time.deltaTime;
        transform.Translate(movement, 0, 0);
        
        if (deltaX > 0 && grounded)
        {
            animator.SetInteger("Action", 1);
            movingRight = true;
        }
        else if (deltaX < 0 && grounded)
        {
            animator.SetInteger("Action", 2);
            movingRight = false;
        }
        else if (movingRight && grounded)
        {
            animator.SetInteger("Action", 0);
        }
        else if (!movingRight && grounded)
        {
            animator.SetInteger("Action", 0);

        }
    }
    private void MoveVertical()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && grounded && !canClimb)
        {
            grounded = false;
            rigidBody.AddForce(new Vector3(0, 5, 0), ForceMode2D.Impulse);
             AnimatePLayerJumping();
        }
        else if (canClimb)
        {
            var deltaY = Input.GetAxis("Vertical");
            var newYPos = transform.position.y + deltaY / 10;
            transform.position = new Vector2(transform.position.x, newYPos);
            AnimatePlayerClimbing();
        }
    }

    private void AnimatePlayerClimbing()
    {
        if (canClimb && !grounded)
        {
            animator.SetInteger("Action", 3);
        }
    }

    // private void AnimatePlayerWalkingRight()
    // {
    //     Sprite playerSprite = GetComponent<SpriteRenderer>().sprite;
    //     if (playerSprite != walking[0])
    //     {
    //         ChangeSprite(walking, 0);
    //     } 
    //     else if (playerSprite == walking[0]) 
    //     {
    //         ChangeSprite(walking, 1);
    //     }
    // }
    //  private void AnimatePlayerWalkingLeft()
    // {
    //     Sprite playerSprite = GetComponent<SpriteRenderer>().sprite;
    //     if (playerSprite != walking[2])
    //     {
    //         ChangeSprite(walking, 2);
    //     } 
    //     else if (playerSprite == walking[2]) 
    //     {
    //         ChangeSprite(walking, 3);
    //     }
    // }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
    }

     private void AnimatePLayerJumping()
     {
         if (movingRight && !grounded)
         {
            animator.SetInteger("Action", 4);
         }
        else if (!movingRight && !grounded)
         {
            animator.SetInteger("Action", 5);
         }
    }

    // private void ChangeSprite(Sprite[] action, int index)
    // {
    //     GetComponent<SpriteRenderer>().sprite = action[index];
    // }

    public void ClimbingLadder()
    {
        rigidBody.gravityScale = 0;
        rigidBody.velocity = new Vector2(0,0);
        canClimb = true;
        // transform.position = new Vector2();       
    }

    public void LeavingLadder()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
        canClimb = false;
    }
}
