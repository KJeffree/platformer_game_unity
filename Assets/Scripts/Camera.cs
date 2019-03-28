using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float playerPosX = Mathf.Clamp(player.transform.position.x, 9, 41);
        transform.position = new Vector3(playerPosX, transform.position.y, transform.position.z);
        
    }
}
