using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class ManageScenes : MonoBehaviour
{
    public void CreateGame() {
      SceneManager.LoadScene("CreateGame");
    }

    public void WaitAsHost() {
      Debug.Log("WAIT AS HOST CALLED");
      SceneManager.LoadScene("HostWaits");
    }

    public void JoinGame() {
      SceneManager.LoadScene("JoinRoom");
    }

    public void StartGame() {
      Hashtable roomSettings = new Hashtable();
      roomSettings.Add("readyToJoin", true);
      PhotonNetwork.CurrentRoom.SetCustomProperties(roomSettings);

      PhotonNetwork.LoadLevel("Multiplayer");
      //SceneManager.LoadScene("Multiplayer");
    }
}
