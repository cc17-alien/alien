using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class YouAreEatenScene : MonoBehaviourPunCallbacks
{
    void Start() {
        Hashtable roomSettings = PhotonNetwork.CurrentRoom.CustomProperties;
        GameEndStatus(roomSettings);
    }

    void GameEndStatus(Hashtable roomSettings) {
        
        if (roomSettings.ContainsKey("sceneName")) {
            string sceneName = (string) roomSettings["sceneName"];
            PhotonNetwork.LoadLevel(sceneName);
        }
    }

    public override void OnRoomPropertiesUpdate(Hashtable propsThatChanged) {
        GameEndStatus(propsThatChanged);
    }
}
