using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borderSize : MonoBehaviour
{
    public GameObject borderleft;

    private float width;
    private float height;
    // Start is called before the first frame update
    void Start()
    {
        // width = GetComponent<RectTransform>().sizeDelta.x;
        height = borderleft.GetComponent<RectTransform>().sizeDelta.x;
        // Debug.Log(height);

        // GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);

        // Debug.Log(width);
        //get the width of border left
        //chage self height to equal the width of border left


        var rt = GetComponent<RectTransform>();
        // rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100);
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
    }

}
