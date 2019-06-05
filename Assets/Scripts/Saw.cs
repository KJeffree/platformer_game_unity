using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{

    [SerializeField] Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.rotation = -45f;
    }

    void FixedUpdate()
    {
        rigidBody.rotation -= 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
