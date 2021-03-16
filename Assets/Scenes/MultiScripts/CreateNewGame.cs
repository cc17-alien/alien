using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
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
        //create and connect to a random room
            CreateRoom();
        } else {
            //need to test
            roomID.text = PhotonNetwork.CurrentRoom.Name;
        }
    }

    void CreateRoom() {
        //this will be changed later to generated random string
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

    public override void OnRoomPropertiesUpdate(Hashtable roomSettings) {
        bool readyToJoin = (bool) roomSettings["readyToJoin"];
        if (readyToJoin && !PhotonNetwork.IsMasterClient) {
            PhotonNetwork.LoadLevel("Multiplayer");
        }
    }
}
