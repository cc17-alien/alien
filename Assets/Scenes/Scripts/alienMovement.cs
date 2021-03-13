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
    public float searchThreashhold;

    playerNoise playerNoise;
    GameObject targetPlayer;

    private float searchAngle = 0f;
    private int searchCount = 0;
    private float searchDistance = 0f;

    void Update()
    {
        SetSearchPlayerAndDistance();

        if (searchCount == 0)
        {
            if (searchDistance <= searchThreashhold &&
                targetPlayer.GetComponent<playerNoise>().noise <= noiseThreshhold)
            {
                StartCoroutine(SearchCycle(targetPlayer));
            }
            else
            {
                MoveToPlayer();
            }
        }
        else
        {
            if (targetPlayer.GetComponent<playerNoise>().noise > noiseThreshhold)
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

    void MoveToPlayer()
    {
        Vector3 destination = targetPlayer.transform.position;
        transform.position = Vector3.MoveTowards(
            transform.position, destination, Time.deltaTime * speed);      
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