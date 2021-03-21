using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class OnlineTaskHold : MonoBehaviourPun
{

    public int countDown;
    public int noiseIncreation = 10;

    [Header("Bellow should be assigned to it's own parent/sybling")]
    public GameObject Objective;
    public GameObject ObjectiveSprite;
    public Sprite CompletionSprite;
    
    public GameObject ObjectiveLamp;
    public Sprite CompletionLampSprite;

    public GameObject Gauge1;
    public GameObject Gauge2;
    public GameObject Gauge3;
    public GameObject Gauge4;
    public GameObject Gauge5;
    public GameObject GaugePannel;

    public GameObject HoldButton;

    [HideInInspector]
    public GameObject InteractingPlayer;

    private IndicatorX IndicatorX;
    private Transform transformX;

    public void HandleHoldButton()
    {
        StartCoroutine(CountDown());
    }

    [PunRPC]
    void CompleteTask() {
        GaugePannel.SetActive(false);
        ObjectiveSprite.GetComponent<SpriteRenderer>().sprite = CompletionSprite;
        Objective.tag = "TaskComplete";
        ObjectiveLamp.GetComponent<Image>().sprite = CompletionLampSprite;

        //setting IndicatorX's & Y's "isComplete" to true (to change it's color and size);
        GetComponentInChildren<IndicatorX>().isComplete = true;
        GetComponentInChildren<IndicatorY>().isComplete = true;
    }

    IEnumerator CountDown()
    {
        if (countDown > 0 && HoldButton.activeSelf)
        {
            yield return new WaitForSeconds(1);
            InteractingPlayer.GetComponent<playerNoise>().noise += noiseIncreation = 10;


            Gauge1.SetActive(true);
            if(countDown == 4){
                Gauge2.SetActive(true);
            }else if(countDown == 3){
                Gauge2.SetActive(true);
                Gauge3.SetActive(true);
            }else if(countDown == 2){
                Gauge2.SetActive(true);
                Gauge3.SetActive(true);
                Gauge4.SetActive(true);
            }else if(countDown == 1){
                Gauge2.SetActive(true);
                Gauge3.SetActive(true);
                Gauge4.SetActive(true);
                Gauge5.SetActive(true);
            }
            
            countDown -= 1;
            StartCoroutine(CountDown());
        }
        else if (countDown <= 0)
        {
            yield return new WaitForSeconds(1);
            if (PhotonNetwork.IsConnected) {
                photonView.RPC("CompleteTask", RpcTarget.All);
            } else {
                CompleteTask();
            }
        }
    }
}
