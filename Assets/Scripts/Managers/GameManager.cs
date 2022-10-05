using UnityEngine;

public class GameManager : MonoBehaviour
{
    private LifeCycleManager lifeCycleManager;
    private GameManager gameManager;

    [SerializeField] GameObject Player;
    [SerializeField] TMPro.TMP_Text scoreField;
    [SerializeField] GameObject PauseMenu;

    private bool IsGamePaused;

    private void Awake()
    {
        IsGamePaused = false;
        gameManager = this;
        lifeCycleManager = LifeCycleManager.Instance();

        if (Game.level == null)
        {
            Game.level = Level.CreateLevel(Game.CurrentLevel);
        }

        Game.Start();
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsGamePaused)
                GamePaused();
            else
                GameResumed();
        }

        Game.Score = (int)Player.transform.position.x;
        scoreField.text = Game.Score.ToString();
    }

    public void GlowbCollided()
    {
        if (Game.IsAlive)
        {
            Player.SetActive(false);
            Invoke("GameOver", 2f);
        }
         
    }

    public void GamePaused()
    {
        Player.GetComponent<GrappleInputManager>().enabled = false;
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        IsGamePaused = true;
    }

    public void GameResumed()
    {

        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        IsGamePaused = false;
        Player.GetComponent<GrappleInputManager>().enabled = true;

    }

    public void GameOver()
    {
        Player.GetComponent<GrappleInputManager>().enabled = false;
        Time.timeScale = 0;
        Game.Died();
        lifeCycleManager.State = LifeCycleManager.LifeCycleState.GameOver;
    }

    public void NextClicked()
    {
        Game.level = Level.CreateLevel(Game.CurrentLevel + 1); // yea not good but whatever. This will support 2billion levels
        // Reload scene with new level (does cleanup)
        SceneLoader.LoadScene(lifeCycleManager.GetScene());
    }

    public void LevelsClicked()
    {
        lifeCycleManager.State = LifeCycleManager.LifeCycleState.LevelSelection;
    }
    
    public void QuitClicked()
    {
        Time.timeScale = 1;
        lifeCycleManager.State = LifeCycleManager.LifeCycleState.Landed;
    }
}
