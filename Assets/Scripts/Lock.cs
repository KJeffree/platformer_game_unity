﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public void UnlockLock()
    {
        Destroy(gameObject);
    }
}
