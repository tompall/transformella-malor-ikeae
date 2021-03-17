using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GlobalGameManager : MonoBehaviour
{


    public GameObject[] objectsToReactivateOnRestart;
    public GameObject[] objectsToDeActivateOnRestart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RestartNarrativeAnywhere()
    {
        foreach (GameObject gob in objectsToReactivateOnRestart)
        {
            gob.SetActive(true);
        }

        foreach (GameObject gob in objectsToDeActivateOnRestart)
        {
            gob.SetActive(false);
        }
    }

 

}
