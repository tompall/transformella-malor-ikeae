using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GlobalGameManager : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
