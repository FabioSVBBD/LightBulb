using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonsController : MonoBehaviour
{
    [SerializeField] LevelsManager lm;
    [SerializeField] private AudioClip _activeClip;
    [SerializeField] private AudioClip _disabledClip;
    public int level;
    public bool active;

    private Material m_Material;

    private void Start()
    {
        m_Material = GetComponent<Renderer>().material;

        if (active)
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
        if (active)
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
