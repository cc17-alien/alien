using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerEaten : MonoBehaviour
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
            SceneManager.LoadScene("YouAreEaten");
        }
    }
}
