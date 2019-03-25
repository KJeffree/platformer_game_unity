using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Sprite[] walking;
    [SerializeField] Sprite[] idle;
    [SerializeField] Sprite[] jumping;


    bool grounded = false;
    bool movingRight = true;
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
        Debug.Log(grounded);
    }

    private void MoveHorizontal()
    {
        var deltaX = Input.GetAxis("Horizontal");
        var newXPos = transform.position.x + deltaX / 8;
        transform.position = new Vector2(newXPos, transform.position.y);
        if (deltaX > 0 && grounded)
        {
            AnimatePlayerWalkingRight();
            movingRight = true;
        }
        else if (deltaX < 0 && grounded)
        {
            AnimatePlayerWalkingLeft();
            movingRight = false;
        }
        else if (movingRight && grounded)
        {
            GetComponent<SpriteRenderer>().sprite = idle[0];
        }
        else if (!movingRight && grounded)
        {
            GetComponent<SpriteRenderer>().sprite = idle[1];
        }
    }
    private void MoveVertical()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && grounded == true)
        {
            grounded = false;
            rigidBody.AddForce(new Vector3(0, 5, 0), ForceMode2D.Impulse);
            AnimatePLayerJumping();
        }
    }

    private void AnimatePlayerWalkingRight()
    {
        Sprite playerSprite = GetComponent<SpriteRenderer>().sprite;
        if (playerSprite != walking[0])
        {
            GetComponent<SpriteRenderer>().sprite = walking[0];
        } 
        else if (playerSprite == walking[0]) 
        {
            GetComponent<SpriteRenderer>().sprite = walking[1];
        }
    }
     private void AnimatePlayerWalkingLeft()
    {
        Sprite playerSprite = GetComponent<SpriteRenderer>().sprite;
        if (playerSprite != walking[2])
        {
            GetComponent<SpriteRenderer>().sprite = walking[2];
        } 
        else if (playerSprite == walking[2]) 
        {
            GetComponent<SpriteRenderer>().sprite = walking[3];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
    }

    private void AnimatePLayerJumping()
    {
        if (movingRight && !grounded)
        {
            GetComponent<SpriteRenderer>().sprite = jumping[0];
        }
        else if (!movingRight && !grounded)
        {
            GetComponent<SpriteRenderer>().sprite = jumping[1];
        }
    }
}
