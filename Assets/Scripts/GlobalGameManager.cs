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

    public void LoadCalibrationScene()
    {
        SceneManager.LoadScene("calibration-scene", LoadSceneMode.Single);
    }

    public void TestTest()
    {
        Debug.Log("button pressed");
        
    }

    public void TestPush()
    {
        Debug.Log("button pushed");

    }

    public void TestRelease()
    {
        Debug.Log("button released");

    }


}
