using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    Level level;

    Player player;
    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<Level>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(){
        level.ReduceHealth();
        player.Damage();
    }
}
