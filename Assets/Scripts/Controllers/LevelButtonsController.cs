using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonsController : MonoBehaviour
{
    [SerializeField] LevelsManager lm;
    public int level;
    public bool active;

    private Material m_Material;

    private void Start()
    {
        m_Material = GetComponent<Renderer>().material;

        if (Game.highestLevelPassed + 1 >= level)
        {
            m_Material.SetColor("_EmissionColor", Color.white);
            m_Material.EnableKeyword("_EMISSION");
        }
    }

    private void OnMouseOver()
    {

    }

    void OnMouseDown()
    {
        if(Game.highestLevelPassed + 1 >= level)
            lm.LevelSelected(level);
    }
}
