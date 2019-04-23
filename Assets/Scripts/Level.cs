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
        for (int i = 0; i < availableGems.Length; i++)
        {
            if (collectedGem == availableGems[i])
            {
                gemTracker[i].GetComponent<UnityEngine.UI.Image>().sprite = collectedGem;
            }
        }
    }
}
