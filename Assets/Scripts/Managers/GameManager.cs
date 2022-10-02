using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private LifeCycleManager lifeCycleManager;
    private GameManager gameManager;
    private Game game;

    [SerializeField] GameObject Player;
    [SerializeField] TMPro.TMP_Text scoreField;
    [SerializeField] GameObject PauseMenu;

    private bool IsGamePaused{ get; set; }

    private void Awake()
    {
        IsGamePaused = false;
        gameManager = this;
        game = new Game();
        lifeCycleManager = LifeCycleManager.Instance();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!IsGamePaused)
                GamePaused();
            else
                GameResumed();
        }

        game.Score = (int)Player.transform.position.x;
        scoreField.text = game.Score.ToString();
    }

    public void GlowbCollided()
    {
        if (game.IsAlive)
            gameManager.GameOver();
    }

    public void GamePaused()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        IsGamePaused = true;
    }

    public void GameResumed()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        IsGamePaused = false;

    }

    public void GameOver()
    {
        Debug.Log($"Score: {game.Score}");


        Time.timeScale = 0;
        game.Died();
        lifeCycleManager.State = LifeCycleManager.LifeCycleState.GameOver;
    }

    
}
