using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonsController : MonoBehaviour
{
	[SerializeField] LevelsManager lm;
	[SerializeField] private AudioClip _activeClip;
	[SerializeField] private AudioClip _disabledClip;
	public int level;

	private Material m_Material;

	private void Start()
	{
		m_Material = GetComponent<Renderer>().material;

		if (Game.highestLevelPassed + 1 >= level)
		{
			Debug.Log($"Highest level passed: {Game.highestLevelPassed}");

			m_Material.SetColor("_EmissionColor", Color.white);
			m_Material.EnableKeyword("_EMISSION");
		}
	}

	private void OnMouseOver()
	{
		if (Game.highestLevelPassed + 1 >= level)
		{
			m_Material.SetColor("_EmissionColor", new Color(0.5f, 0.5f, 0.5f, 1.0f));
		}
	}

	void OnMouseExit()
	{
		if (Game.highestLevelPassed + 1 >= level)
		{
			m_Material.SetColor("_EmissionColor", Color.white);
		}
	}


	void OnMouseDown()
	{
		if (Game.highestLevelPassed + 1 >= level)
		{
			SoundManager.Instance.PlaySound(_activeClip);
			lm.LevelSelected(level);
		}
		else
		{
			SoundManager.Instance.PlaySound(_disabledClip);
		}
	}
}
