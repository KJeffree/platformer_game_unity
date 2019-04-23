using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    // [SerializeField] int collectableGems;
    // [SerializeField] int collectableKeys;
    [SerializeField] GameObject[] gemTracker;
    [SerializeField] GameObject[] keyTracker;

    [SerializeField] Sprite[] availableGems;
    [SerializeField] Sprite[] availableKeys;

    [SerializeField] Lock[] availableLocks;

    // public void CountGems()
    // {
    //     collectableGems++;
    // }

    // public void CountKeys()
    // {
    //     collectableKeys++;
    // }

    // public void RemoveGem()
    // {
    //     collectableGems--;
    // }

    // public void RemoveKey()
    // {
    //     collectableKeys--;
    // }

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

    public void AddCollectedKey(Sprite collectedKey)
    {
        for (int i = 0; i < availableKeys.Length; i++)
        {
            if (collectedKey == availableKeys[i])
            {
                keyTracker[i].GetComponent<UnityEngine.UI.Image>().sprite = collectedKey;
            }
        }
    }

    public void UnlockLock(Sprite key)
    {
       for (int i = 0; i < availableKeys.Length; i++)
       {
           if (key == availableKeys[i])
           {
               availableLocks[i].UnlockLock();
           }
       }
    }
}
