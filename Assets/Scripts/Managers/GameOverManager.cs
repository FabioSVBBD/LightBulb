using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    LifeCycleManager lifeCycleManager;

    private void Awake()
    {
        lifeCycleManager = LifeCycleManager.Instance();
    }

    public void onHome()   
    {
        lifeCycleManager.State = LifeCycleManager.LifeCycleState.Landed;
    }

    public void onRestart()
    {
        lifeCycleManager.State = LifeCycleManager.LifeCycleState.Playing;
    }
}
