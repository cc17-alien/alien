using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
