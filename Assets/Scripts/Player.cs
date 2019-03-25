using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Sprite[] walking;
    bool grounded = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontal();
        MoveVertical(); 
    }

    private void MoveHorizontal()
    {
        var deltaX = Input.GetAxis("Horizontal");
        var newXPos = transform.position.x + deltaX / 8;
        transform.position = new Vector2(newXPos, transform.position.y);
        if (deltaX > 0)
        {
            AnimatePlayerWalkingRight();
        }
        else if (deltaX < 0)
        {
            AnimatePlayerWalkingLeft();
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = walking[0];
        }
    }
    private void MoveVertical()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && grounded == true)
        {
            
        }
        
        // if (deltaY > 0)
        // {
        //     AnimatePlayerWalkingRight();
        // }
        // else if (deltaX < 0)
        // {
        //     AnimatePlayerWalkingLeft();
        // }
        // else
        // {
        //     GetComponent<SpriteRenderer>().sprite = walking[0];
        // }
    }

    private void AnimatePlayerWalkingRight()
    {
        Sprite playerSprite = GetComponent<SpriteRenderer>().sprite;
        if (playerSprite != walking[1])
        {
            GetComponent<SpriteRenderer>().sprite = walking[1];
        } 
        else if (playerSprite == walking[1]) 
        {
            GetComponent<SpriteRenderer>().sprite = walking[2];
        }
    }
     private void AnimatePlayerWalkingLeft()
    {
        Sprite playerSprite = GetComponent<SpriteRenderer>().sprite;
        if (playerSprite != walking[3])
        {
            GetComponent<SpriteRenderer>().sprite = walking[3];
        } 
        else if (playerSprite == walking[3]) 
        {
            GetComponent<SpriteRenderer>().sprite = walking[4];
        }
    }

    public void GroundPlayer()
    {
        grounded = true;
    }
}
