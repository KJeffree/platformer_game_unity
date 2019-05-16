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

    [SerializeField] GameObject[] healthTracker;

    [SerializeField] Sprite[] availableHealth;

    [SerializeField] int currentHeartIndex = 0;

    [SerializeField] int healthReduced = 0;

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

    public void CheckCurrentHeart()
    {
        if (healthReduced <= 2)
        {
            currentHeartIndex = 0;
        }
        if (healthReduced > 2 && healthReduced <= 5)
        {
            currentHeartIndex = 1;
        }
        if (healthReduced > 5)
        {
            currentHeartIndex = 2;
        }
    }

    public void ReduceHealth()
    {
        healthReduced++;
        CheckCurrentHeart();
        ChangeHeartSprite();

    }

    private void ChangeHeartSprite()
    {
        Sprite currentHeart = healthTracker[currentHeartIndex].GetComponent<UnityEngine.UI.Image>().sprite;
        if (currentHeart == availableHealth[0])
        {
            healthTracker[currentHeartIndex].GetComponent<UnityEngine.UI.Image>().sprite = availableHealth[1];
        }
        else if (currentHeart == availableHealth[1])
        {
            healthTracker[currentHeartIndex].GetComponent<UnityEngine.UI.Image>().sprite = availableHealth[2];

        }
    }
}
