using UnityEngine;

public class LevelsManager : MonoBehaviour
{
    LifeCycleManager lifeCycleManager;

    private void Awake()
    {
        lifeCycleManager = LifeCycleManager.Instance();
    }

    public void LevelSelected(int level)
    {
        Game.level = Level.CreateLevel(level);
        lifeCycleManager.State = LifeCycleManager.LifeCycleState.Playing;

    }
}
