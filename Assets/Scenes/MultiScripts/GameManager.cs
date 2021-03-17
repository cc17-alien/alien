using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

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
            setEndingScene("AllEaten");
            //SceneManager.LoadScene("AllEaten");
        }

         //Congratulations
        int objectiveNumber = GameObject.FindGameObjectsWithTag("Objective").Length;
                
        if(objectiveNumber == 0){
            setEndingScene("Congratulations");
            //SceneManager.LoadScene("Congratulations"); 
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

    void setEndingScene(string sceneName) {
        Hashtable roomSettings = PhotonNetwork.CurrentRoom.CustomProperties;

        roomSettings.Add("sceneName", sceneName);

        PhotonNetwork.CurrentRoom.SetCustomProperties(roomSettings);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) {
        Debug.LogFormat("{0} Players Connected.", PhotonNetwork.CurrentRoom.PlayerCount);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer) {
        Debug.LogFormat("{0} Players Connected.", PhotonNetwork.CurrentRoom.PlayerCount);
    }

    public override void OnRoomPropertiesUpdate(Hashtable propsThatChanged) {
        // string sceneName = (string) propsThatChanged["sceneName"];
        // PhotonNetwork.LoadLevel(sceneName);
    }
}
