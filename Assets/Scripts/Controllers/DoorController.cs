using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] GameObject leftDoor;
    [SerializeField] GameObject rightDoor;
    [SerializeField] GameObject mainCamera;

    public float speed;
    public float open_x;

    private bool isOpening;
    private Vector3 leftStartPos;
    private Vector3 rightStartPos;

    private Material m_Material;


    private void Start()
    {
        leftStartPos = leftDoor.transform.position;
        rightStartPos = rightDoor.transform.position;
        Debug.Log(leftStartPos);
        m_Material = GetComponent<Renderer>().material;
        m_Material.SetColor("_Color", Color.white);
    }
    void Update()
    {
        if (isOpening && leftDoor.transform.position.x > -open_x)
        {
            leftDoor.transform.Translate(Vector3.left * Time.deltaTime * speed);
            rightDoor.transform.Translate(Vector3.right * Time.deltaTime * speed);
            mainCamera.transform.Translate(Vector3.forward * Time.deltaTime * speed * 12.5f);
        }
        if(leftDoor.transform.position.x <= -open_x && rightDoor.transform.position.x >= open_x)
        {
            isOpening = false;
        }
        
    }

    private void OnMouseDown()
    {
        isOpening = true;
        
    }

    void OnMouseOver()
    {

        // Change the Color of the GameObject when the mouse hovers over it
        m_Material.SetColor("_EmissionColor", Color.white);
        m_Material.EnableKeyword("_EMISSION");

    }

    void OnMouseExit()
    {
        if(!isOpening)
            m_Material.SetColor("_EmissionColor", Color.black);
    }
}
