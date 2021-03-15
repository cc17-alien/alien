using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class WaitingManager : MonoBehaviourPunCallbacks
{
    int numOfPlayers;
    public Text numOfPlayersText;

    void updatePlayers() {
        numOfPlayers = PhotonNetwork.CurrentRoom.PlayerCount;
        numOfPlayersText.text = numOfPlayers.ToString();
    }

    public override void OnJoinedRoom() {
        updatePlayers();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) {
        updatePlayers();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer) {
        updatePlayers();
    }
}
