using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskHoldButton : MonoBehaviour
{
    
    public int countDown;
    public GameObject CountDownText;
    public GameObject TaskComplete;
    private UnityEngine.UI.Text textComponent;

    public GameObject Objective;
    public Material CompletionMaterial;

    public void HandleHoldButton()
    {
        textComponent = CountDownText.GetComponent<UnityEngine.UI.Text>();
        textComponent.text = countDown.ToString();
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        if(countDown > 0){
            yield return new WaitForSeconds(1);
            countDown -= 1;
            textComponent.text = countDown.ToString();
            StartCoroutine(CountDown());
        }else if(countDown <= 0){
            TaskComplete.SetActive(true);
            Objective.GetComponent<MeshRenderer>().material = CompletionMaterial;
        }
       
    }


}
