using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    Level level;
    GameSession gameSession;
    // Start is called before the first frame update
    void Start()
    {
        level = FindObjectOfType<Level>();
        // CountCollectableGems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);
        if (tag == "CollectableGem")
        {
            CollectedGem();
        }
        else if (tag == "CollectableKey")
        {
            CollectedKey();
        }
    }

    private void CollectedGem()
    {
        // level.RemoveGem();
        level.AddCollectedGem(GetComponent<SpriteRenderer>().sprite);
    }

    private void CollectedKey()
    {
        Sprite key = GetComponent<SpriteRenderer>().sprite;
        // level.RemoveKey();
        level.AddCollectedKey(key);
        level.UnlockLock(key);
    }

    // private void CountCollectableGems()
    // {
    //     if (tag == "CollectableGem")
    //     {
    //         level.CountGems();
    //     }
    //     if (tag == "CollectableKey")
    //     {
    //         level.CountKeys();
    //     }
    // }
}
