using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject finishLine;
    [SerializeField] GameObject completionPanel;

    Transform latestObstacle;
    GameObject obstacle;

    private bool IsFinishing = false;

    void Start()
    {
        SpawnObject(player.transform.position.x);
    }

    void Update()
    {
        if (IsFinishing)
        {
            if (latestObstacle.transform.position.x <= player.transform.position.x)
            {
                completionPanel.SetActive(true);
                IsFinishing = false;
                Time.timeScale = 0;
            }

            return;
        }

        if (player.transform.position.x - latestObstacle.transform.position.x > Game.level.Latency)
        {
            if (Game.level.Obstacles.Count == 0)
            {
                SpawnFinishLine(player.transform.position.x);
                IsFinishing = true;
                return;
            }

            SpawnObject(player.transform.position.x);
        }
    }

    public void SpawnObject(float lightPosX)
    {
        Obstacle newObstacle = Game.level.Obstacles.Pop();

        obstacle = Instantiate(prefab, new Vector3(lightPosX + 15, newObstacle.YPos, -1), Quaternion.identity);
        obstacle.transform.localScale = new Vector2(newObstacle.Width, newObstacle.Height);
        
        latestObstacle = obstacle.transform;
    }

    public void SpawnFinishLine(float lightPosX)
    {
        obstacle = Instantiate(finishLine, new Vector3(lightPosX + 15, finishLine.transform.position.y, -1), Quaternion.identity);
        latestObstacle = obstacle.transform;
    }
}
