using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycleManager
{
    public enum LifeCycleState
    {
        Landed, Playing, GameOver
    }

    private LifeCycleState _state;
    public LifeCycleState State
    {
        get { return _state; }
        set
        {
            if (_state != value)
            {
                _state = value;
                SceneLoader.LoadScene(GetScene());
            }
        }
    }

    private Dictionary<LifeCycleState, string> StateSceneMap { get; set; }

    public string GetScene()
    {
        string scene = StateSceneMap[State];

        if (scene == null)
        {
            throw new Exception($"Scene not defined for all game states. Reading: GameState.{State}");
        }

        return scene;
    }

    private static LifeCycleManager instance;
    public static LifeCycleManager Instance()
    {
        if (instance == null)
        {
            instance = new LifeCycleManager();
        }

        return instance;
    }

    private LifeCycleManager()
    {
        State = LifeCycleState.Landed;

        StateSceneMap = new Dictionary<LifeCycleState, string>()
        {
            { LifeCycleState.Landed, "Home" },
            { LifeCycleState.Playing, "Game" },
            { LifeCycleState.GameOver, "GameOver" }
        };
    }
}
