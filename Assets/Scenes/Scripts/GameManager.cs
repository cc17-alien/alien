using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] arrayOfPlayerObjects = GameObject.FindGameObjectsWithTag("Player");

         if (arrayOfPlayerObjects.Length == 0) {
             SceneManager.LoadScene(2);
         } 

        //congratulations
        int objectiveNumber = GameObject.FindGameObjectsWithTag("Objective").Length;
             
        if(objectiveNumber == 0){
            SceneManager.LoadScene(3);
    }
}
}
