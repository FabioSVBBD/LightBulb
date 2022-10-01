using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    LifeCycleManager lifeCycleManager;

    private void Awake()
    {
        lifeCycleManager = LifeCycleManager.Instance();
    }

    public void onPause()
    {
        // For testing purpose, go to gameover, but should go to paused state
        lifeCycleManager.State = LifeCycleManager.LifeCycleState.GameOver;
    }
}
