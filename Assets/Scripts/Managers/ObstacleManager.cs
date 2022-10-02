using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] prefabs = new GameObject[3];

    GameObject prefab;
    Transform latestObstacle;
    GameObject prefabClone;

    void Start()
    {
        SpawnObject(player.transform.position.x, player.transform.position.y);
    }

    void Update()
    {
        if (player.transform.position.x - latestObstacle.transform.position.x > 5f)
        {
            SpawnObject(player.transform.position.x, player.transform.position.y);
        }
    }

    public void SpawnObject(float lightPosX, float lightPosY){
        int prefabIndex = Random.Range(0, 3);
        prefab = prefabs[prefabIndex];
        
        prefabClone = Instantiate(prefab, new Vector3(lightPosX+15f, Random.Range(lightPosY-5f, lightPosY+5f), -1f), Quaternion.identity);
        prefabClone.transform.localScale = new Vector2(Random.Range(1f, 3f), Random.Range(1f, 3f));
        latestObstacle = prefabClone.transform;
    }
}
