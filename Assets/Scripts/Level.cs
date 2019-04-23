using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int collectableGems;
    [SerializeField] GameObject[] gemTracker;

    [SerializeField] Sprite[] availableGems;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CountGems()
    {
        collectableGems++;
    }

    public void RemoveGem()
    {
        collectableGems--;
    }

    public void AddCollectedGem(Sprite collectedGem)
    {
        if (collectedGem == availableGems[0])
        {
            gemTracker[0].GetComponent<UnityEngine.UI.Image>().sprite = collectedGem;
        }
        else if (collectedGem == availableGems[1])
        {
            gemTracker[1].GetComponent<UnityEngine.UI.Image>().sprite = collectedGem;
        }
        else if (collectedGem == availableGems[2])
        {
            gemTracker[2].GetComponent<UnityEngine.UI.Image>().sprite = collectedGem;
        }
        else if (collectedGem == availableGems[3])
        {
            gemTracker[3].GetComponent<UnityEngine.UI.Image>().sprite = collectedGem;
        }
    }
}
