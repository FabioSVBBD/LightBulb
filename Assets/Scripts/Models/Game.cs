using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Game
{
    private int score;

    public int Score { get { return score; } set
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

    public bool IsAlive { get; private set; }

    public Game()
    {
        Score = 0;
        IsAlive = true;
    }

    public void Died()
    {
        IsAlive = false;
    }
}
