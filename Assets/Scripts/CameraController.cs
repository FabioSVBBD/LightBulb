using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private float originalCameraX ;

    void Start()
    {
        originalCameraX = Camera.main.transform.position.x; 
    }

    void Update()
    {
        if (player.transform.position.x > originalCameraX)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
