using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showDebugger : MonoBehaviour
{
    private int clickCount = 0;
    private Canvas debugger; 

    void Start()
    {
        debugger = gameObject.GetComponent<Canvas>();
    }

    IEnumerator CountClicks()
    {
        yield return new WaitForSeconds(5);
        clickCount = 0;
    }

    public void ToggleDebugger()
    {
        clickCount += 1;

        if (clickCount == 1)
        {
            StartCoroutine(CountClicks());
        }

        if (clickCount == 5)
        {
            if (debugger.enabled) debugger.enabled = false;
            else debugger.enabled = true;
            clickCount = 0;
        }
    }
}
