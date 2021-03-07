using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerObjective : MonoBehaviour
{
    public GameObject OpenTaskButton;
    public GameObject Task;

    void Start()
    {
        // GameObject OpenTaskButton = GameObject.Find("OpenTaskButton");
        // Button OpenTaskButton = OpenTaskButtonObj.GetComponent<Button>();
        OpenTaskButton.SetActive(false);
        Task.SetActive(false);
    }

    void OnTriggerStay(Collider collidedObj)
    {
        Debug.Log("Objective??");
        if(collidedObj.gameObject.tag == "Objective"){
            Debug.Log("Yes Objective");
            OpenTaskButton.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collidedObj)
    {
        Debug.Log("Out?");
        if(collidedObj.gameObject.tag == "Objective"){
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
