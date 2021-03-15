using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ManageScenes : MonoBehaviour
{
    public void CreateGame() {
      //this will be CreateGame later
      SceneManager.LoadScene("HostWaits");
    }

    public void JoinGame() {
      SceneManager.LoadScene("JoinRoom");
    }

    public void StartGame() {
      PhotonNetwork.LoadLevel("Multiplayer");
    }
}
