using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienMovement : MonoBehaviour
{
    public float speed;
    playerNoise playerNoise;
    GameObject previousPlayer;
    private int circleCount = 0;
    private float radius = 10f;
    private float currentAngle = 0f;
    private float chaseThreashhold = 8.5f;
    private int noiseThreshhold = 500;
    private int circleLimit = 30;

    void Update()
    {
        GameObject[] arrayOfPlayerObjects = GameObject.FindGameObjectsWithTag("Player");
        float previousPlayerAggro = 0f;
        float playerAggro;
        float chaseDistance = 0f;

        foreach (GameObject player in arrayOfPlayerObjects)
        {
            playerNoise = player.GetComponent<playerNoise>();
            float distance = Vector3.Distance(
                transform.position, player.transform.position);
            playerAggro = playerNoise.noise + 1 / distance;

            if (playerAggro > previousPlayerAggro)
            {
                previousPlayerAggro = playerAggro;
                previousPlayer = player;
                chaseDistance = distance;
            }
        }

        if (circleCount == 0)
        {
            if (chaseDistance <= chaseThreashhold &&
                previousPlayer.GetComponent<playerNoise>().noise <= noiseThreshhold)
            {
                StartCoroutine(CirclePlayer(previousPlayer));
            }
            else
            {
                Vector3 destination = previousPlayer.transform.position;
                transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);      
            }
        }
        else
        {
            currentAngle += Time.deltaTime * speed;
            if (circleCount >= (circleLimit / 3))
            {
                float expand = (circleCount / circleLimit);
                float x = radius * Mathf.Sin(currentAngle / expand);
                float z = radius * Mathf.Cos(currentAngle / expand);
                Vector3 circleDestination = new Vector3(x, 0, z) + transform.position;
                transform.position = Vector3.MoveTowards(transform.position, circleDestination, Time.deltaTime * speed);
            }
        }
    }

    IEnumerator CirclePlayer(GameObject player)
    {
        circleCount += 1;

        yield return new WaitForSeconds(1);

        if (circleCount >= circleLimit || player != previousPlayer)
        {
            circleCount = 0;
        }
        else
        {
            StartCoroutine(CirclePlayer(player));
        }
    }
}