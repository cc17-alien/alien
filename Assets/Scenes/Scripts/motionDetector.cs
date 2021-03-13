using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motionDetector : MonoBehaviour
{
    private Camera mainCamera;
    public int noiseIncreation;
    public void ToggleMotionDetector()
    {
        mainCamera = GetComponent<Camera>();
        if (mainCamera.cullingMask == -1)
        {
            mainCamera.cullingMask = ~(1 << LayerMask.NameToLayer("Alien"));
            StopAllCoroutines();
        }
        else
        {
            mainCamera.cullingMask = -1;
            StartCoroutine(IncreasePlayerNoise());
        }

    }
    IEnumerator IncreasePlayerNoise()
    {
        yield return new WaitForSeconds(1);
        transform.parent.GetComponent<playerNoise>().noise += noiseIncreation;
        StartCoroutine(IncreasePlayerNoise());
    }
}
