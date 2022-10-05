using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    LifeCycleManager lifeCycleManager;
    // public AudioSource clickSound;
    [SerializeField] private AudioClip _clip;

    private void Awake()
    {
        lifeCycleManager = LifeCycleManager.Instance();
    }

    public void onHome()
    {
        //clickSound.Play();
        Time.timeScale = 1;
        SoundManager.Instance.PlaySound(_clip);
        lifeCycleManager.State = LifeCycleManager.LifeCycleState.Landed;
    }

    public void onRestart()
    {
        // clickSound.Play();
        SoundManager.Instance.PlaySound(_clip);
        lifeCycleManager.State = LifeCycleManager.LifeCycleState.Playing;
        Game.level = Level.CreateLevel(Game.CurrentLevel);
    }
}
