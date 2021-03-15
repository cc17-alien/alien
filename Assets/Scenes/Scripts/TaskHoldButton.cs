using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskHoldButton : MonoBehaviour
{

    public int countDown;
    public int noiseIncreation = 10;

    [Header("Bellow should be assigned to it's own parent/sybling")]
    public GameObject CountSecondsText;
    public GameObject TaskComplete;
    private UnityEngine.UI.Text textComponent;

    public GameObject Objective;
    public GameObject ObjectiveSprite;
    public Sprite CompletionSprite;

    [HideInInspector]
    public GameObject InteractingPlayer;

    private IndicatorX IndicatorX;
    private Transform transformX;
    private GameObject gameObjectX;

    public void HandleHoldButton()
    {
        textComponent = CountSecondsText.GetComponent<UnityEngine.UI.Text>();
        textComponent.text = countDown.ToString();
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        if (countDown > 0)
        {
            yield return new WaitForSeconds(1);
            InteractingPlayer.GetComponent<playerNoise>().noise += noiseIncreation = 10;
            countDown -= 1;
            textComponent.text = countDown.ToString();
            StartCoroutine(CountDown());
        }
        else if (countDown <= 0)
        {
            TaskComplete.SetActive(true);
            // Objective.GetComponent<MeshRenderer>().material = CompletionMaterial;
            ObjectiveSprite.GetComponent<SpriteRenderer>().sprite = CompletionSprite;
            Objective.tag = "TaskComplete";

            //setting IndicatorX's & Y's "isComplete" to true (to change it's color and size);
            transform.parent.parent.gameObject.GetComponentInChildren<IndicatorX>().isComplete = true;
            transform.parent.parent.gameObject.GetComponentInChildren<IndicatorY>().isComplete = true;
        }

    }


}
