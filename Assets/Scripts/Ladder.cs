using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
    {

        [SerializeField] Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // player.ClimbingLadder();
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        // player.LeavingLadder();
    }
}
