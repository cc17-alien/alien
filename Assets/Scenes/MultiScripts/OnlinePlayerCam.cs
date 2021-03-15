using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OnlinePlayerCam : MonoBehaviourPun, IPunObservable
{
    public GameObject playerCam;
    private GameObject sceneCam;

    void Awake() {
        //maybe belongs in seperate player manager script
        DontDestroyOnLoad(this.gameObject);
        SwitchCamera();
    }

    void SwitchCamera() {
        if (PhotonNetwork.IsConnected && photonView.IsMine) {
            sceneCam = GameObject.Find("MainCamera");

            if (sceneCam != null) {
                sceneCam.SetActive(false);
            }

            playerCam.SetActive(true);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {

    }
}
