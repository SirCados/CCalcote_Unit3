using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLight : MonoBehaviour
{
    public GameObject HazardLight;
    bool _isLightActive = false;
    public float BlinkFrequency = 0.15f;

    private void Start()
    {
        InvokeRepeating("EnableLight", BlinkFrequency, BlinkFrequency);
    }


    void EnableLight()
    {
        _isLightActive = !_isLightActive;
        HazardLight.SetActive(_isLightActive);
    }
}
