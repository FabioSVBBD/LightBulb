using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour
{

    private Material m_Material;

    void Start()
    {
        m_Material = GetComponent<Renderer>().material;
        m_Material.SetColor("_Color", Color.white);
    }

    void OnMouseOver()
    {

        // Change the Color of the GameObject when the mouse hovers over it
        m_Material.SetColor("_EmissionColor", Color.white);
        m_Material.EnableKeyword("_EMISSION");

    }

    void OnMouseExit()
    {
        //Change the Color back to white when the mouse exits the GameObject
        m_Material.SetColor("_EmissionColor", Color.black);
    }

}
