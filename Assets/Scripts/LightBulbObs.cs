using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulbObs : MonoBehaviour
{

    Rigidbody2D _rb;
    [SerializeField] ObstacleBehaviour obstacle;
    float _inputHorizontal;
    float _inputVertical;

    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        obstacle.SpawnObject(transform.position.x, transform.position.y);
    }

    void Update()
    {
        Transform latestObstacle = obstacle.getLatestObstacle();
        if(transform.position.x - latestObstacle.transform.position.x > 5f){
            obstacle.SpawnObject(transform.position.x, transform.position.y);
        }
    }
}
