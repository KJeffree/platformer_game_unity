﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int collectableGems;

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
}
