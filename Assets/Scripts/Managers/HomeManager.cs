using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    LifeCycleManager lifeCycleManager;

    private void Awake()
    {
        lifeCycleManager = LifeCycleManager.Instance();
    }

    public void onStart()
    {
        lifeCycleManager.State = LifeCycleManager.LifeCycleState.LevelSelection;
    }
}
