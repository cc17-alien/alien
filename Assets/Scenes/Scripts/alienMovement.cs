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
    float radius = 4f;
    float currentAngle = 0f;

    void Update()
    {
        GameObject[] arrayOfPlayerObjects = GameObject.FindGameObjectsWithTag("Player");
        float previousPlayerAggro = 0;
        float playerAggro;
        float chaseDistance = 0;

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
            if (chaseDistance <= 8.5 &&
                previousPlayer.GetComponent<playerNoise>().noise <= 500)
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
            int dirMod = circleCount % 2 == 0 ? -1 : 1;
            float x = radius * Mathf.Sin(currentAngle * dirMod);
            float z = radius * Mathf.Cos(currentAngle * dirMod);
            transform.position = new Vector3 (x, 0, z);
        }
    }

    IEnumerator CirclePlayer(GameObject player)
    {
        circleCount += 1;

        yield return new WaitForSeconds(1);

        if (circleCount >= 10 || player != previousPlayer)
        {
            circleCount = 0;
        }
        else
        {
            StartCoroutine(CirclePlayer(player));
        }
    }
}