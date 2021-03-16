using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class HandleGameOver : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgain() {
        //WIP = will need to find way to know host/nonhost player
        Debug.Log("PLAY AGAIN CALLED");
        SceneManager.LoadScene("HostWaits");
    }

    public void BackToHome() {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom() {
        SceneManager.LoadScene("Home");
    }
}
