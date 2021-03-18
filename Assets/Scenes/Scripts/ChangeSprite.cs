using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{

    public Sprite onSprite;
    public Sprite offSprite;

    private bool isOn = false;

    public void ToggleSprite()
    {
        if (isOn)
        {
            GetComponent<Image>().sprite = offSprite;
            isOn = false;
        }
        else
        {
            GetComponent<Image>().sprite = onSprite;
            isOn = true;
        }
    }
}
