using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectiveTask : MonoBehaviour
{
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
