using UnityEngine;

public class LevelsManager : MonoBehaviour
{
    LifeCycleManager lifeCycleManager;
    [SerializeField] private AudioClip _clip;

    private void Awake()
    {
        lifeCycleManager = LifeCycleManager.Instance();
    }

    public void LevelSelected(int level)
    {
        SoundManager.Instance.PlaySound(_clip);
        Game.level = Level.CreateLevel(level);
        lifeCycleManager.State = LifeCycleManager.LifeCycleState.Playing;

    }
}
