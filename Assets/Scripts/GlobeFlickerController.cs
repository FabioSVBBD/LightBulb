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
    float intensityThreshold;
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
        intensityThreshold = baseIntensity - delta/100;
 
    }

    void Update()
    {

        if(_grapple.IsAttached()){
            if(myLight.range < baseRange)
            {
                myLight.range += delta / 100;
            }
            myLight.intensity = baseIntensity;
            
        }
        else{
            // myLight.intensity = Random.Range(0f, 10f);
            if (myLight.intensity - random < myLight.intensity - intensityThreshold)
            {
                random = Random.Range(pLower, pUpper);
                myLight.intensity = Mathf.PingPong(Time.time * random, delta) + lowerBound;
                
            }
            else
            {
                myLight.intensity -= delta / 50;
            }
            
            
        }
    }
}
