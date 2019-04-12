using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Sprite[] walking;
    [SerializeField] Sprite[] idle;
    [SerializeField] Sprite[] jumping;

    float speed = 10.00f;


    bool grounded = false;
    bool movingRight = true;
    bool canClimb = false;
    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontal();
        MoveVertical();
    }

    private void MoveHorizontal()
    {
        var deltaX = Input.GetAxis("Horizontal") * speed;
        var movement = deltaX *= Time.deltaTime;
        transform.Translate(movement, 0, 0);
        
        if (deltaX > 0 && grounded)
        {
            // AnimatePlayerWalkingRight();
            movingRight = true;
        }
        else if (deltaX < 0 && grounded)
        {
            // AnimatePlayerWalkingLeft();
            movingRight = false;
        }
        else if (movingRight && grounded)
        {
            // ChangeSprite(idle, 0);
        }
        else if (!movingRight && grounded)
        {
            // ChangeSprite(idle, 1);
        }
    }
    private void MoveVertical()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && grounded && !canClimb)
        {
            grounded = false;
            rigidBody.AddForce(new Vector3(0, 5, 0), ForceMode2D.Impulse);
            // AnimatePLayerJumping();
        }
        else if (canClimb)
        {
            var deltaY = Input.GetAxis("Vertical");
            var newYPos = transform.position.y + deltaY / 10;
            transform.position = new Vector2(transform.position.x, newYPos);
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

    // private void AnimatePLayerJumping()
    // {
    //     if (movingRight && !grounded)
    //     {
    //         ChangeSprite(jumping, 0);
    //     }
    //     else if (!movingRight && !grounded)
    //     {
    //         ChangeSprite(jumping, 1);
    //     }
    // }

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
