using UnityEngine;

public class HomeManager : MonoBehaviour
{
    LifeCycleManager lifeCycleManager;
    [SerializeField] private AudioClip _clip;

    private void Awake()
    {
        lifeCycleManager = LifeCycleManager.Instance();
    }

    public void onStart()
    {
        SoundManager.Instance.PlaySound(_clip);
        lifeCycleManager.State = LifeCycleManager.LifeCycleState.LevelSelection;
    }
}
