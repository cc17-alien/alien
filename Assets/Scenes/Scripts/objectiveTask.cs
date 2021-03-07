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
        Debug.Log("Player??");
        if (collidedObj.gameObject.tag == "Player")
        {
            Debug.Log("Yes Player");
            OpenTaskButton.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collidedObj)
    {
        Debug.Log("Out?");
        if (collidedObj.gameObject.tag == "Player" || collidedObj.gameObject.tag == "Eaten")
        {
            Debug.Log("Out!!!!");
            OpenTaskButton.SetActive(false);    
            Task.SetActive(false);
        }
    }

    public void SetTaskActive()
    {
        Task.SetActive(true);
    }
    public void SetTaskInactive()
    {
        Task.SetActive(false);
    }
}
