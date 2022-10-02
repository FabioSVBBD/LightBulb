/* A level has obstacles, and a frequency at which the obstacles are sent */
using System.Collections.Generic;

using UnityEngine;

internal class Level
{
    public Stack<Obstacle> Obstacles; // The obstacle the user will have to avoid
    public double Latency; // The latency between two of the obstacles

    public Level(Stack<Obstacle> obstacles, double latency = 5)
    {
        if (obstacles != null)
            Obstacles = obstacles;

        Latency = latency;
    }

    public static Level CreateLevel1()
    {
        double latency = 10;
        int levelLength = 1;
        Stack<Obstacle> obstacles = new Stack<Obstacle>();

        for (int i = 0; i < levelLength; i++)
        {
            obstacles.Push(new Obstacle(2, 2, 3)); // TODO
        }

        return new Level(obstacles, latency);
    }

    public static Level CreateLevel2()
    {
        double latency = 7;
        int levelLength = 15;
        Stack<Obstacle> obstacles = new Stack<Obstacle>();

        for (int i = 0; i < levelLength; i++)
        {
            int width = UnityEngine.Random.Range(2, 4);
            int height = Random.Range(2, 4);
            int y = height == 3 ? 4 : 3; // fkn random

            obstacles.Push(new Obstacle(width, height, y));
        }

        return new Level(obstacles, latency);
    }

    public static Level CreateLevel3()
    {
        double latency = 6;
        int levelLength = 20;
        Stack<Obstacle> obstacles = new Stack<Obstacle>();

        for (int i = 0; i < levelLength; i++)
        {
            int width = UnityEngine.Random.Range(2, 4);
            int height = Random.Range(2, 4);
            int y = Random.Range(0, 5); // fkn random

            obstacles.Push(new Obstacle(width, height, y));
        }

        return new Level(obstacles, latency);
    }

    public static Level CreateEndlessMode()
    {
        // TODO: prob a flag
        return CreateLevel2();
    }

    public static Level CreateLevel(int index)
    {
        Game.CurrentLevel = index;

        return index switch
        {
            1 => CreateLevel1(),
            2 => CreateLevel2(),
            3 => CreateLevel3(),
            _ => CreateEndlessMode(),
        };
    }
}
