using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienMovement : MonoBehaviour
{
    public float speed;
    playerNoise playerNoise;
    GameObject previousPlayer;
    boolean circling = false;

    void Update()
    {
        GameObject[] arrayOfPlayerObjects = GameObject.FindGameObjectsWithTag("Player");
        float previousPlayerAggro = 0;
        float playerAggro;
        float chaseDistance = 0;

        foreach (GameObject player in arrayOfPlayerObjects){
            playerNoise = player.GetComponent<playerNoise>();
            float distance = Vector3.Distance(transform.position, player.transform.position);
            playerAggro = playerNoise.noise + 1 / distance;
            if (playerAggro > previousPlayerAggro){
                previousPlayerAggro = playerAggro;
                previousPlayer = player;
                chaseDistance = distance;
            }
        }

        if (chaseDistance <= 8.5 && previousPlayer.GetComponent<playerNoise>().noise <= 5)
        {

        }

        // if alien within 8.5 distance of player, patrols a 120 degree semicircle around player
        // player can move away from alien, but if noise increases alien moves to player
        // player has 2/3 chance to escape if he quietly moves in any dirction
        // after 10 seconds, if player > 20 distance from alien, alien moves off
        Vector3 playerLocation = previousPlayer.transform.position;
        Vector3 destination = chaseDistance <= 8.5 ? new Vector3(5, 0, 5) + playerLocation : playerLocation;
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);      
    }    
}