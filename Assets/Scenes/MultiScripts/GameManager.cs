using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{

    public GameObject playerPrefab;
    GameObject playerInstance;

    void Start()
    {
        SpawnPlayer();
    }

    void Update()
    {
        GameObject[] arrayOfPlayerObjects = GameObject.FindGameObjectsWithTag("Player");

         if (arrayOfPlayerObjects.Length == 0) {
             Debug.Log("No Players Remaining");
             SceneManager.LoadScene("AllEaten");
         }

         //Congratulations
        int objectiveNumber = GameObject.FindGameObjectsWithTag("Objective").Length;
                
        if(objectiveNumber == 0){
            SceneManager.LoadScene("Congratulations"); 
        }
    }

    void SpawnPlayer() {
        playerInstance = PhotonNetwork.Instantiate(
            this.playerPrefab.name,
            new Vector3(0f, -20f, 0f),
            Quaternion.identity,
            0
        );
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) {
        Debug.LogFormat("{0} Players Connected.", PhotonNetwork.CurrentRoom.PlayerCount);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer) {
        Debug.LogFormat("{0} Players Connected.", PhotonNetwork.CurrentRoom.PlayerCount);
    }
}
