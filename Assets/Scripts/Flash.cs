using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    private float time = 0.0f;
    // Start is called before the first frame update
    private void Update()
    {
        time += Time.deltaTime;

        if (time >= 7f)
        {
            time = 0f;
            Flicker();

            // execute block of code here
        }

    }
    void Flicker()
    {
        TurnOn();
        Invoke("TurnOff", 0.5f);
        Invoke("TurnOn", 0.1f);
        Invoke("TurnOff", 0.3f);
        //code here will execute after 5 seconds
    }

    void TurnOn()
    {
        gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }
    void TurnOff()
    {
        gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }
}
