using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateIndicator : MonoBehaviour
{
    public GameObject IndicatorX;
    public GameObject IndicatorY;
    private GameObject[] Objectives;
    private Vector3 objPosition;
    // Start is called before the first frame update
    void Start()
    {
        Objectives = GameObject.FindGameObjectsWithTag("Objective");
        foreach (GameObject objective in Objectives)
        {
            Instantiate(IndicatorX, objective.transform.parent.Find("Canvas"));
            Instantiate(IndicatorY, objective.transform.parent.Find("Canvas"));
        }
    }

}
