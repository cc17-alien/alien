using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class HandleJoinGame : MonoBehaviourPunCallbacks
{

    private string roomName = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setRoomName(string value) {
        roomName = value;
        //Debug.Log(roomName);
    }

    public void JoinOrCreatePrivateRoom() {
        PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions(), null);
    }

    public override void OnJoinedRoom() {
        Debug.Log("Joined Room!");
    }
}
