using UnityEngine;

public class GameManager : MonoBehaviour
{
	private LifeCycleManager lifeCycleManager;
	private GameManager gameManager;

	[SerializeField] GameObject Player;
	[SerializeField] TMPro.TMP_Text scoreField;
	[SerializeField] GameObject PauseMenu;

	[SerializeField] GameObject Roof;
	[SerializeField] GameObject Background;
	[SerializeField] GameObject Floor;

	[SerializeField] LevelMaterial[] materials = new LevelMaterial[5];

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

    private void Start()
    {
		int index = Game.CurrentLevel <= 0 || Game.CurrentLevel > 6 ? 0 : Game.CurrentLevel - 1;

		Roof.GetComponent<Renderer>().material = materials[index].Roof;
		Background.GetComponent<Renderer>().material = materials[index].Background;
		Floor.GetComponent<Renderer>().material = materials[index].Floor;
    }

    private void Update()
	{
		if (Game.Charge == Game.MIN_CHARGE && !IsGamePaused)
        {
			GlowbCollided();
        }

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!IsGamePaused)
				GamePaused();
			else
				GameResumed();
		}

		Game.Score = (int)Player.transform.position.x;
		scoreField.text = Game.Score.ToString();

		if (Game.lastConnectedObject != null && Game.isConnected && Game.lastConnectedObject == Roof && !IsGamePaused)
		{
			Game.Charge += 0.1f;
		} else
        {
			Game.Charge -= 0.05f;
        }

		// TODO:: Update the glowb light as per charge left

		Debug.Log($"Charge left: {Game.Charge}");
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

		lifeCycleManager.AtLevel = false;

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
		Time.timeScale = 1;
		lifeCycleManager.AtLevel = true;
		lifeCycleManager.State = LifeCycleManager.LifeCycleState.Landed;
	}

	public void QuitClicked()
	{
		Time.timeScale = 1;
		lifeCycleManager.AtLevel = false;
		Debug.Log($"Life cycle manager {lifeCycleManager.AtLevel}");
		lifeCycleManager.State = LifeCycleManager.LifeCycleState.Landed;
	}

	public void onRestart()
	{
		// clickSound.Play();
		// SoundManager.Instance.PlaySound(_clip);
		lifeCycleManager.State = LifeCycleManager.LifeCycleState.Playing;
		Game.level = Level.CreateLevel(Game.CurrentLevel);
	}
}
