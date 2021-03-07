using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectiveTask : MonoBehaviour
{
[Header("Bellow should be assigned to it's own child")]
    public GameObject OpenTaskButton;
    public GameObject Task;

    void Start()
    {
        OpenTaskButton.SetActive(false);
        Task.SetActive(false);
    }

    void OnTriggerStay(Collider collidedObj)
    {
        if (collidedObj.gameObject.tag == "Player")
        {
            OpenTaskButton.SetActive(true);
            Task.GetComponentInChildren<TaskHoldButton>().InteractingPlayer = collidedObj.gameObject;
        }else if(collidedObj.gameObject.tag == "Eaten")
        {
            OpenTaskButton.SetActive(false);
            Task.SetActive(false);
        }
    }

    void OnTriggerExit(Collider collidedObj)
    {
        if (collidedObj.gameObject.tag == "Player")
        {
            OpenTaskButton.SetActive(false);    
            Task.SetActive(false);
        }
    }

}
