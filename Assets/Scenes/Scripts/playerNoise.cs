using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerNoise : MonoBehaviour
{
    // Start is called before the first frame update
    public float noise;
    private Vector3 lastPosition;
    private float lastMovement = 0;

    void Start()
    {
        lastPosition = transform.position;
        StartCoroutine(AdjustNoise());
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

    float GetDistance() {

        Vector3 coordinates = transform.position;
        float distance = Vector3.Distance(lastPosition, coordinates);
        lastPosition = coordinates;

        return distance;
    }

    IEnumerator AdjustNoise()
    {
        yield return new WaitForSeconds(1);

        float tilt = GetTilt();
        float speed = GetDistance();

        int movement = speed <= 0.5 ? 0 :
                       speed <= 2.5 ? 5 :
                       speed <= 5.0 ? 10 :
                       speed <= 8.0 ? 20 :
                       speed <= 12.0 ? 50 : 100;

        noise = (noise - lastMovement) + Math.Max(movement, lastMovement);

        if (movement >= lastMovement)
        {
            lastMovement = movement;
        }
        else if (lastMovement >= 5)
        {
            lastMovement -= 5;
        }

        if (tilt < 0.01 && noise > 0 && speed < 0.5)
        {
            float modifier = Math.Min(100 / (tilt * 10000), 10);
            noise -= modifier;
        }

        StartCoroutine(AdjustNoise());
    }
}
