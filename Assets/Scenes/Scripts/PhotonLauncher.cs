using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class PhotonLauncher : MonoBehaviourPunCallbacks
{

    // Start is called before the first frame update
    void Start()
    {
        Connect();
    }

    // Update is called once per frame
    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    #region PunCallbacks

    public override void OnConnectedToMaster() {
        Debug.Log("OnConnectedToMaster called by PUN");
    }

    public override void OnDisconnected(DisconnectCause cause) {
        Debug.LogWarningFormat("OnDisconnected called by PUN with reason {0}", cause);
    }

    public override void OnJoinedRoom() {
        Debug.Log("OnJoinedRoom called by PUN, user is in room");
        SceneManager.LoadScene(1);
    }

    #endregion

    #region public methods

    public void Connect() {
        if (!PhotonNetwork.IsConnected) {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    #endregion
}
