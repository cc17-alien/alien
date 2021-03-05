using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienMovement : MonoBehaviour
{
    public float speed;
    GameObject player;
    playerNoise script;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<playerNoise>();
    }

    // Update is called once per frame
    GameObject previousPlayer;
    void Update()
    {
        GameObject[] arrayOfPlayerObjects = GameObject.FindGameObjectsWithTag("Player");
        float previousPlayerAggro = 0;
        float playerAggro;

        
        foreach (GameObject player in arrayOfPlayerObjects){
            var distance = Vector3.Distance(transform.position, player.transform.position);
            playerAggro = script.noise / distance;
            if(playerAggro > previousPlayerAggro){
                previousPlayerAggro = playerAggro;
                previousPlayer = player;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, previousPlayer.transform.position, Time.deltaTime * speed);      
    }    
}

/*
public class alienMovement : MonoBehaviour
{
    private GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    GameObject previousePlayer;
    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        float distanceToPreviousePlayer = 1000000;
        foreach (GameObject player in players) { 
                var distance = Vector3.Distance(transform.position, player.transform.position);
                if(distanceToPreviousePlayer > distance){
                    distanceToPreviousePlayer = distance;
                    previousePlayer = player;
                }
            }
        transform.position = Vector3.MoveTowards(transform.position, previousePlayer.transform.position, Time.deltaTime * speed);
        
    }
}*/
