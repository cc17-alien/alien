using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerObjective : MonoBehaviour
{
    void OnTriggerStay(Collider collidedObj)
    {
        Debug.Log("Objective??");
        if(collidedObj.gameObject.tag == "Objective"){
            Debug.Log("Yes Objective");
        }
    }
}
