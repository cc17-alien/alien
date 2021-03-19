using UnityEngine;
using UnityEngine.UI;

public class playerDebugger : MonoBehaviour
{
    public Text DebuggerText;

    playerNoise playerNoise;

    void Start()
    {
        float noise = GetComponent<playerNoise>().noise;
        Debug.Log(noise);
    }

    void Update()
    {
        float noise = GetComponent<playerNoise>().noise;
        float speed = GetComponent<playerNoise>().speed;
        float movement = GetComponent<playerNoise>().lastMovement;
        DebuggerText.text = "noise: " + noise.ToString() +
                            "\nspeed: " + speed.ToString() +
                            "\nmovement: " + movement.ToString();
    }
}
