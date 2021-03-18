using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    }

    public void JoinPrivateRoom() {
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnJoinedRoom() {
        Debug.Log("Joining FriendsWait");
        SceneManager.LoadScene("FriendsWait");
    }
}
