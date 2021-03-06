using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienMovement : MonoBehaviour
{
    public float speed;
    playerNoise playerNoise;
    GameObject previousPlayer;

    void Update()
    {
        GameObject[] arrayOfPlayerObjects = GameObject.FindGameObjectsWithTag("Player");
        float previousPlayerAggro = 0;
        float playerAggro;

        
        foreach (GameObject player in arrayOfPlayerObjects){
            playerNoise = player.GetComponent<playerNoise>();
            float distance = Vector3.Distance(transform.position, player.transform.position);
            playerAggro = playerNoise.noise + 1 / distance;
            if(playerAggro > previousPlayerAggro){
                previousPlayerAggro = playerAggro;
                previousPlayer = player;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, previousPlayer.transform.position, Time.deltaTime * speed);      
    }    
}