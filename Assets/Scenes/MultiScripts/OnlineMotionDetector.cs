using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OnlineMotionDetector : MonoBehaviourPun, IPunObservable
{
    public GameObject playerDot;

    public GameObject UI;

    private Camera mainCamera;
    
    public int noiseIncreation = 5;


    void Awake() {
        EnableCanvas();
    }

    void EnableCanvas() {
        if (PhotonNetwork.IsConnected && photonView.IsMine) {
            playerDot.SetActive(true);
            UI.SetActive(true);
        }
    }

    public void ToggleMotionDetector()
    {

        mainCamera = GetComponentInChildren<Camera>();

        if (mainCamera.cullingMask == -1)
        {
            mainCamera.cullingMask = ~(1 << LayerMask.NameToLayer("Alien"));
            StopAllCoroutines();
        }
        else
        {
            mainCamera.cullingMask = -1;
            StartCoroutine(IncreasePlayerNoise());
        }
    }
    IEnumerator IncreasePlayerNoise()
    {
        GetComponent<playerNoise>().noise += noiseIncreation;
        yield return new WaitForSeconds(1);
        StartCoroutine(IncreasePlayerNoise());
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {

    }
}

