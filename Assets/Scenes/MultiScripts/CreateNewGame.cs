using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CreateNewGame : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        //create and connect to a random room
        CreateRoom();
    }

    void CreateRoom() {
        //this will be changed later to generated random string
        string roomID = "V5GH4";
        PhotonNetwork.CreateRoom(roomID, new RoomOptions(), null);
    }
}
