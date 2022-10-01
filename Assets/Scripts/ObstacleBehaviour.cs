using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    public GameObject[] prefabs = new GameObject[3];
    Transform latestObstacle;
    GameObject prefabClone;

    Rigidbody2D _rb;
    public void SpawnObject(float lightPosX, float lightPosY){
        int prefabIndex = Random.Range(0, 3);
        prefab = prefabs[prefabIndex];
        
        prefabClone = Instantiate(prefab, new Vector3(lightPosX+20f, Random.Range(lightPosY-5f, lightPosY+5f), 0f), Quaternion.identity);
        prefabClone.transform.localScale = new Vector2(Random.Range(0f, 3f), Random.Range(0f, 3f));
        latestObstacle = prefabClone.transform;
    }

    public Transform getLatestObstacle(){
        return latestObstacle;
    }

}
