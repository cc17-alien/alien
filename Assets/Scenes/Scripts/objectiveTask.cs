using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectiveTask : MonoBehaviour
{
[Header("Bellow should be assigned to it's own child")]

    public GameObject Task;
    public GameObject HoldButton;
    public GameObject ObjectiveLamp;

    void Start()
    {
        Task.SetActive(false);
        ObjectiveLamp.SetActive(false);
    }

    void OnTriggerStay(Collider collidedObj)
    {
        if (collidedObj.gameObject.tag == "Player")
        {
            ObjectiveLamp.SetActive(true);
            HoldButton.SetActive(true);
            Task.transform.parent.parent.gameObject.GetComponentInChildren<TaskHoldButton>().InteractingPlayer = collidedObj.gameObject;
        }else if(collidedObj.gameObject.tag == "Eaten")
        {
            Task.SetActive(false);
            HoldButton.SetActive(false);
            ObjectiveLamp.SetActive(false);
        }
    }

    void OnTriggerExit(Collider collidedObj)
    {
        if (collidedObj.gameObject.tag == "Player")
        {
            Task.SetActive(false);
            HoldButton.SetActive(false);
            ObjectiveLamp.SetActive(false);
        }
    }

}
