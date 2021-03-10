using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerNoise : MonoBehaviour
{
    // Start is called before the first frame update
    public float noise;
    void Start()
    {
        StartCoroutine(NoiseReduction());
    }

    // Update is called once per frame
    void Update()
    {

    }

    float GetTilt()
    {
        Vector3 dir = Vector3.zero;

        dir.x = Input.acceleration.x;
        dir.z = Input.acceleration.z;

        dir *= Time.deltaTime;

        return Math.Abs(dir.x) + Math.Abs(dir.z);
    }

    IEnumerator NoiseReduction()
    {
        yield return new WaitForSeconds(1);

        float tilt = GetTilt();

        if (tilt < 0.005 && noise > 0)
        {
            noise -= 1;
        }

        StartCoroutine(NoiseReduction());
    }
}
