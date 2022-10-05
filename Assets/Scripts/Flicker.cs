using UnityEngine;
using System.Collections.Generic;

// Written by Steve Streeting 2017
// License: CC0 Public Domain http://creativecommons.org/publicdomain/zero/1.0/

/// <summary>
/// Component which will flicker a linked light while active by changing its
/// intensity between the min and max values given. The flickering can be
/// sharp or smoothed depending on the value of the smoothing parameter.
///
/// Just activate / deactivate this component as usual to pause / resume flicker
/// </summary>
public class Flicker : MonoBehaviour
{
    [Tooltip("External light to flicker; you can leave this null if you attach script to a light")]
    private Material mat;
    [Tooltip("Minimum random light intensity")]
    public float minIntensity = -0.7f;
    [Tooltip("Maximum random light intensity")]
    public float maxIntensity = 0f;
    [Tooltip("How much to smooth out the randomness; lower values = sparks, higher = lantern")]
    [Range(1, 1000)]
    public int smoothing = 1000;
    private Color col;
    public float intensity;

    // Continuous average calculation via FIFO queue
    // Saves us iterating every time we update, we just change by the delta
    Queue<float> smoothQueue;
    float lastSum = 0;

    bool increasing;


    /// <summary>
    /// Reset the randomness and start again. You usually don't need to call
    /// this, deactivating/reactivating is usually fine but if you want a strict
    /// restart you can do.
    /// </summary>
    public void Reset()
    {
        smoothQueue.Clear();
        lastSum = 0;
    }

    void Start()
    {
        smoothQueue = new Queue<float>(smoothing);
        // External or internal light?
        if (mat == null)
        {
            mat = GetComponent<Renderer>().material;
            col = mat.GetColor("_EmissionColor");
        }

    }

    void Update()
    {
        if (mat == null)
            return;

        if (increasing)
        {
           
            intensity += 10 * Time.deltaTime;
            if (intensity >= 255)
            {
                Debug.Log("Decrease");
                increasing = false;
            }
                
        }
        else
        {
            
            intensity -= 10 * Time.deltaTime;
            intensity -= 10 * Time.deltaTime;
            if (intensity < 0)
            {
                Debug.Log("Increase");
                increasing = true;
            }
                
        }
        Color off = new Color(intensity,intensity,intensity);

        // Calculate new smoothed average
        mat.SetColor("_EmissionColor", off);
    }

}
