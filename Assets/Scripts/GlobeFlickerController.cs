using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeFlickerController : MonoBehaviour
{
    Light myLight;
    GrappleScript _grapple;

    void Awake(){
        _grapple = GameObject.Find("Player").GetComponent<GrappleScript>();
    }

    void Start()
    {
        myLight = GetComponent<Light>();
    }

    void Update()
    {
        if(_grapple.IsAttached()){
            myLight.intensity = 9;
        }
        else{
            myLight.intensity = Random.Range(0f, 10f);
            // myLight.intensity = Mathf.PingPong(Time.time-0.2f, 10);
        }
    }
}
