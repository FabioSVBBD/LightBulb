internal static class Game
{
    public static Level level;
    private static int score;
    public static int CurrentLevel = 1;

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
        IsAlive = true;
    }

    public static void Died()
    {
        IsAlive = false;
    }
}
