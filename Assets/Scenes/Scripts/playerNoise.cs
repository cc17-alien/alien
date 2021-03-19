using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerNoise : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public float noise;
    public float speed;
    public float lastMovement;

    public float speedThresholdVeryLow;
    public float speedThresholdLow;
    public float speedThresholdMed;
    public float speedThresholdHigh;
    public float speedThresholdVeryHigh;
    private Vector3 lastPosition;

    void Start()
    {
        StartCoroutine(AdjustNoise(true));
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
        // Debug.Log(distance + " | " + lastPosition + " | " + coordinates);
        lastPosition = coordinates;

        return distance;
    }

    IEnumerator AdjustNoise(bool start = false)
    {
        if (start)
        {
            yield return new WaitForSeconds(9);
            lastPosition = transform.position;
        }

        yield return new WaitForSeconds(1);
        
        
        if(lastPosition.y == 0){
            float tilt = GetTilt();
            float speed = GetDistance();
       

            int movement = speed <= (speedThresholdVeryLow * 0.01) ? 0 :
                        speed <= (speedThresholdLow * 0.01) ? 5 :
                        speed <= (speedThresholdMed * 0.01) ? 10 :
                        speed <= (speedThresholdHigh * 0.01) ? 20 :
                        speed <= (speedThresholdVeryHigh * 0.01) ? 50 : 100;

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
        }
        else
        {
            lastPosition = transform.position;
        }
        StartCoroutine(AdjustNoise());
    }
}
