using UnityEngine;

internal static class Game
{
    public const float MAX_CHARGE = 100;
    public const float MIN_CHARGE = 0;

    public static int highestLevelPassed = 0;
    public static Level level;
    private static int score;
    private static float charge;

    public static int CurrentLevel = 1;
    public static GameObject lastConnectedObject;
    public static bool isConnected = false;

    public static float Charge
    {
        get { return charge; }
        set 
        {
            charge = Mathf.Clamp(value, MIN_CHARGE, MAX_CHARGE);
        }
    }

    public static int Score { 
        get { return score; } 
        set
        {
            if (value == score)
                return;

            if (value < 0)
            {
                score = 0;
                return;
            }

            score = value;
        }
    }

    public static bool IsAlive { get; private set; }

    static Game()
    {
        Start();
    }

    public static void Start()
    {
        Score = 0;
        Charge = MAX_CHARGE;
        IsAlive = true;
    }

    public static void Died()
    {
        IsAlive = false;
    }
}
