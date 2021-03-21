using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class CreateNewGame : MonoBehaviourPunCallbacks
{

    public Text roomID;

    // Start is called before the first frame update
    void Start()
    {
        if (!PhotonNetwork.InRoom) {
            CreateRoom();
        } else {
            roomID.text = PhotonNetwork.CurrentRoom.Name;
        }
    }

    void CreateRoom() {
        GenerateID();
        PhotonNetwork.CreateRoom(roomID.text, new RoomOptions(), null);
    }

    void GenerateID() {
        const string glyphs= "abcdefghijklmnopqrstuvwxyz0123456789";
        string newID = "";

        for (int i = 0; i < 5; i++) {
            newID += glyphs[UnityEngine.Random.Range(0, glyphs.Length)];
        }

        roomID.text = newID;
    }

    public override void OnRoomPropertiesUpdate(Hashtable propsThatChanged) {
        if (propsThatChanged.ContainsKey("readyToJoin")) {
            bool readyToJoin = (bool) propsThatChanged["readyToJoin"];
            if (readyToJoin && !PhotonNetwork.IsMasterClient) {
                PhotonNetwork.LoadLevel("Multiplayer");
            }
        }
    }
}
