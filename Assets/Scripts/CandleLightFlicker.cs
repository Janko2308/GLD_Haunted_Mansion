using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLightFlicker : MonoBehaviour
{
    private Light candleLight;
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.5f;
    public float flickerSpeed = 0.1f;

    void Start()
    {
        candleLight = GetComponent<Light>();
    }

    void Update()
    {
        // Randomly change the light intensity to simulate flickering
        float noise = Mathf.PerlinNoise(Time.time * flickerSpeed, 0);
        candleLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
    }
}
