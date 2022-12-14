using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
	[SerializeField] GameObject player;
	[SerializeField] GameObject prefab;
	[SerializeField] GameObject finishLine;
	[SerializeField] GameObject completionPanel;
	[SerializeField] LevelMaterial[] levelMaterials = new LevelMaterial[5];

	Transform latestObstacle;
	GameObject obstacle;

	private bool IsFinishing = false;

	void Start()
	{
		if (Game.level.Latency > 0)
		{
			int index = Game.CurrentLevel <= 0 || Game.CurrentLevel > 6 ? 0 : Game.CurrentLevel - 1;
			prefab.GetComponent<Renderer>().material = levelMaterials[index].Obstacle;
			SpawnObject(player.transform.position.x);
			return;
		}
	}

	void Update()
	{
		if (IsFinishing)
		{
			if (latestObstacle.transform.position.x <= player.transform.position.x)
			{
				completionPanel.SetActive(true);

				if (Game.highestLevelPassed < Game.CurrentLevel)
					Game.highestLevelPassed = Game.CurrentLevel;

				IsFinishing = false;
				Time.timeScale = 0;
			}

			return;
		}

		if ((latestObstacle != null && player.transform.position.x - latestObstacle.transform.position.x > Game.level.Latency) || (latestObstacle == null && player.transform.position.x >= 30f))
		{
			if (Game.level.Obstacles.Count == 0 && !Game.level.Infinite)
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

		if (Game.level.Infinite)
		{
			Obstacle infiniteObstacle = new Obstacle(Random.Range(1, 4), Random.Range(1, 3), Random.Range(-1, 6));


			obstacle = Instantiate(prefab, new Vector3(lightPosX + 15, infiniteObstacle.YPos, 0), Quaternion.identity);
			obstacle.transform.localScale = new Vector3(infiniteObstacle.Width, infiniteObstacle.Height, 10);

			latestObstacle = obstacle.transform;
			return;
		}


		if (Game.level.Obstacles.Count > 0)
		{
			Obstacle newObstacle = Game.level.Obstacles.Pop();

			obstacle = Instantiate(prefab, new Vector3(lightPosX + 15, newObstacle.YPos, 0), Quaternion.identity);
			obstacle.transform.localScale = new Vector3(newObstacle.Width, newObstacle.Height, 6);

			latestObstacle = obstacle.transform;
		}

	}

	public void SpawnFinishLine(float lightPosX)
	{
		obstacle = Instantiate(finishLine, new Vector3(lightPosX + 15, finishLine.transform.position.y, -1), Quaternion.identity);
		latestObstacle = obstacle.transform;
	}
}
