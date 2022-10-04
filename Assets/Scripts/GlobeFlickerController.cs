using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeFlickerController : MonoBehaviour
{
    Light myLight;
    GrappleScript _grapple;
    float baseIntensity;
    float baseRange;
    float lowerBound;
    public float delta;
    public float pLower;
    public float pUpper;
    private float random;
   
    void Awake(){
        _grapple = GameObject.Find("Player").GetComponent<GrappleScript>();
    }

    void Start()
    {
        myLight = GetComponent<Light>();
        baseIntensity = myLight.intensity;
        baseRange = myLight.range;
        lowerBound = baseIntensity - delta;
 
    }

    void Update()
    {

        if(_grapple.IsAttached()){
            myLight.intensity = baseIntensity;
            myLight.range = baseRange;
        }
        else{
            // myLight.intensity = Random.Range(0f, 10f);
            random = Random.Range(pLower, pUpper);
            myLight.range = myLight.range - delta/1000;
            myLight.intensity = Mathf.PingPong(Time.time*random, delta) + lowerBound;
        }
    }
}
