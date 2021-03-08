using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class motionDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(SetMotionDetectorInactive());
        }
    }


    IEnumerator SetMotionDetectorInactive()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
