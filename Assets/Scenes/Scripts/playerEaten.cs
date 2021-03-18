using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class playerEaten : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Alien")
        {
            gameObject.tag = "Eaten";
            Debug.Log("Collision Entered");

            if (photonView.IsMine) {
                SceneManager.LoadScene("YouAreEaten");
            }
        }
    }
}
