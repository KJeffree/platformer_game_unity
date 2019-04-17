using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Collider2D collider = collision.collider;

    //     Vector3 contactPoint = collision.contacts[0].point;
    //     Vector3 center = collider.bounds.center;

    //     bool right = contactPoint.x > center.x + 0.5;
    //     bool left = contactPoint.x < center.x - 0.5;

    //     if(right || left)
    //     {
    //         // Rigidbody2D playerRigidBody = player.GetComponent<Rigidbody2D>();
    //         // playerRigidBody.velocity = new Vector2(0,0);
    //         player.HitWall();
    //     }

    // }
}
