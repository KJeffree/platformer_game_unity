using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    Level level;
    // Start is called before the first frame update
    void Start()
    {
        CountCollectableGems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);
        level.RemoveGem();
    }

    private void CountCollectableGems()
    {
        level = FindObjectOfType<Level>();
        if (tag == "CollectableGem")
        {
            level.CountGems();
        }
    }
}
