﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class objectiveTask : MonoBehaviourPun
{
[Header("Bellow should be assigned to it's own child")]

    public GameObject GaugePannel;
    public GameObject HoldButton;
    public GameObject ObjectiveLamp;

    void Start()
    {
        GaugePannel.SetActive(false);
        ObjectiveLamp.SetActive(false);
    }

    void OnTriggerStay(Collider collidedObj)
    {
        if (collidedObj.gameObject.tag == "Player")
        {
            Debug.Log(collidedObj);
            ObjectiveLamp.SetActive(true);
            HoldButton.SetActive(true);

            if (PhotonNetwork.IsConnected) {
                GaugePannel.transform.parent.parent.gameObject.GetComponentInChildren<OnlineTaskHold>().InteractingPlayer = collidedObj.gameObject;
            } else {
                GaugePannel.transform.parent.parent.gameObject.GetComponentInChildren<TaskHoldButton>().InteractingPlayer = collidedObj.gameObject;
            }
            
        }else if(collidedObj.gameObject.tag == "Eaten")
        {
            GaugePannel.SetActive(false);
            HoldButton.SetActive(false);
            ObjectiveLamp.SetActive(false);
        }
    }

    void OnTriggerExit(Collider collidedObj)
    {
        if (collidedObj.gameObject.tag == "Player")
        {
            GaugePannel.SetActive(false);
            HoldButton.SetActive(false);
            ObjectiveLamp.SetActive(false);
        }
    }

}
