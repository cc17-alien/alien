using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class GameManager : MonoBehaviourPunCallbacks
{

    public GameObject playerPrefab;
    public GameObject objectivePrefab;
    GameObject playerInstance;

    private Vector3[] objectiveLocations = {
        new Vector3(-5f, 0f, 0f),
        new Vector3(-20f, 0f, -5f),
    };

    void Start()
    {
        SpawnObjectives();
        SpawnPlayer();
    }

    void Update()
    {
        GameObject[] arrayOfPlayerObjects = GameObject.FindGameObjectsWithTag("Player");

        if (arrayOfPlayerObjects.Length == 0) {
            Debug.Log("No Players Remaining");
            setEndingScene("AllEaten");
            return;
        }

        int objectiveNumber = GameObject.FindGameObjectsWithTag("TaskComplete").Length;
                
        if(objectiveNumber == objectiveLocations.Length){
            setEndingScene("Congratulations");
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

    void SpawnObjectives() {
        if (PhotonNetwork.IsMasterClient) {
            foreach (Vector3 location in objectiveLocations) {
                PhotonNetwork.Instantiate(
                    this.objectivePrefab.name,
                    location,
                    Quaternion.identity,
                    0
                );
            }
        }

    }

    void setEndingScene(string sceneName) {
        Hashtable roomSettings = PhotonNetwork.CurrentRoom.CustomProperties;
        if (!roomSettings.ContainsKey("sceneName")) {
            roomSettings.Add("sceneName", sceneName);
            PhotonNetwork.CurrentRoom.SetCustomProperties(roomSettings);
        } else {
            Debug.Log(roomSettings["sceneName"]);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) {
        Debug.LogFormat("{0} Players Connected.", PhotonNetwork.CurrentRoom.PlayerCount);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer) {
        Debug.LogFormat("{0} Players Connected.", PhotonNetwork.CurrentRoom.PlayerCount);
    }

    public override void OnRoomPropertiesUpdate(Hashtable propsThatChanged) {
        if (propsThatChanged.ContainsKey("sceneName")) {
            string sceneName = (string) propsThatChanged["sceneName"];
            PhotonNetwork.DestroyAll();
            PhotonNetwork.LoadLevel(sceneName);
        }
    }
}
