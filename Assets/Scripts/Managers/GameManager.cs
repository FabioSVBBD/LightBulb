using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	private LifeCycleManager lifeCycleManager;
	private GameManager gameManager;

	[SerializeField] GameObject Player;
	[SerializeField] TMPro.TMP_Text scoreField;
	[SerializeField] GameObject PauseMenu;
	[SerializeField] GameObject GameOverMenu;
	[SerializeField] GameObject fadePanel;
	[SerializeField] TMPro.TMP_Text finalScoreText;

	[SerializeField] GameObject Roof;
	[SerializeField] GameObject Background;
	[SerializeField] GameObject Floor;

	[SerializeField] LevelMaterial[] materials = new LevelMaterial[5];

	private bool IsGamePaused;
	private float currentAlpha;

	private void UpdateImageAlpha(float alpha)
    {
		Image image = fadePanel.GetComponent<Image>();
		var temp = image.color;
		temp.a = alpha;
		image.color = temp;
		currentAlpha = image.color.a;

		if (currentAlpha <= 0)
        {
			fadePanel.SetActive(false);
			Time.timeScale = 1;
		}

			
	}

	private void Awake()
	{
		currentAlpha = 1;
		Image image = fadePanel.GetComponent<Image>();
		UpdateImageAlpha(currentAlpha);

		IsGamePaused = false;
		gameManager = this;
		lifeCycleManager = LifeCycleManager.Instance();

		if (Game.level == null)
		{
			Game.level = Level.CreateLevel(Game.CurrentLevel);
		}

		Game.Start();
		Time.timeScale = 0;
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
		if (currentAlpha > 0)
        {
			UpdateImageAlpha(currentAlpha - 0.02f);
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
	}

	public void GlowbCollided()
	{
		if (Game.IsAlive)
		{
			Player.SetActive(false);
			Invoke("GameOver", 1f);
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

		scoreField.enabled = false;
		finalScoreText.text = Game.Score.ToString();
		GameOverMenu.SetActive(true);
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
