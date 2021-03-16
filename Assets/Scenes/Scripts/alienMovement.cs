using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienMovement : MonoBehaviour
{
    public float speed;
    public int noiseThreshhold;
    public int searchLimit;
    public float searchRadius;
    public float searchStartDistance;
    public int searchStopNoise;

    playerNoise playerNoise;
    GameObject targetPlayer;

    private float searchAngle = 0f;
    private int searchCount = 0;
    private float searchDistance = 0f;

    void Update()
    {
        SetSearchPlayerAndDistance();

        ProximityIndicator();

        float targetPlayerNoise = targetPlayer.GetComponent<playerNoise>().noise;

        if (searchCount == 0)
        {
            if (searchDistance <= searchStartDistance &&
                targetPlayerNoise <= searchStopNoise)
            {
                StartCoroutine(SearchCycle(targetPlayer));
            }
            else
            {
                MoveToPlayer(targetPlayerNoise);
            }
        }
        else
        {
            if (targetPlayerNoise > searchStopNoise)
            {
                StopSearchPlayer();
            }
            if (searchCount >= (searchLimit / 3))
            {
                SearchPlayer();
            }
        }
    }

    void SetSearchPlayerAndDistance()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        float targetPlayerAggro = 0f;
        float playerAggro;

        foreach (GameObject player in playerObjects)
        {
            playerNoise = player.GetComponent<playerNoise>();
            float distance = Vector3.Distance(
                transform.position, player.transform.position);
            playerAggro = playerNoise.noise + 1 / distance;

            if (playerAggro > targetPlayerAggro)
            {
                targetPlayerAggro = playerAggro;
                targetPlayer = player;
                searchDistance = distance;
            }
        }
    }

    public float ProximityIndicator()
    {
        float alertLevel = searchDistance > searchStartDistance * 1.25 ? 0f :
                           searchDistance > searchStartDistance * 1 ? 0.25f :
                           searchDistance > searchStartDistance * 0.75 ? 0.5f :
                           searchDistance > searchStartDistance * 0.5 ? 0.75f :
                           searchDistance > searchStartDistance * 0.25 ? 4 : 1f;
        
        return alertLevel;
    }

    void MoveToPlayer(float noise)
    {
        Vector3 destination = targetPlayer.transform.position;
        float speedMult = noise >= noiseThreshhold * 10 ? 10f :
                          noise >= noiseThreshhold * 6 ? 2.25f :
                          noise >= noiseThreshhold * 4 ? 2f :
                          noise >= noiseThreshhold * 2 ? 1.75f :
                          noise >= noiseThreshhold ? 1.5f : 1;
        float moveSpeed = Time.deltaTime * speed * speedMult;

        transform.position = Vector3.MoveTowards(
            transform.position, destination, moveSpeed);
    }

    void SearchPlayer()
    {
        searchAngle += Time.deltaTime * speed;
        int speedMult = searchCount < (searchLimit / 3) * 2 ? 1 : 2;
        float x = searchRadius * Mathf.Sin(searchAngle);
        float z = searchRadius * Mathf.Cos(searchAngle);

        Vector3 searchDestination = new Vector3(x, 0, z) + transform.position;
        float searchSpeed = Time.deltaTime * speed * speedMult;

        transform.position = Vector3.MoveTowards(
            transform.position, searchDestination, searchSpeed);
    }

    void StopSearchPlayer()
    {
        targetPlayer.GetComponent<playerNoise>().noise += 10;
        searchCount = 0;
    }

    IEnumerator SearchCycle(GameObject player)
    {
        searchCount += 1;

        yield return new WaitForSeconds(1);

        if (searchCount >= searchLimit || player != targetPlayer)
        {
            searchCount = 0;
        }
        else
        {
            StartCoroutine(SearchCycle(player));
        }
    }
}